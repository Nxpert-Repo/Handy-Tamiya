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

namespace Handy.Lib.MaterialTransferAndIssuance
{
    public class MaterialIssuanceBase
    {
        private DataTable dtDeliveryCheckList;

        private MaterialIssuanceBase()
        {
            dtDeliveryCheckList = new DataTable();
        }

        /// <summary>
        /// Called from CommonFunctions.IdentifyBarcode() when scanned barcoded is WRIS and function is MaterialIssuance.
        /// 1. Checks if WRIS exist in CE MaterialIssuance table
        /// 2. If not exist, retrieves data from remote DB and saves to CE MaterialIssuance table.
        ///    If there are records for reprint, saves records to CE MaterialIssuanceReprint table.
        /// 3. Creates or updates CE ScanStatus table for the WRIS record.
        /// </summary>
        public static void MaterialIssuanceReceivingReportList()
        {
            //Check if Already scanned
            DataTable dt0 = CommonFunctions.CEGetData(string.Format("SELECT * FROM MaterialIssuance WHERE IssuanceNo = '{0}'", CommonFunctions.BarcodeWRISNo));

            if (dt0 != null)  // no exception
            {
                if (dt0.Rows.Count == 0) // no data
                {
                    //set new values
                    using (DataTable dt = CommonFunctions.GetData(string.Format("EXEC spHandyGetMaterialIssuanceRRList '{0}'", CommonFunctions.BarcodeWRISNo)))
                    {
                        if (dt.Rows.Count > 0)
                        {

                            //INSERT
                            foreach (DataRow row in dt.Rows)
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Insert.MaterialIssuanceRRList
                                                                                ,CommonFunctions.BarcodeWRISNo
                                                                                ,row["IssuanceType"].ToString().Trim()
                                                                                ,row["IssuanceDesc"].ToString().Trim()
                                                                                ,row["RRNo"].ToString().Trim()
                                                                                ,row["RRSeqNo"].ToString().Trim()
                                                                                ,row["RRLotSeqNo"].ToString().Trim()
                                                                                ,row["RRLocSeqNo"].ToString().Trim()
                                                                                ,row["StockCode"].ToString().Trim()
                                                                                ,row["StockName"].ToString().Trim()
                                                                                ,row["StockSpecs"].ToString().Trim()
                                                                                ,row["LotCode"].ToString().Trim()
                                                                                ,row["LocatorCode"].ToString().Trim()
                                                                                ,row["Quantity"].ToString().Trim()
                                                                                ,row["Unit"].ToString().Trim()
                                                                                ,row["RRStatus"].ToString().Trim()
                                                                                ,row["Status"].ToString().Trim()
                                                                                ,row["ScanFlag"].ToString().Trim()
                                                                                ,row["SentFlag"].ToString().Trim()));

                                try
                                {
                                    if (Convert.ToBoolean(row["Reprint"]))
                                    {
                                        string Query = string.Format(CommonQueryStrings.Mobile.Insert.MaterialIssuanceReprint
                                                                   , CommonFunctions.BarcodeWRISNo
                                                                   , row["IssuanceScannedDate"].ToString().Trim()
                                                                   , row["RRNo"].ToString().Trim()
                                                                   , row["RRSeqNo"].ToString().Trim()
                                                                   , row["RRLotSeqNo"].ToString().Trim()
                                                                   , row["RRLocSeqNo"].ToString().Trim());
                                        CommonFunctions.CeExecuteNonQuery(Query);
                                    }
                                }
                                catch { }

                            }

                            //Create Log
                            if (CommonFunctions.CEGetData(string.Format(@"SELECT ControlNo FROM ScanStatus WHERE ControlNo = '{0}'", CommonFunctions.BarcodeWRISNo)).Rows.Count > 0)
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE ScanStatus SET ItemCount= {0}, ScannedCount = {1}, SentCount = {2}, CompleteFlag = 0 WHERE ControlNo = '{3}'"
                                                        , dt.Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM MaterialIssuance WHERE IssuanceNo = '{0}' AND ScanFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT SentFlag FROM MaterialIssuance WHERE IssuanceNo = '{0}' AND SentFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count
                                                        , CommonFunctions.BarcodeWRISNo));
                            }
                            else
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO ScanStatus (ControlNo, ItemCount, ScannedCount, SentCount, CompleteFlag, Process)
                                                VALUES('{0}',{1},{2},{3},0,'DR')"
                                                        , CommonFunctions.BarcodeWRISNo
                                                        , dt.Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM MaterialIssuance WHERE IssuanceNo = '{0}' AND ScanFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT SentFlag FROM MaterialIssuance WHERE IssuanceNo = '{0}' AND SentFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count));
                            }

                            dt.Dispose();
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Indicates whether there are RR that need reprinting.  Queries CE DeliveryReportReprint table. 
        /// </summary>
        /// <returns></returns>
        public static bool IsDeliveryReportRRInfoReprint()
        {
            bool ret;

            try
            {//marvie
                string ViewQuery = string.Format(CommonQueryStrings.Mobile.ViewFiltered.ChecklistRRIsReprint
                                                , CommonFunctions.BarcodeRRNo
                                                , CommonFunctions.BarcodeRRSeq
                                                , CommonFunctions.BarcodeRRLotSeq
                                                , CommonFunctions.BarcodeRRLocSeq
                                                , CommonFunctions.BarcodePrintedDate);
                ret = CommonFunctions.CEDataReader(ViewQuery).Trim().Equals("1") ? true : false;

            }
            catch (Exception err)
            {
                CommonFunctions.MessageShow(err.Message, CommonEnum.NotificationType.Error);
                ret = false;
            }

            return ret;
        }
        /// <summary>
        /// 1. Queries CE MaterialIssuance table for the given RRNo, RRSeqNo, RRLotSeqNo, RRLocSeqNo. Get first record (IssuanceNo, ScanFlag)
        /// 2. If ScanFlag is null or empty, display message base on whether MaterialIssuance has data, then return false. 
        ///    If no data message is "Issuance scanning is required."
        ///    If has data, message is "Scanned Item {LotCode} does not belong in the list of scanned Issuance No."
        /// 3. If ScanFlag = 1, show Message "Item has been scanned." and return false. 
        /// 4. If ScanFlag = 0, CE update MaterialIssuance table and return true.
        /// </summary>
        /// <returns></returns>
        public static bool IsDeliveryReportRRInfoUpdated()
        {
            try
            {
                string scanflag = "";
                string DRNo = "";
                DataTable DRInfo = CommonFunctions.CEGetData(string.Format(@"SELECT IssuanceNo ,
                                                                                    ScanFlag 
                                                                               FROM MaterialIssuance
                                                                              WHERE RRNo = '{0}' 
                                                                                AND RRSeqNo = '{1}'
                                                                                AND RRLotSeqNo = '{2}'
                                                                                AND RRLocSeqNo = '{3}'
                                                                                AND IssuanceNo = '{4}'"
                                                             , CommonFunctions.BarcodeRRNo
                                                             , CommonFunctions.BarcodeRRSeq
                                                             , CommonFunctions.BarcodeRRLotSeq
                                                             , CommonFunctions.BarcodeRRLocSeq
                                                             , CommonFunctions.BarcodeWRISNo));//marvie
                                                             //, "ISS23-117728"));
                if (DRInfo != null)
                {
                    if (DRInfo.Rows.Count > 0)
                    {
                        DRNo = DRInfo.Rows[0]["IssuanceNo"].ToString().Trim();
                        scanflag = DRInfo.Rows[0]["ScanFlag"].ToString().Trim();
                    }
                }

                DRInfo = null;

                //Check if item on the list
                if (string.IsNullOrEmpty(scanflag)) //Item is not on the list
                {
                    //Get all list of DR
                    DataTable dtDRList = CommonFunctions.CEGetData(string.Format("SELECT IssuanceNo FROM MaterialIssuance"));

                    if (dtDRList.Rows.Count == 0) //No DR is scanned
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow("", CommonMsg.Warning.ScanIssuance, CommonEnum.NotificationType.Information, CommonEnum.MessageButtons.CloseOnly);
                    }
                    else
                    {
                        //There list of DR but item is not included
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.ScannedItemNotInList, CommonFunctions.LotCode, "Issuance No."), CommonMsg.Warning.ItemMismatch, CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
                    }

                    try
                    {
                        dtDRList = null;
                        dtDRList.Dispose();
                    }
                    catch { }
                    return false;
                }
                else //Item is on the list
                {
                    //Item is already scanned
                    if (scanflag == "1")
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow("", CommonMsg.Info.ItemScanned, CommonEnum.NotificationType.Information, CommonEnum.MessageButtons.CloseOnly);
                        return false;
                    }
                    else
                    {
                        //Update items scanned flag
////                        CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE MaterialIssuance 
////                                                                             SET ScanFlag = 1
////                                                                                ,Quantity = '{4}'
////                                                                                ,PrintedDateTime = '{5}'
////                                                                                ,StockCode = '{6}'
////                                                                           WHERE RRNo = '{0}' 
////                                                                             AND RRSeqNo = '{1}'
////                                                                             AND RRLotSeqNo = '{2}'
////                                                                             AND RRLocSeqNo = '{3}'"
////                                                                               , CommonFunctions.BarcodeRRNo
////                                                                               , CommonFunctions.BarcodeRRSeq
////                                                                               , CommonFunctions.BarcodeRRLotSeq
////                                                                               , CommonFunctions.BarcodeRRLocSeq
////                                                                               , CommonFunctions.BarcodeQuantity
////                                                                               , CommonFunctions.BarcodePrintedDate
////                                                                               , CommonFunctions.BarcodeStockCode));
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE MaterialIssuance 
                                                                             SET ScanFlag = 1
                                                                                ,PrintedDateTime = '{4}'
                                                                                ,StockCode = '{5}'
                                                                           WHERE RRNo = '{0}' 
                                                                             AND RRSeqNo = '{1}'
                                                                             AND RRLotSeqNo = '{2}'
                                                                             AND RRLocSeqNo = '{3}'"
                                                                              , CommonFunctions.BarcodeRRNo
                                                                              , CommonFunctions.BarcodeRRSeq
                                                                              , CommonFunctions.BarcodeRRLotSeq
                                                                              , CommonFunctions.BarcodeRRLocSeq
                                                                              , CommonFunctions.BarcodePrintedDate
                                                                              , CommonFunctions.BarcodeStockCode));
                        IsAllScannedIssuance(DRNo);//Try to update server data
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Audio.PlayErrorBeep();
                CommonFunctions.MessageShow(CommonMsg.Error.ProcessUnable + ex.Message
                            , CommonMsg.Warning.PleaseTryAgain
                            , CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
                return true;
            }
        }


        public static bool IsAllScannedIssuance()
        {
            return IsAllScannedIssuance("");
        }

        /// <summary>
        /// Monitor items until 
        /// </summary>
        /// <param name="WRISNo"></param>
        /// <returns></returns>
        public static bool IsAllScannedIssuance(string WRISNo)
        {
            CommonFunctions.IsComplete = false;
            int CountItemsForPosting = 0;
            int CountItemsPosted = 0;

            //Get if there is a DR for scanned item.
            if (WRISNo == "")
            {
                WRISNo = CommonFunctions.CEDataReader(string.Format(@"SELECT IssuanceNo 
                                                                        FROM MaterialIssuance
                                                                       WHERE RRNo = '{0}' 
                                                                         AND RRSeqNo = '{1}'
                                                                         AND RRLotSeqNo = '{2}'
                                                                         AND RRLocSeqNo = '{3}'"
                                                                  , CommonFunctions.BarcodeRRNo
                                                                  , CommonFunctions.BarcodeRRSeq
                                                                  , CommonFunctions.BarcodeRRLotSeq
                                                                  , CommonFunctions.BarcodeRRLocSeq));
            }
            //Get all the unscanned items from the DR 
            DataTable dt = CommonFunctions.CEGetData(string.Format("SELECT IssuanceNo FROM MaterialIssuance WHERE IssuanceNo = '{0}' AND ScanFlag = 0", WRISNo));

            //Continue if there are unscanned items
            if (dt != null && dt.Rows.Count == 0) //All items are scanned
            {
                //Clear
                dt = new DataTable();

                //Get unsent items
                dt = CommonFunctions.CEGetData(string.Format("SELECT * FROM MaterialIssuance WHERE IssuanceNo = '{0}' AND SentFlag = 0", WRISNo));

                //Set
                if (dt != null)
                {
                    CountItemsForPosting = dt.Rows.Count;
                    if (CountItemsForPosting > 0)
                    {
                        if (CommonFunctions.IsConnected())
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                CommonFunctions.BarcodeRRNo = row["RRNo"].ToString();
                                CommonFunctions.BarcodeRRSeq = row["RRSeqNo"].ToString();
                                CommonFunctions.BarcodeRRLotSeq = row["RRLotSeqNo"].ToString();
                                CommonFunctions.BarcodeRRLocSeq = row["RRLocSeqNo"].ToString();
                                CommonFunctions.BarcodeStockCode = row["StockCode"].ToString();
                                CommonFunctions.BarcodeQuantity = row["Quantity"].ToString();
                                CommonFunctions.BarcodePrintedDate = row["PrintedDateTime"].ToString();
                                CommonFunctions.LocatorCode = row["LocatorCode"].ToString();
                                #region double execution of SP
                                //Posting to server
                                //if (CommonFunctions.ExecuteNonQuery(string.Format(@"EXEC spHandyUpdateMaterialIssuance '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
                                //                                            , CommonFunctions.BarcodeRRNo
                                //                                            , CommonFunctions.BarcodeRRSeq
                                //                                            , CommonFunctions.BarcodeRRLotSeq
                                //                                            , CommonFunctions.BarcodeRRLocSeq
                                //                                            , row["IssuanceNo"].ToString()
                                //                                            , string.IsNullOrEmpty(CommonFunctions.BarcodeQuantity) ? 0 : CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity)
                                //                                            , CommonFunctions.Username)))
                                //{
                                //    CommonFunctions.ScannedLabelForReprinting(false, false, CommonFunctions.LocatorCode, string.Format("DR-H{0}", CommonFunctions.HandyNo));
                                #endregion
                                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.IssuanceCompleteFlagCommit
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq));
                                    ++CountItemsPosted;
                                //}
                            }
                        }
                    }
                }

                if (CountItemsForPosting == CountItemsPosted) //Update only the status if all are posted
                {
                    UpdateIssuanceControlNoCompleteFlag(WRISNo);
                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Delete.IssuanceSentItems, WRISNo));
                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Delete.IssuanceReprintItems, WRISNo));
                }
                else
                {
                    CommonFunctions.MessageShow(CommonMsg.Info.NotAllItemsPosted, CommonEnum.NotificationType.Warning);
                }

            }

            //Update counter
            CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE ScanStatus SET ScannedCount = ScannedCount + 1 WHERE ControlNo = '{0}' AND CompleteFlag = 0", WRISNo));

            //Get Status            
            dt.Dispose();
            dt = CommonFunctions.CEGetData(string.Format("SELECT ControlNo,ItemCount,ScannedCount,CompleteFlag FROM ScanStatus WHERE Process = 'DR' ORDER BY ControlNo"));

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    CommonFunctions.DeliveryListToSting = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        int ItemCount = Convert.ToInt32(dr["ItemCount"]);
                        int ScannedCount = Convert.ToInt32(dr["ScannedCount"]);
                        bool IsComplete = (Convert.ToInt32(dr["CompleteFlag"]) == 1) ? true : false;

                        int Remaining = ItemCount - ScannedCount;
                        CommonFunctions.DeliveryListToSting += dr["ControlNo"].ToString() + " - " + ((Remaining == 0 && IsComplete) ? "Completed" : (Remaining == 0 && !IsComplete) ? string.Format("{0} out of {1} Unsent (Please Re-post)", ScannedCount, ItemCount) : (Remaining.ToString() + ((Remaining > 1) ? " Items Remaining" : " Item Remaining"))) + "\n";
                    }
                }
            }

            //Check for remaining unscanned
            dt.Dispose();

            string[] ScanSentStatus = MaterialIssuanceBase.CheckScannedIfAlreadySent();
            int Unscanned = Convert.ToInt16(string.IsNullOrEmpty(ScanSentStatus[0]) ? "0" : ScanSentStatus[0]);
            bool IsAllSent = ScanSentStatus[1].Equals("0") ? true : false;


            Audio.PlayOKBeep();

            if (Unscanned > 0 && !IsAllSent)
            {
                CommonFunctions.MessageShow(CommonFunctions.DeliveryListToSting, Unscanned.ToString() + ((Unscanned > 1) ? " Items Remaining" : " Item Remaining"), CommonEnum.NotificationType.Default, CommonEnum.MessageButtons.CloseOnly);
                CommonFunctions.IsComplete = false;
            }
            else if (Unscanned == 0 && IsAllSent)
            {
                CommonFunctions.MessageShow(CommonFunctions.DeliveryListToSting, "Completed", CommonEnum.NotificationType.Default, CommonEnum.MessageButtons.CloseOnly);
                CommonFunctions.IsComplete = true;
            }
            else if (Unscanned == 0 && !IsAllSent)
            {
                //Do nothing message is already displayed above upon checking ForPosting and Posted items
            }
            return CommonFunctions.IsComplete;
        }

        public static DataTable GetUnsetIssuance()
        {
            DataTable dtUnsetDR = new DataTable();
            dtUnsetDR = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.ViewFiltered.IssuanceUnsent);
            return dtUnsetDR;
        }

        public static bool IsAllSentIssuance()
        {
            DataTable dt = new DataTable();
            dt = CommonFunctions.CEGetData("SELECT ScanFlag FROM MaterialIssuance WHERE ScanFlag = 0 OR (ScanFlag = 1 AND SentFlag = 0)");
            return (dt.Rows.Count > 0) ? false : true;
        }

        public static string[] CheckScannedIfAlreadySent()
        {
            string[] ScanSentList = new string[2];
            //Variable if all items are scanned
            ScanSentList[0] = CommonFunctions.CEDataReader(CommonQueryStrings.Mobile.ViewFiltered.IssuanceRRUnscannedCount);
            //Variable if there are items unposted
            ScanSentList[1] = CommonFunctions.CEDataReader(CommonQueryStrings.Mobile.ViewFiltered.IssuanceAllUnpostCOunt);
            return ScanSentList;
        }

        /// <summary>
        /// Returns data from CE MaterialIssuance table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMaterialIssuanceList()
        {
            DataTable dt = CommonFunctions.CEGetData("SELECT * FROM MaterialIssuance ORDER BY ScanFlag");

            if (dt != null)
                return dt;
            else
                return null;
        }

        public static DataTable GetMaterialIssuanceListByIssuanceNo(string issuanceNo)
        {
            DataTable dt = CommonFunctions.CEGetData(string.Format("SELECT * FROM MaterialIssuance WHERE IssuanceNo = '{0}' ORDER BY ScanFlag",issuanceNo));

            if (dt != null)
                return dt;
            else
                return null;
        }
        public static DataTable GetDRControlNoList()
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.ViewFiltered.IssuanceControlNolist);
            return dt;
        }

        public static void UpdateIssuanceControlNoCompleteFlag(string WRISNo)
        {
            string Query = string.Format(CommonQueryStrings.Mobile.Update.CheckListCompleteFlagCommit, WRISNo);
            CommonFunctions.CeExecuteNonQuery(Query);
            Query = null;
        }

        public static DataTable GetIssuancecannedList(string WRISNo)
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData(string.Format("SELECT * FROM MaterialIssuance WHERE ScanFlag = 1 and IssuanceNo = '{0}'", WRISNo));
            dt.Columns.Add("SentStatus", typeof(string));

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["SentStatus"] = ((int)dr["SentFlag"] == 1) ? "Sent" : "Pending";
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }
        public static DataTable GetIssuancecannedListByItem(string WRISNo, string LotCode)
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData(string.Format("SELECT * FROM MaterialIssuance WHERE ScanFlag = 1 AND IssuanceNo = '{0}' AND LotCode = '{1}'", WRISNo, LotCode));
            dt.Columns.Add("SentStatus", typeof(string));

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["SentStatus"] = ((int)dr["SentFlag"] == 1) ? "Sent" : "Pending";
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }
        public static DataTable GetDRStatusList()
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData("SELECT ControlNo, ItemCount, ScannedCount, CompleteFlag FROM ScanStatus WHERE Process = 'DR' ORDER BY ControlNo");
            dt.Columns.Add("Status", typeof(string));

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int Remaining = (Convert.ToInt32(dr["ItemCount"]) - Convert.ToInt32(dr["ScannedCount"]));
                    dr["Status"] = ((int)dr["CompleteFlag"] == 1) ?
                        ((Remaining == 0) ? "Completed" : string.Format("{0} out of {1} scanned", dr["ScannedCount"].ToString(), dr["ItemCount"].ToString()))
                        : ((Remaining == 0) ? "Completed" : (Remaining.ToString() + ((Remaining > 1) ? " Items Remaining"
                        : " Item Remaining")));

                    if (Remaining == 0 && !CommonFunctions.CEDataReader(String.Format(CommonQueryStrings.Mobile.ViewFiltered.ChecklistRRUnpostCount, dr["ControlNo"])).Equals("0"))
                        dr["Status"] = string.Format("{0} out of {1} Unsent", dr["ScannedCount"].ToString(), dr["ItemCount"].ToString());
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }

        /// <summary>
        /// Populates CE ScanStatus table with count status using CE MaterialIssuance table.
        /// </summary>
        public static void UpdateWRISScanStatusList()
        {
            DataTable dt = new DataTable();
            dt = CommonFunctions.CEGetData("SELECT DISTINCT IssuanceNo FROM MaterialIssuance");

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    CommonFunctions.CeExecuteNonQuery("DELETE ScanStatus");
                    CommonFunctions.MaterialIssuanceList = CommonFunctions.DataColumnToList(dt, "IssuanceNo");
                    foreach (string IssuanceNo in CommonFunctions.MaterialIssuanceList)
                    {
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO ScanStatus (ControlNo, ItemCount, ScannedCount, SentCount, CompleteFlag, Process)
                                                VALUES('{0}',{1},{2},{3},{4},'MI')"
                                                            , IssuanceNo
                                                            , CommonFunctions.CEGetData(string.Format("SELECT [RRNo] + '-' + [RRSeqNo] + '-' + [RRLotSeqNo] + '-' + [RRLocSeqNo] FROM MaterialIssuance WHERE IssuanceNo = '{0}'", IssuanceNo)).Rows.Count
                                                            , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM MaterialIssuance WHERE IssuanceNo = '{0}' AND ScanFlag = 1", IssuanceNo)).Rows.Count
                                                            , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM MaterialIssuance WHERE IssuanceNo = '{0}' AND SentFlag = 1", IssuanceNo)).Rows.Count
                                                            , (CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM MaterialIssuance WHERE IssuanceNo = '{0}' AND ScanFlag = 0", IssuanceNo)).Rows.Count > 0) ? 0 : 1));
                    }
                }
            }
        }

    }
}
