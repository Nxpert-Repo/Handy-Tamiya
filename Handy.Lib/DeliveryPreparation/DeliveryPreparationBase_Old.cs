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
    public class DeliveryPreparationBaseOld
    {

        public static void DeliveryPreparationReceivingReportList()
        {
            //Check if Already scanned
            DataTable dt0 = CommonFunctions.CEGetData(string.Format("SELECT * FROM DeliveryPreparation WHERE DPNo = '{0}'", CommonFunctions.BarcodeWRISNo));

            if (dt0 != null)
            {
                if (dt0.Rows.Count == 0)
                {
                    //set new values
                    using (DataTable dt = CommonFunctions.GetData(string.Format("EXEC spHandyGetDeliveryPreparationRRList '{0}'", CommonFunctions.BarcodeWRISNo)))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            //INSERT
                            foreach (DataRow row in dt.Rows)
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Insert.DeliveryPreparationRRList
                                                                                                                , row["TagNo"].ToString().Trim()
                                                                                                                , row["RRNo"].ToString().Trim()
                                                                                                                , row["RRSeqNo"].ToString().Trim()
                                                                                                                , row["RRLotSeqNo"].ToString().Trim()
                                                                                                                , row["RRLocSeqNo"].ToString().Trim()
                                                                                                                , row["RRStatus"].ToString().Trim()
                                                                                                                , row["Status"].ToString().Trim()
                                                                                                                , row["LocatorCode"].ToString().Trim()
                                                                                                                , row["LastProcessDesc"].ToString().Trim()
                                                                                                                , row["SentFlag"].ToString().Trim()
                                                                                                                , row["SentFlag"].ToString().Trim()
                                                                                                                , row["Customer"].ToString().Trim()
                                                                                                                , CommonFunctions.BarcodeWRISNo
                                                                                                                , row["Specs"].ToString().Trim()));
                            }

                            //Create Log
                            if (CommonFunctions.CEGetData(string.Format(@"SELECT ControlNo FROM ScanStatus WHERE ControlNo = '{0}'", CommonFunctions.BarcodeWRISNo)).Rows.Count > 0)
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE ScanStatus SET ItemCount= {0}, ScannedCount = {1}, SentCount = {2} WHERE ControlNo = '{3}'"
                                                        , dt.Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryPreparation WHERE DPNo = '{0}' AND ScanFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT SentFlag FROM DeliveryPreparation WHERE DPNo = '{0}' AND SentFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count
                                                        , CommonFunctions.BarcodeWRISNo));
                            }
                            else
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO ScanStatus (ControlNo, ItemCount, ScannedCount, SentCount, CompleteFlag, Process)
                                                VALUES('{0}',{1},{2},{3},0,'DP')"
                                                        , CommonFunctions.BarcodeWRISNo
                                                        , dt.Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryPreparation WHERE DPNo = '{0}' AND ScanFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT SentFlag FROM DeliveryPreparation WHERE DPNo = '{0}' AND SentFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count));
                            }

                            dt.Dispose();
                        }

                    }
                }
            }
        }

        public static bool IsDeliveryPreparationRRSpecsInvalid()
        {
            bool ret = true;
            try
            {
                DataTable RRInfo = CommonFunctions.CEGetData(string.Format(CommonQueryStrings.Mobile.ViewFiltered.DPGetSpecsofRRinfo
                                                                        , CommonFunctions.BarcodeRRNo
                                                                        , CommonFunctions.BarcodeRRSeq
                                                                        , CommonFunctions.BarcodeRRLotSeq
                                                                        , CommonFunctions.BarcodeRRLocSeq));
                if (RRInfo != null && RRInfo.Rows.Count > 0)
                { 
                    string Specs = RRInfo.Rows[0]["Specs"].ToString().Trim().ToUpper();
                    if (Specs == CommonFunctions.BarcodeSpecs)
                    {
                        ret = false;
                    }
                    else if(string.IsNullOrEmpty(CommonFunctions.BarcodeSpecs))
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.BarcodeNoSpecs), CommonMsg.Warning.Reprint, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.CloseOnly);
                        //CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.BarcodeNoSpecs), CommonMsg.Warning.Reprint, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.YesNo);
                        //CommonFunctions.DPItemScanMessage = CommonMsg.Warning.BarcodeNoSpecs;
                       
                       
                        
                    }
                    else
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.DPItemMismatch), CommonMsg.Warning.Reprint, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.CloseOnly);
                        //CommonFunctions.DPItemScanMessage = CommonMsg.Warning.DPItemMismatch;
                    }
                }
            }
            catch { }
            return ret;
        }

        public static bool isDeliveryPreparationRRInfoUpdated()
        {
            bool isScannedlabelvalid = true;

            //isDeliveryPreparationRRInfoUpdated(ref isScannedlabelvalid);


            return isScannedlabelvalid;
        }

        public static bool isDeliveryPreparationRRInfoUpdated(ref string StrScannedLabelCode)
        {
            try
            {
                string scanflag = "";
                string DPNo = "";

                DataTable DPInfo = CommonFunctions.CEGetData(string.Format(CommonQueryStrings.Mobile.ViewFiltered.DPRRNoScannedStatus
                                                                                                            , CommonFunctions.BarcodeRRNo
                                                                                                            , CommonFunctions.BarcodeRRSeq
                                                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                                                            , CommonFunctions.BarcodeRRLocSeq));

                if (DPInfo != null)
                {
                    if (DPInfo.Rows.Count > 0)
                    {
                        DPNo = DPInfo.Rows[0]["DPNo"].ToString().Trim();
                        scanflag = DPInfo.Rows[0]["ScanFlag"].ToString().Trim();
                    }
                }

                DPInfo = null;

                //Check update
                if (string.IsNullOrEmpty(scanflag))
                {
                    DataTable dt = CommonFunctions.CEGetData(string.Format("SELECT 1 FROM DeliveryPreparation"));

                    if (dt.Rows.Count == 0)
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow("", CommonMsg.Warning.ScanDP, CommonEnum.NotificationType.Information, CommonEnum.MessageButtons.CloseOnly);
                    }
                    else
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.ItemNotInList, CommonFunctions.TagNo, "DP No."), CommonMsg.Warning.ItemMismatch, CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
                        StrScannedLabelCode = "ItemMismatch";
                    }

                    dt.Dispose();
                    return false;
                }
                else
                {
                    if (DeliveryPreparationBaseOld.IsDeliveryPreparationRRSpecsInvalid() == true)
                    {
                        StrScannedLabelCode = "InvalidSpecs";
                        return false;
                    }
                    if (scanflag == "1")
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow("", CommonMsg.Info.ItemScanned, CommonEnum.NotificationType.Information, CommonEnum.MessageButtons.CloseOnly);
                        //IsScannedLabelInvalid = false;
                        StrScannedLabelCode = "TagAlreadyScanned";
                        return false;
                    }
                    else
                    {
                            CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.DPRRNoScanFlagCommit, CommonFunctions.BarcodeRRNo
                                                                                     , CommonFunctions.BarcodeRRSeq
                                                                                     , CommonFunctions.BarcodeRRLotSeq
                                                                                     , CommonFunctions.BarcodeRRLocSeq
                                                                                     , CommonFunctions.BarcodeQuantity
                                                                                     , CommonFunctions.BarcodePrintedDate
                                                                                     , CommonFunctions.BarcodeStockCode));

                            IsAllScannedDP(DPNo);
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

        public static bool IsAllScannedDP()
        {
            return IsAllScannedDP("");
        }

        public static bool IsAllScannedDP(string DPNo)
        {
            CommonFunctions.IsComplete = false;
            int CountItemsForPosting = 0;
            int CountItemsPosted = 0;

            //Update WRISNo
            if (DPNo == "")
            {
                DPNo = CommonFunctions.CEDataReader(string.Format(CommonQueryStrings.Mobile.ViewFiltered.DPRRNoScannedStatus
                                                                                    , CommonFunctions.BarcodeRRNo
                                                                                    , CommonFunctions.BarcodeRRSeq
                                                                                    , CommonFunctions.BarcodeRRLotSeq
                                                                                    , CommonFunctions.BarcodeRRLocSeq));
            }

            DataTable dt = CommonFunctions.CEGetData(string.Format("SELECT 1 FROM DeliveryPreparation WHERE DPNo = '{0}' AND ScanFlag = 0", DPNo));

            if (dt.Rows.Count == 0)
            {
                //Clear
                dt.Dispose();

                //Get
                dt = CommonFunctions.CEGetData(string.Format("SELECT * FROM DeliveryPreparation WHERE DPNo = '{0}' AND ScanFlag = 1 AND SentFlag = 0", DPNo));
                CountItemsForPosting = dt.Rows.Count;

                //Set
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (CommonFunctions.IsConnected())
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                CommonFunctions.BarcodeRRNo = row["RRNo"].ToString();
                                CommonFunctions.BarcodeRRSeq = row["RRSeqNo"].ToString();
                                CommonFunctions.BarcodeRRLotSeq = row["LotSeqNo"].ToString();
                                CommonFunctions.BarcodeRRLocSeq = row["LocSeqNo"].ToString();
                                CommonFunctions.BarcodeStockCode = row["StockCode"].ToString();
                                CommonFunctions.BarcodeQuantity = row["Quantity"].ToString();
                                CommonFunctions.BarcodePrintedDate = row["PrintedDateTime"].ToString();
                                CommonFunctions.LocatorCode = row["LocatorCode"].ToString();

                                if (CommonFunctions.ExecuteNonQuery(string.Format(@"EXEC spHandyUpdateDeliveryPreparation '{0}','{1}','{2}','{3}','{4}'"
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq
                                                                            , row["DPNo"].ToString())))
                                {

                                    CommonFunctions.ScannedLabelForReprinting(false, false, CommonFunctions.LocatorCode, string.Format("DP-H{0}", CommonFunctions.HandyNo));
                                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.DPRRNoSentFlagCommit
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq));
                                    ++CountItemsPosted;
                                }
                            }
                        }
                    }
                }

                if (CountItemsForPosting == CountItemsPosted) //Update only the status if all are posted
                {
                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.DPCompleteFlagCommit, DPNo));
                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Delete.DPSentItems, DPNo));
                }
                else
                {
                    CommonFunctions.MessageShow(CommonMsg.Info.NotAllItemsPosted, CommonEnum.NotificationType.Warning);
                }
            }

            CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE ScanStatus SET ScannedCount = ScannedCount + 1 WHERE ControlNo = '{0}' AND CompleteFlag = 0", DPNo));

            //Get Status            
            dt.Dispose();
            dt = CommonFunctions.CEGetData(string.Format("SELECT ControlNo,ItemCount,ScannedCount,CompleteFlag FROM ScanStatus WHERE Process = 'DP' ORDER BY ControlNo"));

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

            //Check for remaining
            dt.Dispose();
            string[] ScanSentStatus = DeliveryChecklistBase.CheckScannedIfAlreadySent();
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

        public static string[] CheckScannedIfAlreadySent()
        {
            string[] ScanSentList = new string[2];
            //Variable if all items are scanned
            ScanSentList[0] = CommonFunctions.CEDataReader(CommonQueryStrings.Mobile.ViewFiltered.DPRRUnscannedCount);
            //Variable if there are items unposted
            ScanSentList[1] = CommonFunctions.CEDataReader(CommonQueryStrings.Mobile.ViewFiltered.DPAlltUnpostCOunt);
            return ScanSentList;
        }

        public static bool IsAllSentDP()
        {
            bool ret = true;
            DataTable dt = new DataTable();
            dt = CommonFunctions.CEGetData("SELECT * FROM DeliveryPreparation WHERE ScanFlag = 0 OR (ScanFlag = 1 AND SentFlag = 0)");
            if (dt != null)
                if (dt.Rows.Count > 0)
                    ret = false;

            dt = null; //releasing
            //return (dt.Rows.Count > 0) ? false : true;
            return ret;
        }

        public static DataTable GetDPList()
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.View.DPList);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    //if (!_IsComplete)
                    //{
                    //    ScanLog.WriteText("Unable to Load DR list");
                    //    MessageShow("Unable to Load DR list", CommonEnum.NotificationType.Error);
                    //}
                    return dt;
                }
            }
            else
                return dt;
        }

        public static DataTable GetDPScannedList()
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData("SELECT * FROM DeliveryPreparation WHERE ScanFlag = 1 ORDER BY TagNo");
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

        public static DataTable GetDPStatusList()
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData("SELECT ControlNo, ItemCount, ScannedCount, CompleteFlag FROM ScanStatus WHERE Process = 'DP' ORDER BY ControlNo");
            dt.Columns.Add("Status", typeof(string));

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int Remaining = (Convert.ToInt32(dr["ItemCount"]) - Convert.ToInt32(dr["ScannedCount"]));
                    dr["Status"] = ((int)dr["CompleteFlag"] == 1) ? ((Remaining == 0) ? "Completed" : string.Format("{0} out of {1} scanned", dr["ScannedCount"].ToString(), dr["ItemCount"].ToString())) : ((Remaining == 0) ? "Completed" : (Remaining.ToString() + ((Remaining > 1) ? " Items Remaining" : " Item Remaining")));

                    if (Remaining == 0 && !CommonFunctions.CEDataReader(String.Format(CommonQueryStrings.Mobile.ViewFiltered.DPRRUnpostCount, dr["ControlNo"])).Equals("0"))
                        dr["Status"] = string.Format("{0} out of {1} Unsent", dr["ScannedCount"].ToString(), dr["ItemCount"].ToString());
                }
                return dt;
            }
            else
            {
                return dt;
            }
        }

        public static DataTable GetUnsetDP()
        {
            DataTable dtUnsetDP = new DataTable();
            dtUnsetDP = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.ViewFiltered.DPUnsent);
            return dtUnsetDP;
        }

        public static DataTable GetDPControlNoList()
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.ViewFiltered.DPControlNolist);
            return dt;
        }

        public static void UpdateDPScannedList(string DPNo)
        {
            DataTable dt = new DataTable();
            dt = CommonFunctions.CEGetData(string.Format("SELECT * FROM DeliveryPreparation WHERE ScanFlag = 0 AND DPNo = '{0}'", DPNo));

            if (dt.Rows.Count > 0)
            {
                CommonFunctions.TagNoScannedList = CommonFunctions.DataColumnToList(dt, "TagNo");
                CommonFunctions.TagNoScannedListToSting = string.Empty;

                foreach (string i in CommonFunctions.TagNoScannedList)
                {
                    CommonFunctions.TagNoScannedListToSting += i + "\n";
                }

                if (DialogResult.OK == CommonFunctions.MessageShow("Do you want to continue?\n" + CommonFunctions.TagNoScannedList.Count.ToString() + ((CommonFunctions.TagNoScannedList.Count > 1) ? " Items Remaining:" : " Item Remaining:") + "\n" + CommonFunctions.TagNoScannedListToSting, "Not all Items are scanned", CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.OkCancel))
                {
                    dt = CommonFunctions.CEGetData(string.Format("SELECT * FROM DeliveryPreparation WHERE DPNo = '{0}' AND ScanFlag = 1 AND SentFlag = 0", DPNo));

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (CommonFunctions.IsConnected())
                            {
                                //Set
                                foreach (DataRow row in dt.Rows)
                                {
                                    CommonFunctions.BarcodeRRNo = row["RRNo"].ToString();
                                    CommonFunctions.BarcodeRRSeq = row["RRSeqNo"].ToString();
                                    CommonFunctions.BarcodeRRLotSeq = row["LotSeqNo"].ToString();
                                    CommonFunctions.BarcodeRRLocSeq = row["LocSeqNo"].ToString();
                                    CommonFunctions.BarcodeStockCode = row["StockCode"].ToString();
                                    CommonFunctions.BarcodeQuantity = row["Quantity"].ToString();
                                    CommonFunctions.BarcodePrintedDate = row["PrintedDateTime"].ToString();
                                    CommonFunctions.LocatorCode = row["LocatorCode"].ToString();

                                    if (CommonFunctions.ExecuteNonQuery(string.Format(@"EXEC spHandyUpdateDeliveryPreparation '{0}','{1}','{2}','{3}','{4}'"
                                                                                , CommonFunctions.BarcodeRRNo
                                                                                , CommonFunctions.BarcodeRRSeq
                                                                                , CommonFunctions.BarcodeRRLotSeq
                                                                                , CommonFunctions.BarcodeRRLocSeq
                                                                                , row["DPNo"].ToString())))
                                    {
                                        CommonFunctions.ScannedLabelForReprinting(false, false, CommonFunctions.LocatorCode, string.Format("DP-H{0}", CommonFunctions.HandyNo));
                                        CommonFunctions.CeExecuteNonQuery(string.Format(@"DELETE DeliveryPreparation 
                                                                            WHERE RRNo = '{0}' 
                                                                            AND RRSeqNo = '{1}' 
                                                                            AND LotSeqNo = '{2}' 
                                                                            AND LocSeqNo = '{3}'"
                                                                                , CommonFunctions.BarcodeRRNo
                                                                                , CommonFunctions.BarcodeRRSeq
                                                                                , CommonFunctions.BarcodeRRLotSeq
                                                                                , CommonFunctions.BarcodeRRLocSeq));
                                    }
                                }
                            }
                        }
                    }

                    //delete remaining                    
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"DELETE DeliveryPreparation WHERE DPNo = '{0}' AND (ScanFlag = 0 OR SentFlag = 1)", DPNo));
                    //
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE ScanStatus SET CompleteFlag = 1 WHERE ControlNo = '{0}'", DPNo));
                    dt.Dispose();
                }
            }
        }

        public static void UpdateDPScanStatusList()
        {
            DataTable dt = new DataTable();
            dt = CommonFunctions.CEGetData("SELECT DISTINCT DPNo FROM DeliveryPreparation");

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    CommonFunctions.CeExecuteNonQuery("DELETE ScanStatus");
                    CommonFunctions.DeliveryPreparationList = CommonFunctions.DataColumnToList(dt, "DPNo");
                    foreach (string DeliveryPreparationNo in CommonFunctions.DeliveryPreparationList)
                    {
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO ScanStatus (ControlNo, ItemCount, ScannedCount, SentCount, CompleteFlag, Process)
                                                VALUES('{0}',{1},{2},{3},{4},'DP')"
                                                            , DeliveryPreparationNo
                                                            , CommonFunctions.CEGetData(string.Format("SELECT TagNo FROM DeliveryPreparation WHERE DPNo = '{0}'", DeliveryPreparationNo)).Rows.Count
                                                            , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryPreparation WHERE DPNo = '{0}' AND ScanFlag = 1", DeliveryPreparationNo)).Rows.Count
                                                            , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryPreparation WHERE DPNo = '{0}' AND SentFlag = 1", DeliveryPreparationNo)).Rows.Count
                                                            , (CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryPreparation WHERE DPNo = '{0}' AND ScanFlag = 0", DeliveryPreparationNo)).Rows.Count > 0) ? 0 : 1));
                    }
                }

                dt = null; //releasing
            }
        }

        public static void CleanDPScannedList()
        {
            DataTable dt = new DataTable();
            dt = CommonFunctions.CEGetData("SELECT DISTINCT DPNo FROM DeliveryPreparation");

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    CommonFunctions.DeliveryPreparationList = CommonFunctions.DataColumnToList(dt, "DPNo");
                    foreach (string DeliveryPreparationNo in CommonFunctions.DeliveryPreparationList)
                    {
                        if (CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryPreparation WHERE DPNo = '{0}' AND (ScanFlag = 0 OR (ScanFlag = 1 AND SentFlag = 0))", DeliveryPreparationNo)).Rows.Count == 0)
                        {
                            CommonFunctions.CeExecuteNonQuery(string.Format("DELETE FROM DeliveryPreparation WHERE DPNo = '{0}'", DeliveryPreparationNo));
                        }
                    }
                }

                dt = null; //releasing
            }

        }

    }
}
