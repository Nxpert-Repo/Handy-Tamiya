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
    public class CoilDefraggingBase
    {
        public static void SendingThreadCoilDefragging()
        {
            try
            {
                if (CommonFunctions.IsConnected())
                {
                    /***** Nilo Commented 20130627 : Transferred to getreceivingreportinfo checking only for issued items *****/
                    //if (CommonFunctions.IsBarcodeOutDated())
                    //{
                    //    CommonFunctions.NewLocSeqNo = "N";
                    //    return;
                    //}

                    using (DataTable dt = CommonFunctions.CEGetData("SELECT * FROM CoilDefragging WHERE SentFlag = 0 AND ScanFlag = 1 ORDER BY UniqueId"))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                CommonFunctions.Result = CommonFunctions.DataReader("EXEC dbo.spHandyCoilDefragging '"
                                    + row["RRNo"].ToString().Trim() + "','"
                                    + row["RRSeqNo"].ToString().Trim() + "','"
                                    + row["LotSeqNo"].ToString().Trim() + "','"
                                    + row["LocSeqNo"].ToString().Trim() + "','"
                                    + row["Locatorcode"].ToString().Trim() + "','"
                                    + (int)row["LayerNo"] + "','"
                                    + (int)row["LayerSeqNo"] + "','"
                                    //+ row["Quantity"].ToString().Trim() + "','"
                                    + CommonFunctions.Username + "'");
                            }
                        }

                        if (dt.Rows.Count == 0)
                            CommonFunctions.MessageShow(string.Empty
                                        , CommonMsg.Info.DataUpdated
                                        , CommonEnum.NotificationType.Information
                                        , CommonEnum.MessageButtons.CloseOnly);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

        public static bool CheckLocator()
        {
            return (CommonFunctions.LocatorCode != CommonFunctions.OldLocatorCode) ? true : false;
        }

        public static DataTable GetLocatorList()
        {
            DataTable dt = CommonFunctions.GetData(string.Format(@"SELECT Ldt_LayerNo AS LayerNo
	                                                    ,Ldt_LayerSeqNo AS LayerSeqNo
                                                    FROM E_LocatorDetail
                                                    WHERE (Ldt_RRNo <> '' OR Ldt_RRNo IS NOT NULL)
                                                    AND Ldt_LocatorCode = '{0}'
                                                    ORDER BY Ldt_LayerNo,Ldt_LayerSeqNo", CommonFunctions.LocatorCode));
            return dt;
        }

        public static void GetLocatorInfo()
        {
            DataTable dt = CommonFunctions.GetData(string.Format(@"SELECT Ldt_LayerNo AS LayerNo
                                               ,Ldt_LayerSeqNo AS LayerSeqNo
                                            FROM E_LocatorDetail
                                            WHERE Ldt_RRNo = '{0}'
                                            AND Ldt_RRSeqNo = '{1}'
                                            AND Ldt_RRLotSeqNo = '{2}'
                                            AND Ldt_RRLocSeqNo = '{3}'
                                            AND Ldt_LocatorCode = '{4}'", CommonFunctions.BarcodeRRNo
                                                                        , CommonFunctions.BarcodeRRSeq
                                                                        , CommonFunctions.BarcodeRRLotSeq
                                                                        , CommonFunctions.BarcodeRRLocSeq
                                                                        , CommonFunctions.LocatorCode));

            if (dt.Rows.Count > 0)
            {
                CommonFunctions.InputLayerNo = (int)dt.Rows[0]["LayerNo"];
                CommonFunctions.InputLayerSeqNo = (int)dt.Rows[0]["LayerSeqNo"];
            }
            else
            {
                CommonFunctions.InputLayerNo = 0;
                CommonFunctions.InputLayerSeqNo = 0;
            }
            dt.Dispose();
        }

        public static void ServerActualProcessCoilDefragging(int LayerNo, int LayerSeqNo)
        {
            try
            {
                //ENTRY
                if (string.IsNullOrEmpty(CommonFunctions.CEGetQuantity("CoilDefragging")))
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO {0} (Locatorcode, LayerNo, LayerSeqNo, RRNo, RRSeqNo, LotSeqNo, LocSeqNo, Quantity, RRStatus, SentFlag, ScanFlag)
                            VALUES('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','Q', 0, 1)", "CoilDefragging", CommonFunctions.LocatorCode
                                                                                                                , CommonFunctions.LayerNo
                                                                                                                , CommonFunctions.LayerSeqNo
                                                                                                                , CommonFunctions.BarcodeRRNo
                                                                                                                , CommonFunctions.BarcodeRRSeq
                                                                                                                , CommonFunctions.BarcodeRRLotSeq
                                                                                                                , CommonFunctions.BarcodeRRLocSeq
                                                                                                                , CommonFunctions.AvailableQty));
                else
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE {0} SET Quantity = '{1}', Locatorcode = '{2}', LayerNo = '{3}', LayerSeqNo = '{4}', ScanFlag = 1, RRStatus = 'Q'
                                                            WHERE RRNo = '{5}' AND RRSeqNo = '{6}' AND LotSeqNo = '{7}' AND LocSeqNo = '{8}' AND ScanFlag = 0 AND SentFlag = 0", "CoilDefragging"
                                                                                                                                                                               , CommonFunctions.AvailableQty
                                                                                                                                                                               , CommonFunctions.LocatorCode
                                                                                                                                                                               , CommonFunctions.LayerNo
                                                                                                                                                                               , CommonFunctions.LayerSeqNo
                                                                                                                                                                               , CommonFunctions.BarcodeRRNo
                                                                                                                                                                               , CommonFunctions.BarcodeRRSeq
                                                                                                                                                                               , CommonFunctions.BarcodeRRLotSeq
                                                                                                                                                                               , CommonFunctions.BarcodeRRLocSeq));

                //SEND
                CommonFunctions.SendingThread(CommonEnum.Function.CoilDefragging);


                //STORE (BACK-UP)
                if (CommonFunctions.NewLocSeqNo == "E")
                    CommonFunctions.MessageShow("Item Not Found", CommonEnum.NotificationType.Error);
                else
                {
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE CoilDefragging SET Quantity = '{0}', Locatorcode = '{1}', LayerNo = '{2}', LayerSeqNo = '{3}', RRStatus = 'S', SentFlag = 1
                                      WHERE RRNo = '{4}' AND RRSeqNo = '{5}' AND LotSeqNo = '{6}' AND LocSeqNo = '{7}' AND ScanFlag = 1 AND SentFlag = 0"
                                                                            , CommonFunctions.AvailableQty
                                                                            , CommonFunctions.LocatorCode
                                                                            , LayerNo
                                                                            , LayerSeqNo
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq)); //changed to new LocSeqNo
                    string s = CommonFunctions.BarcodeRRNo + "-" + CommonFunctions.BarcodeRRSeq + "-" + CommonFunctions.BarcodeRRLotSeq + "-" + CommonFunctions.BarcodeRRLocSeq
                            + "\r\nTag No : " + CommonFunctions.TagNo
                            + "\r\nLocator Code : " + CommonFunctions.LocatorCode
                            + "\r\nLayer: " + LayerNo + "-" + LayerSeqNo;
                    CommonFunctions.MessageShow(string.Format("{0}\n{1}", CommonMsg.Success.SuccessCoilDefrag, s));
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

        public static void ServerActualProcessCoilDefragging()
        {
            try
            {
                //CommonFunctions.MessageShow("2");
                //ENTRY
                if (string.IsNullOrEmpty(CommonFunctions.CEGetQuantity("Defragging")))
                {
                    //CommonFunctions.MessageShow("2.1");
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO {0} (RRNo, RRSeqNo, LotSeqNo, LocSeqNo, OldLocatorcode, Locatorcode, Quantity, AvailableQty, RRStatus, SentFlag, ScanFlag)
                            VALUES('{1}','{2}', '{3}','{4}','{5}','{6}','{7}','{8}','Q', 0, 1)", "Defragging"
                                                                                               , CommonFunctions.BarcodeRRNo
                                                                                               , CommonFunctions.BarcodeRRSeq
                                                                                               , CommonFunctions.BarcodeRRLotSeq
                                                                                               , CommonFunctions.BarcodeRRLocSeq
                                                                                               , CommonFunctions.OldLocatorCode
                                                                                               , CommonFunctions.LocatorCode
                                                                                               , CommonFunctions.InputQty
                                                                                               , CommonFunctions.AvailableQty));
                }
                else
                {
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE {0} SET AvailableQty = '{1}', Quantity = '{2}', Locatorcode = '{3}', ScanFlag = 1, RRStatus = 'Q'
                                                            WHERE RRNo = '{4}' AND RRSeqNo = '{5}' AND LotSeqNo = '{6}' AND LocSeqNo = '{7}' AND ScanFlag = 0 AND SentFlag = 0", "Defragging"
                                                                                                                                                                               , CommonFunctions.AvailableQty
                                                                                                                                                                               , CommonFunctions.InputQty
                                                                                                                                                                               , CommonFunctions.LocatorCode
                                                                                                                                                                               , CommonFunctions.BarcodeRRNo
                                                                                                                                                                               , CommonFunctions.BarcodeRRSeq
                                                                                                                                                                               , CommonFunctions.BarcodeRRLotSeq
                                                                                                                                                                               , CommonFunctions.BarcodeRRLocSeq));
                }
                //SEND
                CommonFunctions.SendingThread(CommonEnum.Function.StockMovement);
                //STORE (BACK-UP)
                if (CommonFunctions.NewLocSeqNo == "E")
                    CommonFunctions.MessageShow(CommonMsg.Error.ItemnotFound, CommonEnum.NotificationType.Error);
                else
                {
                    //Update or create new
                    if (CommonFunctions.AvailableQty == CommonFunctions.InputQty)
                    {
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE {0} SET LocatorCode = '{1}', Quantity = '{2}', RRStatus = 'S', SentFlag = 1 
                                          WHERE RRNo = '{3}' AND RRSeqNo = '{4}' AND LotSeqNo = '{5}' AND LocSeqNo = '{6}' AND ScanFlag = 1 AND SentFlag = 0", "Defragging"
                                                                                                                                                             , CommonFunctions.LocatorCode
                                                                                                                                                             , CommonFunctions.InputQty
                                                                                                                                                             , CommonFunctions.BarcodeRRNo
                                                                                                                                                             , CommonFunctions.BarcodeRRSeq
                                                                                                                                                             , CommonFunctions.BarcodeRRLotSeq
                                                                                                                                                             , CommonFunctions.BarcodeRRLocSeq)); //changed to new LocSeqNo
                        CommonFunctions.MessageShow(string.Format("{0}\n{1}", CommonMsg.Success.ItemUpdated, CommonFunctions.NewRRInfo(CommonFunctions.LocatorCode, CommonFunctions.InputQty, true))
                                    , CommonEnum.NotificationType.Default);
                    }
                    else
                    {
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO {0} (Locatorcode, RRNo, RRSeqNo, LotSeqNo, LocSeqNo, Quantity, AvailableQty, RRStatus, ScanFlag, SentFlag) 
                                                        VALUES('{1}','{2}','{3}','{4}','{5}', '{6}', '0','S', 1, 1)", "Defragging"
                                                                                                                    , CommonFunctions.LocatorCode
                                                                                                                    , CommonFunctions.BarcodeRRNo
                                                                                                                    , CommonFunctions.BarcodeRRSeq
                                                                                                                    , CommonFunctions.BarcodeRRLotSeq
                                                                                                                    , CommonFunctions.NewLocSeqNo
                                                                                                                    , CommonFunctions.InputQty)); //changed to new LocSeqNo
                        //SET NEXT
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE {0} SET ScanFlag = 0
                                                            WHERE RRNo = '{1}' AND RRSeqNo = '{2}' AND LotSeqNo = '{3}' AND LocSeqNo = '{4}' AND ScanFlag = 1 AND SentFlag = 0", "Defragging"
                                                                                                                                                                               , CommonFunctions.BarcodeRRNo
                                                                                                                                                                               , CommonFunctions.BarcodeRRSeq
                                                                                                                                                                               , CommonFunctions.BarcodeRRLotSeq
                                                                                                                                                                               , CommonFunctions.BarcodeRRLocSeq));

                        CommonFunctions.MessageShow(string.Format("{0}\n{1}", CommonMsg.Success.NewRR, CommonFunctions.NewRRInfo(CommonFunctions.LocatorCode, CommonFunctions.InputQty, true)));
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

    }
}
