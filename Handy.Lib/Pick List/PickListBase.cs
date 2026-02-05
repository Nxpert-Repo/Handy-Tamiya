using System;
using System.Collections.Generic;
using System.Data;
using DataHelper;
using CEDataHelper;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Drawing;

namespace Handy.Lib
{
    //20130416 Allen Added: Pick List Base Class
    public class PickListBase
    {
        
        public static bool GeneratePicklist()
        {
            bool _return = false;

            if (CommonFunctions.IsConnected())
            {
                //Getting WRIS List of stocks
                try { CommonFunctions.WRISTable.Dispose(); 
                      CommonFunctions.PickListTable.Dispose(); 
                } catch { }
                CommonFunctions.WRISTable = CommonFunctions.GetData(string.Format(@"SELECT Wrd_WHReqControlNo [WRISNo],
	                                                                                       Wrd_ReqSeqNo [ReqSeqNo],
	                                                                                       Wrd_ReqSplitSeqNo [ReqSplitSeqNo],
	                                                                                       Wrd_Stockcode [Stockcode],
                                                                                           dbo.GETStockName(Wrd_Stockcode, Wrd_StockTypeCode) [Stockname], 
                                                                                           Rst_StockTypCode [StockTypeCode],
                                                                                           Rst_StockSpecs [Specs],
	                                                                                       Wrd_SiQuantity [SiQuantity],
	                                                                                       Wrd_RequestedQty [RequestedQty],
	                                                                                       Wrd_ReservedQty [ReservedQty],
	                                                                                       Wrd_IssuedQty [IssuedQty],
	                                                                                       Wrd_SiUnit [SiUnit],
	                                                                                       Wrd_RRNo [RRNo],
	                                                                                       Wrd_RRSeqNo [RRSeqNo],
	                                                                                       Wrd_RRLotSeqNo [RRLotSeqNo],
	                                                                                       Wrd_RRlocseqno [RRlocseqno],
	                                                                                       Wrd_loccode [Locatorcode],
	                                                                                       Wrd_remarks [Remarks],
	                                                                                       Wrd_IssueStatus [IssueStatus],
	                                                                                       Wrd_status [Status],
	                                                                                       WRD.User_login,
	                                                                                       WRD.ludatetime	        
                                                                                      FROM T_WarehouseRequisitionDetail WRD
                                                                                 LEFT JOIN T_RawMaterialsAndSupplies RMAS
                                                                                        ON Wrd_Stockcode = Rst_Stockcode
                                                                                     WHERE Wrd_WHReqControlNo = '{0}'
                                                                                       AND Wrd_IssueStatus = 'N'
                                                                                       AND Wrd_Status = 'A'
                                                                                  ORDER BY Wrd_StockCode", CommonFunctions.BarcodeWHReqControlNo));
                //CommonFunctions.PickListTable = CommonFunctions.GetData(sng.Format(CommonQueryStrings.StoredProc.spHandyGetFifoPickList
                //                                                                     , CommonFunctions.BarcodeWHReqControlNo
                //                                                                     , CommonFunctions.CommitPickList == true ? "1" : "0"
                //                                                                     , CommonFunctions.Username));

                if (CommonFunctions.WRISTable != null)
                {
                    if (CommonFunctions.WRISTable.Rows.Count <= 0)
                    {
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Error.d_NoPickList, CommonFunctions.BarcodeWHReqControlNo), CommonEnum.NotificationType.Warning);
                        _return = false;
                    }
                    //else if (CommonFunctions.PickListTable.Rows.Count > 0 && CommonFunctions.CommitPickList)
                    //{
                    //    CommonFunctions.MessageShow(string.Format(CommonMsg.Success.d_FifoGenereationCommitted, CommonFunctions.BarcodeWHReqControlNo), CommonEnum.NotificationType.Success);
                    //    _return = true;
                    //}
                    else
                    {
                        _return = true;
                    }
                }
            }

            return _return;
        }

        public static bool isRRScanValid()
        {
            if (string.IsNullOrEmpty(CommonFunctions.BarcodeRRNo))
            {
                CommonFunctions.MessageShow(CommonMsg.Warning.RREmpty, CommonEnum.NotificationType.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(CommonFunctions.BarcodeQuantity))
            {
                CommonFunctions.MessageShow(CommonMsg.Warning.QtyEmpy, CommonEnum.NotificationType.Warning);
                return false;
            }
            else if (CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity) <= 0)
            {
                CommonFunctions.MessageShow(CommonMsg.Warning.InvalidQty, CommonEnum.NotificationType.Warning);
                return false;                
            }
            else if (isRRScanned())
            {
                CommonFunctions.MessageShow(CommonMsg.Warning.ItemIsUsed, CommonEnum.NotificationType.Warning);
                return false;
            }
            else if (isWRISStockFull())
            {
                CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_NoAvailableRequestQty
                                        , CommonFunctions.BarcodeStockCode
                                        , CommonFunctions.GetStockName(CommonFunctions.BarcodeStockCode))
                                        , CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.Ok);
                return false;
            }

            bool hasQty = false;            
            bool stockcodeMatched = false;
            foreach (DataRow row in CommonFunctions.WRISTable.Rows)
            {
                if (row["Stockcode"].ToString().Trim().Equals(CommonFunctions.BarcodeStockCode))
                {
                    stockcodeMatched = true;
                    if (CommonFunctions.ConvertStringDecimal(row["RequestedQty"].ToString()) - CommonFunctions.ConvertStringDecimal(row["ReservedQty"].ToString()) > 0)
                        hasQty = true;
                }
            }

            return hasQty && stockcodeMatched;
        }

        public static bool isRRScanned()
        {
            foreach (DataRow row in CommonFunctions.WRISTable.Rows)
            {
                if (row["RRNo"].ToString().Equals(CommonFunctions.BarcodeRRNo) &&
                    row["RRSeqNo"].ToString().Equals(CommonFunctions.BarcodeRRSeq) &&
                    row["RRLotSeqNo"].ToString().Equals(CommonFunctions.BarcodeRRLotSeq) &&
                    row["RRlocseqno"].ToString().Equals(CommonFunctions.BarcodeRRLocSeq) &&
                    CommonFunctions.ConvertStringDecimal(row["ReservedQty"].ToString()) <= GetRRAvailableQty())
                    return true;
            }
            
            return false;
        }

        public static int fillRR()
        {
            DataRow clone = null;
            int retVal = 0;
            int ctr = 0;
            foreach (DataRow row in CommonFunctions.WRISTable.Rows)
            {
                if (row["Stockcode"].ToString().Trim().Equals(CommonFunctions.BarcodeStockCode) && 
                    CommonFunctions.ConvertStringDecimal(row["RequestedQty"].ToString().Trim()) > CommonFunctions.ConvertStringDecimal(row["ReservedQty"].ToString().Trim()))
                {
                    retVal = ctr;
                    if (CommonFunctions.ConvertStringDecimal(row["RequestedQty"].ToString().Trim()) - CommonFunctions.ConvertStringDecimal(row["ReservedQty"].ToString().Trim())  > CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity))
                    {             
                            row["RequestedQty"] = CommonFunctions.ConvertStringDecimal(row["RequestedQty"].ToString()) - CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity);

                            clone = CommonFunctions.WRISTable.NewRow();
                            clone.ItemArray = row.ItemArray.Clone() as object[];
                            row["ReservedQty"] = CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity);                         
                            //string tempStr = "000" + (CommonFunctions.ConvertStringDecimal(clone["ReqSplitSeqNo"].ToString().Trim()) + 1);
                            //clone["ReqSplitSeqNo"] = tempStr.Substring(tempStr.Length - 3, 3);        
                            clone["ReqSplitSeqNo"] = string.Empty;
                    }
                    else
                    {
                        row["ReservedQty"] = CommonFunctions.ConvertStringDecimal(row["RequestedQty"].ToString().Trim());
                    }
                    row["RRNo"] = CommonFunctions.BarcodeRRNo;
                    row["RRSeqNo"] = CommonFunctions.BarcodeRRSeq;
                    row["RRLotSeqNo"] = CommonFunctions.BarcodeRRLotSeq;
                    row["RRlocseqno"] = CommonFunctions.BarcodeRRLocSeq;
                }
                if (clone != null)
                    break;
                ctr++;
            }

            if (clone != null)
            {
                CommonFunctions.WRISTable.Rows.InsertAt(clone, CommonFunctions.WRISTable.Rows.Count);
                //ListViewItem lst = new ListViewItem();
                ////lst.Text = clone["ReqSeqNo"].ToString().Trim();
                ////lst.SubItems.Add(clone["ReqSplitSeqNo"].ToString().Trim());
                ////lst.SubItems.Add(clone["Stockcode"].ToString().Trim());
                //lst.Text = clone["Stockname"].ToString().Trim();
                ////lst.SubItems.Add(clone["Stockname"].ToString().Trim());
                ////lst.SubItems.Add(clone["Specs"].ToString().Trim());
                ////lst.SubItems.Add(clone["StockTypeCode"].ToString().Trim());
                ////lst.SubItems.Add(clone["SiQuantity"].ToString().Trim());
                //lst.SubItems.Add(String.Format("{0:0.00}", clone["RequestedQty"]));
                //lst.SubItems.Add(String.Format("{0:0.00}", clone["ReservedQty"]));
                ////lst.SubItems.Add(String.Format("{0:0.00}", clone["IssuedQty"]));
                ////lst.SubItems.Add(clone["RRNo"].ToString().Trim());
                ////lst.SubItems.Add(clone["RRSeqNo"].ToString().Trim());
                ////lst.SubItems.Add(clone["RRLotSeqNo"].ToString().Trim());
                ////lst.SubItems.Add(clone["RRlocseqno"].ToString().Trim());
                ////lst.SubItems.Add(clone["IssueStatus"].ToString().Trim());
                ////lst.SubItems.Add(clone["Status"].ToString().Trim());

                //return lst;
            }
            return retVal;
        }

        public static bool isWRISStockFull()
        {
            decimal totalReq = 0;
            decimal totalRes = 0;
            foreach (DataRow row in CommonFunctions.WRISTable.Rows)
            {
                if (row["Stockcode"].ToString().Trim().Equals(CommonFunctions.BarcodeStockCode))
                {
                    totalReq += CommonFunctions.ConvertStringDecimal(row["RequestedQty"].ToString().Trim());
                    totalRes += CommonFunctions.ConvertStringDecimal(row["ReservedQty"].ToString().Trim());
                }
            }

            return totalReq == totalRes;
        }

        public static decimal GetRRAvailableQty()
        {
            return CommonFunctions.ConvertStringDecimal(CommonFunctions.GetData(string.Format(@"SELECT Rrd_LocaQuantity - (Rrd_ReservedQty + Rrd_IssuedQty)
                                        FROM T_ReceivingReportDetail
                                       WHERE Rrd_RRNo = '{0}'
                                         AND Rrd_RRSeqNo = '{1}'
                                         AND Rrd_LotSeqNo = '{2}'
                                         AND Rrd_RRlocseqno = '{3}'",CommonFunctions.BarcodeRRNo
                                                                    ,CommonFunctions.BarcodeRRSeq
                                                                    ,CommonFunctions.BarcodeRRLotSeq
                                                                    ,CommonFunctions.BarcodeRRLocSeq)).Rows[0][0].ToString());
        }

        public static void Commit()
        {
            foreach (DataRow row in CommonFunctions.WRISTable.Rows)
            {
                if (CommonFunctions.ConvertStringDecimal(row["ReservedQty"].ToString().Trim()) > 0 || row["ReqSplitSeqNo"].ToString().Trim().Equals(string.Empty))
                {
                    CommonFunctions.ExecuteNonQuery(string.Format(CommonQueryStrings.StoredProc.spHandyPicklistAssignment
                                                                    , row["WRISNo"].ToString().Trim()
                                                                    , row["ReqSeqNo"].ToString().Trim()
                                                                    , row["ReqSplitSeqNo"].ToString().Trim()
                                                                    , row["ReservedQty"].ToString().Trim()
                                                                    , row["RRNo"].ToString().Trim()
                                                                    , row["RRSeqNo"].ToString().Trim()
                                                                    , row["RRLotSeqNo"].ToString().Trim()
                                                                    , row["RRlocseqno"].ToString().Trim()
                                                                    , CommonFunctions.Username));

                }
            }
        }
    }
}
