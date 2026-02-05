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
    public class DeliveryChecklistBase
    {
        #region UlimateDeliveryChecklist
        private DataTable dtDeliveryCheckList;

        private DeliveryChecklistBase()
        {
            dtDeliveryCheckList = new DataTable();
        }

        public static void DeliveryReportReceivingReportList()
        {
            //Check if Already scanned
            DataTable dt0 = CommonFunctions.CEGetData(string.Format("SELECT * FROM DeliveryReport WHERE DRNo = '{0}'", CommonFunctions.BarcodeWRISNo));

            if (dt0 != null)
            {
                if (dt0.Rows.Count == 0)
                {
                    //set new values
                    using (DataTable dt = CommonFunctions.GetData(string.Format("EXEC spHandyGetDeliveryReportRRList '{0}'", CommonFunctions.BarcodeWRISNo)))
                    {
                        if (dt.Rows.Count > 0)
                        {

                            //INSERT
                            foreach (DataRow row in dt.Rows)
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Insert.DeliveryReportRRList
                                                                                , row["TagNo"].ToString().Trim()
                                                                                , row["RRNo"].ToString().Trim()
                                                                                , row["RRSeqNo"].ToString().Trim()
                                                                                , row["RRLotSeqNo"].ToString().Trim()
                                                                                , row["RRLocSeqNo"].ToString().Trim()
                                                                                , row["RRStatus"].ToString().Trim()
                                                                                , row["Status"].ToString().Trim()
                                                                                , row["LocatorCode"].ToString().Trim()
                                                                                , row["SentFlag"].ToString().Trim()
                                                                                , row["SentFlag"].ToString().Trim()
                                                                                , row["Customer"].ToString().Trim()
                                                                                , CommonFunctions.BarcodeWRISNo
                                                                                , row["Specs"].ToString().Trim()));
                                try 
                                {
                                    if (Convert.ToBoolean(row["Reprint"]))
                                    {
                                        string Query = string.Format(CommonQueryStrings.Mobile.Insert.DeliveryCheckListReprint
                                                                   , CommonFunctions.BarcodeWRISNo
                                                                   , row["DRScannedDate"].ToString().Trim()
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
                                                        , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryReport WHERE DRNo = '{0}' AND ScanFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT SentFlag FROM DeliveryReport WHERE DRNo = '{0}' AND SentFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count
                                                        , CommonFunctions.BarcodeWRISNo));
                            }
                            else
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO ScanStatus (ControlNo, ItemCount, ScannedCount, SentCount, CompleteFlag, Process)
                                                VALUES('{0}',{1},{2},{3},0,'DR')"
                                                        , CommonFunctions.BarcodeWRISNo
                                                        , dt.Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryReport WHERE DRNo = '{0}' AND ScanFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count
                                                        , CommonFunctions.CEGetData(string.Format("SELECT SentFlag FROM DeliveryReport WHERE DRNo = '{0}' AND SentFlag = 1", CommonFunctions.BarcodeWRISNo)).Rows.Count));
                            }

                            dt.Dispose();
                        }

                    }
                }
            }
        }

        public static bool IsDeliveryReportRRInfoReprint()
        {
            bool ret;

            try
            { 
                string ViewQuery = string.Format( CommonQueryStrings.Mobile.ViewFiltered.ChecklistRRIsReprint
                                                , CommonFunctions.BarcodeRRNo
                                                , CommonFunctions.BarcodeRRSeq
                                                , CommonFunctions.BarcodeRRLotSeq
                                                , CommonFunctions.BarcodeRRLocSeq
                                                , CommonFunctions.BarcodePrintedDate );
                ret = CommonFunctions.CEDataReader(ViewQuery).Trim().Equals("1") ? true : false;

            }
            catch(Exception err)
            {
                CommonFunctions.MessageShow(err.Message, CommonEnum.NotificationType.Error);
                ret = false;
            }

            return ret;
        }

        public static bool IsDeliveryReportRRInfoUpdated()
        {
            try
            {
                //Local Delivery Checklist data validation

                //Check if item from the list is already scanned
                string scanflag = "";
                string DRNo = "";
                DataTable DRInfo = CommonFunctions.CEGetData(string.Format(@"SELECT DRNo ,
                                                                                    ScanFlag 
                                                                               FROM DeliveryReport
                                                                              WHERE RRNo = '{0}' 
                                                                                AND RRSeqNo = '{1}'
                                                                                AND LotSeqNo = '{2}'
                                                                                AND LocSeqNo = '{3}'"
                                                             , CommonFunctions.BarcodeRRNo
                                                             , CommonFunctions.BarcodeRRSeq
                                                             , CommonFunctions.BarcodeRRLotSeq
                                                             , CommonFunctions.BarcodeRRLocSeq));
                if (DRInfo != null)
                {
                    if (DRInfo.Rows.Count > 0)
                    {
                        DRNo = DRInfo.Rows[0]["DRNo"].ToString().Trim();
                        scanflag = DRInfo.Rows[0]["ScanFlag"].ToString().Trim();
                    }
                }

                DRInfo = null;

                //Check if item on the list
                if (string.IsNullOrEmpty(scanflag)) //Item is not on the list
                {
                    //Get all list of DR
                    DataTable dtDRList = CommonFunctions.CEGetData(string.Format("SELECT DRNo FROM DeliveryReport"));

                    if (dtDRList.Rows.Count == 0) //No DR is scanned
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow("", CommonMsg.Warning.ScanDR, CommonEnum.NotificationType.Information, CommonEnum.MessageButtons.CloseOnly);
                    }
                    else
                    {
                        //There list of DR but item is not included
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.ItemNotInList, CommonFunctions.TagNo, "DR No."), CommonMsg.Warning.ItemMismatch, CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
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
                    if (DeliveryChecklistBase.IsDeliveryReportRRSpecsInvalid() == true)
                    {
                        return false;
                    }
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
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE DeliveryReport 
                                                          SET ScanFlag = 1,
                                                              Quantity = '{4}',
                                                              PrintedDateTime = '{5}',
                                                              StockCode = '{6}'
                                                          WHERE RRNo = '{0}' 
                                                            AND RRSeqNo = '{1}'
                                                            AND LotSeqNo = '{2}'
                                                            AND LocSeqNo = '{3}'", CommonFunctions.BarcodeRRNo
                                                                                 , CommonFunctions.BarcodeRRSeq
                                                                                 , CommonFunctions.BarcodeRRLotSeq
                                                                                 , CommonFunctions.BarcodeRRLocSeq
                                                                                 , CommonFunctions.BarcodeQuantity
                                                                                 , CommonFunctions.BarcodePrintedDate
                                                                                 , CommonFunctions.BarcodeStockCode));
                        IsAllScannedDR(DRNo);//Try to update server data
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

        public static bool IsDeliveryReportRRSpecsInvalid()
        {
            bool ret = true;
            try
            {
                DataTable RRInfo = CommonFunctions.CEGetData(string.Format(CommonQueryStrings.Mobile.ViewFiltered.DRGetSpecsofRRinfo, CommonFunctions.BarcodeRRNo, CommonFunctions.BarcodeRRSeq, CommonFunctions.BarcodeRRLotSeq, CommonFunctions.BarcodeRRLocSeq));
                if (RRInfo != null && RRInfo.Rows.Count > 0)
                {
                    string Specs = RRInfo.Rows[0]["Specs"].ToString().Trim().ToUpper();
                    if (Specs == CommonFunctions.BarcodeSpecs)
                    {
                        ret = false;
                    }
                    else if (string.IsNullOrEmpty(CommonFunctions.BarcodeSpecs))
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.BarcodeNoSpecs), CommonMsg.Warning.Reprint, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.CloseOnly);

                    }
                    else
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.DPItemMismatch), CommonMsg.Warning.Reprint, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.CloseOnly);

                    }
                }
            }
            catch { }
            return ret;
        }

        public static bool IsAllScannedDR()
        {
            return IsAllScannedDR("");
        }

        public static bool IsAllScannedDR(string DRNo)
        {
            CommonFunctions.IsComplete = false;
            int CountItemsForPosting = 0;
            int CountItemsPosted = 0;

            //Get if there is a DR for scanned item.
            if (DRNo == "")
            {
                DRNo = CommonFunctions.CEDataReader(string.Format(@"SELECT DRNo 
                                                                      FROM DeliveryReport
                                                                     WHERE RRNo = '{0}' 
                                                                       AND RRSeqNo = '{1}'
                                                                       AND LotSeqNo = '{2}'
                                                                       AND LocSeqNo = '{3}'"
                                                                  , CommonFunctions.BarcodeRRNo
                                                                  , CommonFunctions.BarcodeRRSeq
                                                                  , CommonFunctions.BarcodeRRLotSeq
                                                                  , CommonFunctions.BarcodeRRLocSeq));
            }
            //Get all the unscanned items from the DR 
            DataTable dt = CommonFunctions.CEGetData(string.Format("SELECT DRNo FROM DeliveryReport WHERE DRNo = '{0}' AND ScanFlag = 0", DRNo));

            //Continue if there are unscanned items
            if (dt.Rows.Count == 0) //All items are scanned
            {
                //Clear
                dt = new DataTable();

                //Get
                dt = CommonFunctions.CEGetData(string.Format("SELECT * FROM DeliveryReport WHERE DRNo = '{0}' AND SentFlag = 0", DRNo));
                CountItemsForPosting = dt.Rows.Count;

                //Set
                if (dt != null)
                {
                    if (CountItemsForPosting > 0)
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

                                //Posting to server
                                if (CommonFunctions.ExecuteNonQuery(string.Format(@"EXEC spHandyUpdateDeliveryReport '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
                                                                            , CommonFunctions.BarcodeRRNo
                                                                            , CommonFunctions.BarcodeRRSeq
                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                            , CommonFunctions.BarcodeRRLocSeq
                                                                            , row["DRNo"].ToString()
                                                                            , string.IsNullOrEmpty(CommonFunctions.BarcodeQuantity) ? 0 : CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity)
                                                                            , CommonFunctions.Username)))
                                                                            
                                {
                                    CommonFunctions.ScannedLabelForReprinting(false, false, CommonFunctions.LocatorCode, string.Format("DR-H{0}", CommonFunctions.HandyNo));
                                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.CheckListRRSentFlagCommit
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
                    UpdateDRControlNoCompleteFlag(DRNo);
                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Delete.ChecklistSentItems, DRNo));
                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Delete.ChecklistReprintItems, DRNo));
                }
                else
                {
                    CommonFunctions.MessageShow(CommonMsg.Info.NotAllItemsPosted, CommonEnum.NotificationType.Warning);
                }

            }

            CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE ScanStatus SET ScannedCount = ScannedCount + 1 WHERE ControlNo = '{0}' AND CompleteFlag = 0", DRNo));

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

        public static DataTable GetUnsetDR()
        { 
            DataTable dtUnsetDR = new DataTable();
            dtUnsetDR = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.ViewFiltered.ChecklistUnsent);
            return dtUnsetDR;
        }

        public static bool IsAllSentDR()
        {
            DataTable dt = new DataTable();
            dt = CommonFunctions.CEGetData("SELECT ScanFlag FROM DeliveryReport WHERE ScanFlag = 0 OR (ScanFlag = 1 AND SentFlag = 0)");
            return (dt.Rows.Count > 0) ? false : true;
        }

        public static string[] CheckScannedIfAlreadySent()
        {
            string[] ScanSentList = new string[2];
            //Variable if all items are scanned
            ScanSentList[0] = CommonFunctions.CEDataReader(CommonQueryStrings.Mobile.ViewFiltered.ChecklistRRUnscannedCount);
            //Variable if there are items unposted
            ScanSentList[1] = CommonFunctions.CEDataReader(CommonQueryStrings.Mobile.ViewFiltered.ChecklisAlltUnpostCOunt);
            return ScanSentList;
        }

        public static DataTable GetDRList()
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData("SELECT TagNo, ScanFlag, SentFlag, DRNo, Customer FROM DeliveryReport ORDER BY ScanFlag,TagNo");

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
                return null;
        }

        public static DataTable GetDRControlNoList()
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.ViewFiltered.ChecklistControlNolist);
            return dt;
        }

        public static void UpdateDRControlNoCompleteFlag(string DRNo)
        {
            string Query = string.Format(CommonQueryStrings.Mobile.Update.CheckListCompleteFlagCommit, DRNo);
            CommonFunctions.CeExecuteNonQuery(Query);
            Query = null;
        }

        public static DataTable GetDRScannedList()
        {
            //Get List
            DataTable dt = CommonFunctions.CEGetData("SELECT * FROM DeliveryReport ORDER BY TagNo");
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

        public static void UpdateDRScannedList(string DRNo)
        {
            DataTable dt = new DataTable();
            dt = CommonFunctions.CEGetData(string.Format("SELECT * FROM DeliveryReport WHERE ScanFlag = 0 AND DRNo = '{0}'", DRNo));

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
                    dt = CommonFunctions.CEGetData(string.Format("SELECT * FROM DeliveryReport WHERE DRNo = '{0}' AND ScanFlag = 1 AND SentFlag = 0", DRNo));

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

                                    if (CommonFunctions.ExecuteNonQuery(string.Format(@"EXEC spHandyUpdateDeliveryReport '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
                                                                                , CommonFunctions.BarcodeRRNo
                                                                                , CommonFunctions.BarcodeRRSeq
                                                                                , CommonFunctions.BarcodeRRLotSeq
                                                                                , CommonFunctions.BarcodeRRLocSeq
                                                                                , row["DRNo"].ToString()
                                                                                , string.IsNullOrEmpty(CommonFunctions.BarcodeQuantity) ? 0 : CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity)
                                                                                , CommonFunctions.Username)))
                                    {
                                        CommonFunctions.ScannedLabelForReprinting(false, false, CommonFunctions.LocatorCode, string.Format("DR-H{0}", CommonFunctions.HandyNo));
                                        CommonFunctions.CeExecuteNonQuery(string.Format(@"DELETE DeliveryReport
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
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"DELETE DeliveryReport WHERE DRNo = '{0}' AND (ScanFlag = 0 OR SentFlag = 1)", DRNo));
                    //delete reprint 
                    CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Delete.ChecklistReprintItems, DRNo));
                    //
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE ScanStatus SET CompleteFlag = 1 WHERE ControlNo = '{0}'", DRNo));

                    dt.Dispose();
                }
            }
        }

        public static void UpdateDRScanStatusList()
        {
            DataTable dt = new DataTable();
            dt = CommonFunctions.CEGetData("SELECT DISTINCT DRNo FROM DeliveryReport");

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    CommonFunctions.CeExecuteNonQuery("DELETE ScanStatus");
                    CommonFunctions.DeliveryReporttList = CommonFunctions.DataColumnToList(dt, "DRNo");
                    foreach (string DeliveryReportNo in CommonFunctions.DeliveryReporttList)
                    {
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO ScanStatus (ControlNo, ItemCount, ScannedCount, SentCount, CompleteFlag, Process)
                                                VALUES('{0}',{1},{2},{3},{4},'DR')"
                                                            , DeliveryReportNo
                                                            , CommonFunctions.CEGetData(string.Format("SELECT TagNo FROM DeliveryReport WHERE DRNo = '{0}'", DeliveryReportNo)).Rows.Count
                                                            , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryReport WHERE DRNo = '{0}' AND ScanFlag = 1", DeliveryReportNo)).Rows.Count
                                                            , CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryReport WHERE DRNo = '{0}' AND SentFlag = 1", DeliveryReportNo)).Rows.Count
                                                            , (CommonFunctions.CEGetData(string.Format("SELECT ScanFlag FROM DeliveryReport WHERE DRNo = '{0}' AND ScanFlag = 0", DeliveryReportNo)).Rows.Count > 0) ? 0 : 1));
                    }
                }
            }
        }

        public static void CleanDRScannedList()
        {
            DataTable dt = new DataTable();
            dt = CommonFunctions.CEGetData("SELECT DISTINCT DRNo FROM DeliveryReport");

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    CommonFunctions.DeliveryReporttList = CommonFunctions.DataColumnToList(dt, "DRNo");
                    foreach (string DeliveryReportNo in CommonFunctions.DeliveryReporttList)
                    {

                        if (CommonFunctions.CEGetData(string.Format("SELECT TagNo FROM DeliveryReport WHERE DRNo = '{0}' AND (ScanFlag = 0 OR (ScanFlag = 1 AND SentFlag = 0))", DeliveryReportNo)).Rows.Count == 0)
                        {
                            CommonFunctions.CeExecuteNonQuery(string.Format("DELETE FROM DeliveryReport WHERE DRNo = '{0}'", DeliveryReportNo));
                        }
                    }
                }
                dt = null; //releasing
            }

        }

        #endregion
    }
}
