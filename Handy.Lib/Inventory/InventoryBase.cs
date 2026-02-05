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
    public class InventoryBase
    {
        public static bool Reprint = false;
        public static bool IsInventoryProcess = false;
        public class StockDetail
        {
            public String StockCode;
            public String StockType;
            public String Warehouse;
        }

        //Nilo Revised 12/10/2012
        /// <summary>
        /// Post unsent data from Handy Inventory table to remote SQL T_MonthlyInventoryScannedDetail table.
        /// Displays sucess message after sucessfull operation.
//        /// </summary>
//        public static void SendingThreadInventory()
//        {
//            CommonFunctions.SuccessPost = false;
//            CommonFunctions.Progress = 0;
//            try
//            {
//                CommonFunctions.MITTable = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.View.InventoryUnsent);
//                //Checking Null Table
//                if (CommonFunctions.MITTable == null) { return; }
//                CommonFunctions.PostProgress.Value = 0;
//                int Count = CommonFunctions.MITTable.Rows.Count;
//                int rowindex = 0;
//                string BathcInsertQuery = string.Empty;
//                if (Count <= 0)
//                {
//                    CommonFunctions.SuccessPost = true;
//                    return;
//                }
//                Cursor.Current = Cursors.WaitCursor;
//                //Forming Batch Insert Query
//                foreach (DataRow row in CommonFunctions.MITTable.Rows)
//                {
//                    CommonFunctions.PostProgress.Visible = true;
//                    CommonFunctions.PostProgress.Value = Convert.ToInt32((Convert.ToDecimal(rowindex) / CommonFunctions.MITTable.Rows.Count) * 100);

//                    #region Forming Query for Posting
//                    BathcInsertQuery = BathcInsertQuery + String.Format(@"INSERT INTO [dbo].[T_MonthlyInventoryScannedDetail]( [Mis_RR_Number],[Mis_RR_SeqNo],[Mis_RR_LotSeqNo],[Mis_RR_LocSeqNo],[Mis_StockCode],[Mis_PrintDateTime],[Mis_LocatorCode],[Mis_WarehouseBalanceQuantity],[Mis_WarehouseInventoryQuantity],[Mis_Remark],[Mis_Transacted],[Mis_TerminalNumber],[User_login],[Ludatetime],[Mis_PostStatus],[Mis_ValidityType]
//                                                                        ) SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}', '{13}', '{14}', '{15}'"
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["RRNo"]
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["RRSeqNo"]
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["LotSeqNo"]
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["LocSeqNo"]
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["StockCode"]
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["PrintedDateTime"]
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["Locatorcode"]
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["BalanceQuantity"]
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["ActualQuantity"]
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["Remark"]
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["Transcated"].ToString().Trim().ToUpper().Equals("T") ? "1" : "0"
//                                                                                                       , CommonFunctions.HandyNo
//                                                                                                       , CommonFunctions.Username
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["SentDateTime"]
//                                                                                                       , "N"
//                                                                                                       , CommonFunctions.MITTable.Rows[rowindex]["ValidityType"]) + "\n";

//                    #endregion
//                    ++CommonFunctions.Progress;
//                    ++rowindex;
//                }
//                if (CommonFunctions.IsConnected())
//                {
//                    if (CommonFunctions.ExecuteNonQuery(BathcInsertQuery))
//                    {
//                        CommonFunctions.CeExecuteNonQuery(CommonQueryStrings.Mobile.Update.AllUnsentAsPosted);
//                        CommonFunctions.SuccessPost = true;
//                        //Set Device Date Time
//                        CommonFunctions.SetDeviceDateTime(true);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                CommonFunctions.SuccessPost = false;
//                //MessageShow(ex.ToString());
//            }

//            CommonFunctions.PostProgress.Value = 100;
//            CommonFunctions.PostProgress.Visible = false;
//            Cursor.Current = Cursors.Default;
//            if (CommonFunctions.SuccessPost)
//                CommonFunctions.MessageShow(CommonMsg.Success.d_PostingInventorySuccess, CommonEnum.NotificationType.Default);

//        }
        public static void SendingThreadInventory()
        {
            if (CommonFunctions.IsConnected())
            {
                CommonFunctions.SuccessPost = false;
                CommonFunctions.Progress = 0;
                #region Inventory list posting process

                try
                {
                    string[] parameters = new string[17];
                    CommonFunctions.MITTable = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.ViewFiltered.MobileInventoryListForPosting);

                    if (CommonFunctions.MITTable != null)  //Checking Null Table
                    {
                        CommonFunctions.PostProgress.Value = 0;
                        int Count = CommonFunctions.MITTable.Rows.Count;
                        int rowindex = 0;
                        string BathcInsertQuery = string.Empty;

                        if (CommonFunctions.MITTable.Rows.Count > 0)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //Forming Batch Insert Query
                            foreach (DataRow row in CommonFunctions.MITTable.Rows)
                            {
                                CommonFunctions.PostProgress.Visible = true;
                                CommonFunctions.PostProgress.Value = Convert.ToInt32((Convert.ToDecimal(rowindex) / CommonFunctions.MITTable.Rows.Count) * 100);

                                #region Forming Query for Posting
                                BathcInsertQuery = BathcInsertQuery + String.Format(@"INSERT INTO [dbo].[T_MonthlyInventoryScannedDetail]( [Mis_RR_Number],[Mis_RR_SeqNo],[Mis_RR_LotSeqNo],[Mis_RR_LocSeqNo],[Mis_StockCode],[Mis_PrintDateTime],[Mis_LocatorCode],[Mis_WarehouseBalanceQuantity],[Mis_WarehouseInventoryQuantity],[Mis_Remark],[Mis_Transacted],[Mis_TerminalNumber],[User_login],[Ludatetime],[Mis_PostStatus],[Mis_ValidityType]
                                                                        ) SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}', '{13}', '{14}', '{15}'"
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_RRNo"]
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_RRSeqNo"]
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_LotSeqNo"]
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_LocSeqNo"]
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_StockCode"]
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_BarcodePrintedDate"]
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_LocatorCode"]
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_BalanceQty"]
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_InputQty"]
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_Remark"].ToString()
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_UpdateTransDate"].ToString().Trim().ToUpper().Equals("T") ? "1" : "0"
                                                                                                                   , CommonFunctions.HandyNo
                                                                                                                   , CommonFunctions.Username
                                    //ulysses added : {13} 11/21/13
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_SentDateTime"]
                                                                                                                   , "N"
                                                                                                                   , CommonFunctions.MITTable.Rows[rowindex]["Inv_ValidityType"]) + "\n";

                                #endregion
                                ++CommonFunctions.Progress;
                                ++rowindex;

                            }
                            //Logger.WriteTextData(Logger.HandyMITPathFile, Logger.HandyMITFile, parameters, true, true, '1');
                            if (CommonFunctions.ExecuteNonQuery(BathcInsertQuery))
                            {
                                string CEQuery = String.Format(@"UPDATE T_Inventory
                                                                SET Inv_SentDateTime='{0}' ,
                                                                    Inv_SentFlag='1'
                                                              WHERE Inv_SentFlag='0'"
                                                             , CommonFunctions.DataReader("SELECT GETDATE()"));

                                CommonFunctions.CeExecuteNonQuery(CEQuery);
                                CommonFunctions.SuccessPost = true;
                            }

                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonFunctions.SuccessPost = false;

                }

                #endregion

                CommonFunctions.PostProgress.Value = 100;
                CommonFunctions.PostProgress.Visible = false;
                Cursor.Current = Cursors.Default;

                if (CommonFunctions.SuccessPost)
                {
                    CommonFunctions.MessageShow(CommonMsg.Success.d_PostingInventorySuccess
                                              , CommonEnum.NotificationType.Success);
                }
            }
        }

        /// <summary>
        /// Processes posting of inventory count data.
        /// </summary>
        public static void ServerActualProcessInventory()
        {
            CommonFunctions.SendingThread(CommonEnum.Function.Inventory);
        }
        /// <summary>
        /// Counts the records according to SentFlag.
        /// Return Interger Array COUNTS
        /// Array[0] = Pending
        /// Array[1] = Sent
        /// Array[2] = Redo
        /// </summary>
        /// <returns></returns>
        public static int[] ListCount(CommonEnum.Function Function)
        {
            //Cursor.Current = Cursors.WaitCursor;

            int[] counts = new int[3];
            counts[0] = 0; //Pending 
            counts[1] = 0; //Sent
            counts[2] = 0; //Redo
            try
            {
                switch (Function)
                {
                    #region TODO
                    //case CommonEnum.Function.Tagging:
                    //    SendingThreadTagging();
                    //    break;
                    //case CommonEnum.Function.StockMovement:
                    //    SendingThreadStockMovement();
                    //    break;
                    //case CommonEnum.Function.MaterialAdjustment:
                    //    SendingThreadMaterialAdjustment();
                    //    break;
                    //case CommonEnum.Function.Issuance:
                    //    SendingThreadIssuance();
                    //    break;
                    #endregion
                    case CommonEnum.Function.Inventory:
                        {
                            DataTable dt = new DataTable();
                            dt = CommonFunctions.CEGetData(@"SELECT SentFlag [FLAG]
                                                                  , Count(RRNo) [COUNT]
                                                            FROM Inventory
                                                            GROUP BY SentFlag");
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["FLAG"].ToString().Trim().Equals("0"))
                                    counts[0] = Convert.ToInt16(dr["COUNT"]);
                                else if (dr["FLAG"].ToString().Trim().Equals("1"))
                                    counts[1] = Convert.ToInt16(dr["COUNT"]);
                                else if (dr["FLAG"].ToString().Trim().Equals("2"))
                                    counts[2] = Convert.ToInt16(dr["COUNT"]);
                                else
                                {
                                    //Do nothing 
                                }
                            }
                            dt = null; // releasing
                            //Cursor.Current = Cursors.Default;
                            #region old code for text file
                            //dt = Logger.GetTextDataTable(Logger.HandyPath, Logger.HandyMITFile, 3, false, '~'); //Third Column RR as Primary Key
                            //if (dt == null)
                            //{
                            //    Cursor.Current = Cursors.Default;
                            //    return counts;
                            //}
                            //int i = 0;
                            //if (dt.Rows.Count > 0)
                            //{
                            //    foreach (DataRow row in dt.Rows)
                            //    {
                            //        if (Convert.ToInt16(row["COLUMN_1"]) == 0)
                            //        {
                            //            ++counts[0]; //Pending
                            //            ParseRRNoDisplay(row["COLUMN_3"].ToString());
                            //            AddDisposablePendingTable();
                            //            //_BarcodeRRNo = string.Empty;
                            //            //_BarcodeRRSeq = string.Empty;
                            //            //_BarcodeRRLotSeq = string.Empty;
                            //            //_BarcodeRRLotSeq = string.Empty;
                            //        }
                            //        else if (Convert.ToInt16(row["COLUMN_1"]) == 1)
                            //            ++counts[1]; //Sent
                            //        else if (Convert.ToInt16(row["COLUMN_1"]) == 2)
                            //            ++counts[2]; //Redo
                            //    }
                            //}
                            #endregion
                            break;
                        }
                }
            }
            catch { }
            //Cursor.Current = Cursors.Default;
            return counts;

        }
        //20130405 Allen Transfer: Transferred MITMobileDBList from CommonFunctions
        public static DataTable MobileInventoryDisplayList(CommonEnum.UploadStats UploadStatus)
        {
            string filter = ""; //All by default

            switch (UploadStatus)
            {
                case CommonEnum.UploadStats.Failed: //failed
                    {
                        filter = "WHERE Inv_ValidityType IN ('02','03')"; //ALLEN ADDED '03'
                    }
                    break;
                case CommonEnum.UploadStats.AllValid:
                    {
                        filter = "WHERE Inv_ValidityType IN ('00', '01','02','04','03') AND Inv_StockName <> ''"; //ALLEN ADDED '02' & '03'//20230807 -marvie - commented change stockname to stockcode
                        //filter = "WHERE Inv_ValidityType IN ('00', '01','02','04','03') AND Inv_StockCode <> ''"; //20230807 - marvie added change stockname to stockcode
                    }
                    break;
                case CommonEnum.UploadStats.Pending:
                    {
                        filter = "WHERE Inv_SentFlag = '0' AND Inv_ValidityType IN ('00', '01', '02', '03', '04') AND Inv_StockName <> ''"; //ALLEN ADDED '02' & '03' //20230807 -marvie - commented change stockname to stockcode
                        //filter = "WHERE Inv_SentFlag = '0' AND Inv_ValidityType IN ('00', '01', '02', '03', '04') AND Inv_StockCode <> ''";//20230807 - marvie added change stockname to stockcode
                    }
                    break;
                case CommonEnum.UploadStats.Reprint:
                    {
                        filter = "WHERE Inv_ValidityType = '01'";
                    }
                    break;
                case CommonEnum.UploadStats.Sent:
                    {
                        filter = "WHERE Inv_SentFlag = '1' AND Inv_ValidityType IN ('00', '01', '02', '03', '04') AND Inv_StockName <> ''"; //ALLEN ADDED '02' & '03' //20230807 -marvie - commented change stockname to stockcode
                        //filter = "WHERE Inv_SentFlag = '1' AND Inv_ValidityType IN ('00', '01', '02', '03', '04') AND Inv_StockCode <> ''"; //20230807 - marvie added change stockname to stockcode
                    }
                    break;
            }
            DataTable Dt = new DataTable();
            try
            {
                string CEQuery = String.Format(CommonQueryStrings.Mobile.ViewFiltered.MobileInventoryList, filter);
                Dt = CommonFunctions.CEGetData(CEQuery);
            }
            catch
            {
                Dt = null;
            }
            return Dt;
        }

        //20130405 Allen Transfer: Transferred MITMobileBDTransact from CommonFunctions
        public static bool MobileInventoryAddUpdateData(String AddQuery, String UpdateQuery)
        {
            bool ret = true;
            try
            {
                int AffectedRow = CommonFunctions.CeExecuteNonQuery(UpdateQuery);
                if (AffectedRow != -1 && AffectedRow < 1)
                {
                    CommonFunctions.CeExecuteNonQuery(AddQuery);
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public static bool IsInventoryRRinfoGenerated()
        {
            bool _return = false;

            CommonFunctions.ValidityType = string.Empty;
            try
            {
                #region First Checking from Downloaded Inventory Table
                if (CommonFunctions.InventoryMaster != null)
           
                {
                   
                        #region --old code
                        //ulysses added 11/21/13
                        //Set Device Date Time
                        //CommonFunctions.SetDeviceDateTime(true);

                        //GetRecevingReportStockCodeList();
                        #endregion
                      
                    //Prioritize Local MIT
                    DataRow[] drLocalInventory;
                    drLocalInventory = CommonFunctions.InventoryMaster.Select(String.Format("RRNo = '{0}' AND RRSeqNo = '{1}' AND LotSeqNo = '{2}' AND LocSeqNo = '{3}'"
                                                                                            , CommonFunctions.BarcodeRRNo
                                                                                            , CommonFunctions.BarcodeRRSeq
                                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                                            , CommonFunctions.BarcodeRRLocSeq));
                    Cursor.Current = Cursors.Default;
                    decimal barcodeQty = CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity);
                    DateTime barcodeDatePrint = Convert.ToDateTime(CommonFunctions.BarcodePrintedDate);
                    if (drLocalInventory != null)
                    {
                        if (drLocalInventory.Length > 0)
                        {
                            foreach (DataRow dr in drLocalInventory)
                            {
                                CommonFunctions.StockName = CommonFunctions.GetStockName(dr["StockCode"].ToString().Trim());//dr["StockName"].ToString().Trim();
                                CommonFunctions.Specs = CommonFunctions.GetStockSpecs(dr["StockCode"].ToString().Trim());
                                //CommonFunctions.AvailableQty = CommonFunctions.ConvertStringDecimal(dr["Available"].ToString().Trim());
                                CommonFunctions.AvailableQty = CommonFunctions.ConvertStringDecimal(dr["WarehouseBalanceQty"].ToString().Trim());
                                //CommonFunctions.RRLastUpdate = Convert.ToDateTime(dr["LastUpdate"].ToString().Trim());
                            }
                            if (barcodeQty == CommonFunctions.AvailableQty)
                            {
                                CommonFunctions.Remark = CommonMsg.Info.InventoryOkay;
                                CommonFunctions.ValidityType = CommonEnum.GetStringValue(CommonEnum.ValidityType.Success);
                            }
                            else if (barcodeQty != CommonFunctions.AvailableQty)
                            {
                                string msg = string.Format(CommonMsg.Warning.d_Reprint, string.Format("{0:0.00}", CommonFunctions.AvailableQty));
                                CommonFunctions.MessageShow(msg, "Reprint", CommonEnum.NotificationType.Warning);
                                CommonFunctions.Remark = CommonMsg.Info.InventoryReprintLabel;
                                CommonFunctions.ValidityType = CommonEnum.GetStringValue(CommonEnum.ValidityType.Reprint);
                            }
                          
                            drLocalInventory = null; //releasing
                            _return = true;
                        }
                      
                        else
                        {
                            ReVerifyScannedItemBarcode();
                            _return = true;
                        }
                    }
                    else
                    {
                        //Null row
                        CommonFunctions.AvailableQty = barcodeQty;
                        CommonFunctions.MessageShow(CommonMsg.Error.InventoryNotRetrieve, "Warning", CommonEnum.NotificationType.Error);
                        CommonFunctions.Remark = CommonMsg.Info.InventoryUnretrieved;
                        CommonFunctions.ValidityType = CommonEnum.GetStringValue(CommonEnum.ValidityType.Deleted);
                        _return = true;
                    }
                }
                else if (CommonFunctions.InventoryMaster == null)
                {
                    //Downloading is needed message
                    Cursor.Current = Cursors.Default;
                    CommonFunctions.MessageShow(CommonMsg.Error.InventoryListDownloadingRequired, "Warning", CommonEnum.NotificationType.Error);
                    _return = false;


                }
                #endregion
                Cursor.Current = Cursors.Default;
            }
            catch (NotSupportedException err)
            {
                Cursor.Current = Cursors.Default;
                CommonFunctions.MessageShow(CommonMsg.Error.ProcessUnable + err.Message, CommonEnum.NotificationType.Error);
                _return = false;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CommonFunctions.MessageShow(CommonMsg.Error.ProcessUnable + ex.Message, CommonEnum.NotificationType.Error);
                _return = false;
            }

            return _return;
        }

        public static string GetWarehouseString()
        {
            string strType = "";
            try
            {
                if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.StorageWarehouse)
                {
                    strType = "Storage Warehouse";
                }
                else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.ProductionMiniWarehouse)
                {
                    strType = "Producion Mini-WH";
                }
                else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.HRMiniWarehouse)
                {
                    strType = "HR Mini-Warehosue";
                }
                else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.GAMiniWarehouse)
                {
                    strType = "GA Mini-Warehouse";
                }
                else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.CentralWarehouse)
                {
                    strType = "Central Warehouse";
                }
                else if (CommonFunctions.GeneratedWarehouse == CommonEnum.Warehouse.CentralProcessing)
                {
                    strType = "Central Processing";
                }
                return strType;
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
                return strType;
            }
        }
        public static void AddDisposablePendingList()
        {
            if (CommonFunctions.DisposableTable.Select(string.Format("RRNoDisplay = '{0}'", CommonFunctions.RRNoDisplay)).Length == 0)
            {
                //Declaring New Row
                DataRow DtRow = CommonFunctions.DisposableTable.NewRow();
                DtRow["RRNoDisplay"] = CommonFunctions.RRNoDisplay;
                CommonFunctions.DisposableTable.Rows.Add(DtRow);
                CommonFunctions.DisposableTable.AcceptChanges();
            }
        }

        public static bool MobiledbInventoryProcess(String AddQuery, String UpdateQuery)
        {
            bool ret = true;
            try
            {

                #region Commented code
                //                string exist = CommonFunctions.CEDataReader(string.Format(@"SELECT top(1) RRNo 
//                                                                            FROM Inventory 
//                                                                                WHERE RRNo='{0}'
//		                                                                        AND RRSeqNo='{1}'
//		                                                                        AND LotSeqNo='{2}'
//		                                                                        AND LocSeqNo='{3}'"
//                                                                          , CommonFunctions.BarcodeRRNo
//                                                                          , CommonFunctions.BarcodeRRSeq
//                                                                          , CommonFunctions.BarcodeRRLotSeq
//                                                                          , CommonFunctions.BarcodeRRLocSeq));
//                if (string.IsNullOrEmpty(exist))
//                {
//                    CommonFunctions.CeExecuteNonQuery(AddQuery);
//                }
//                else
//                {
//                    CommonFunctions.CeExecuteNonQuery(UpdateQuery);
                //                }
                #endregion

                if (CommonFunctions.CeExecuteNonQuery(UpdateQuery, false) == 0)
                {
                    CommonFunctions.CeExecuteNonQuery(AddQuery, false);
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// Retrieves data from Handy Inventory table. All = true retrieves all records, otherwise loads top 20 only.
        /// </summary>
        /// <param name="All"></param>
        /// <returns></returns>
        public static DataTable MobiledbInventoryList(bool All)
        {
            DataTable Dt = new DataTable();
            try
            {
                Dt = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.View.InventoryList(All));
            }
            catch
            {
                Dt = null;
            }
            return Dt;
        }

        public static bool MobiledbClearInvetory(String Query)
        {
            bool ret = true;
            try
            {
                CommonFunctions.CeExecuteNonQuery(Query);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        /// <summary>
        /// Returns true if user cancels in confirmation dialog. 
        /// Retrieves data from T_MonthlyInventoryHandyStaging into data table variable InventoryMaster. 
        /// Returns false if error during data retrieval operation.
        /// Returns true if success whether there are data or not.
        /// Set flag InventoryReferenceGenerated to true if there is data, false otherwise.
        /// Retrieves user info and sets date of generation.
        /// </summary>
        /// <returns></returns>
        public static bool MobiledbGenerateInventoryReferenceList()
        {
            bool ret = false;
            if (DialogResult.Yes != CommonFunctions.MessageShow(CommonMsg.Info.InventoryGenerationInfo, CommonEnum.NotificationType.Question, CommonEnum.MessageButtons.YesNo))
                return true;
            try
            {
                try { CommonFunctions.GenericMasterList.Dispose(); } catch { }
                try { CommonFunctions.StockClassDescList.Dispose(); } catch { }

                Cursor.Current = Cursors.WaitCursor;
                if (CommonFunctions.IsConnected())
                {
                    CommonFunctions.InventoryReferenceGenerated = false;
                    //Set Device Date Time
                    CommonFunctions.SetDeviceDateTime(true);
                    CommonFunctions.InventoryMaster = null;
                   // CommonFunctions.InventoryMaster = CommonFunctions.GetData(invQuery,true);
                    CommonFunctions.InventoryMaster =  CommonFunctions.GetData(string.Format(@"EXEC spHandyGetInventoryTable"),true);
                       
                    if (CommonFunctions.InventoryMaster == null)
                        ret = false;
                    else
                    {
                        #region debug code
                        //Initialize searching to downloaded referece list
                        //DataRow[] drLocalInventory;
                        //drLocalInventory = CommonFunctions.InventoryMaster.Select(String.Format("RRNo = '{0}' AND RRSeqNo = '{1}' AND LotSeqNo = '{2}' AND LocSeqNo = '{3}'"
                        //                                                                        , "R13-00000001"    //Test data
                        //                                                                        , "000"             //Test data
                        //                                                                        , "000"             //Test data
                        //                                                                        , "999"));          //Test data
                        //if (drLocalInventory != null)
                        //{
                        //    try
                        //    {
                        //        drLocalInventory = null;
                        //    }
                        //    catch { }
                        //}
                        //End
                        #endregion
                        // get user info from T_UserMaster
                        DataTable DtGenerationInfo = CommonFunctions.GetData((CommonQueryStrings.Remote.ViewFiltered.InventoryGeneratedby(CommonFunctions.Username)));
                        if (DtGenerationInfo != null)
                        {
                            if (DtGenerationInfo.Rows.Count > 0)
                            {
                                CommonFunctions.GeneratedDate = DtGenerationInfo.Rows[0]["GeneratedDate"].ToString().Trim();
                                CommonFunctions.GeneratedBy = DtGenerationInfo.Rows[0]["FirstName"].ToString().Trim() + " " + DtGenerationInfo.Rows[0]["LastName"].ToString().Trim();
                            }
                        }
                        DtGenerationInfo = null; //releasing
                        CommonFunctions.GeneratedRowCnt = CommonFunctions.InventoryMaster.Rows.Count;
                        if (CommonFunctions.GeneratedRowCnt > 0)
                            CommonFunctions.InventoryReferenceGenerated = true;  // flag for valid inventory generation
                        ret = true;
                        Cursor.Current = Cursors.Default;
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(CommonMsg.Success.d_GenerateInventoryMaster, CommonEnum.NotificationType.Success);
                    }
                }

            }
            catch { ret = false; }
            Cursor.Current = Cursors.Default;
            return ret;
        }


        public static bool MobiledbGenerateInventoryReferenceList(string WarehouseCode)//CommonEnum.Warehouse WarehouseCode)
        {
            return MobiledbGenerateInventoryReferenceList(WarehouseCode, "");
        }
        public static bool MobiledbGenerateInventoryReferenceList(string WarehouseCode, String StoredProcedure) //CommonEnum.Warehouse WarehouseCode, String StoredProcedure)
        {
            bool ret = false;

            try
            {
                try { CommonFunctions.GenericMasterList.Dispose(); }
                catch { }
                try { CommonFunctions.StockClassDescList.Dispose(); }
                catch { }
                Cursor.Current = Cursors.WaitCursor;

                if (CommonFunctions.IsConnected())
                {
                    #region --old code
                    //ulysses added 11/21/13
                    //Set Device Date Time
                    //CommonFunctions.SetDeviceDateTime(true);

                    //GetRecevingReportStockCodeList();
                    #endregion
                    CommonFunctions.InventoryMaster = null;

                    ///*** 
                    /// Added by: RJ (2019-06-20)
                    /// Description: breakdown of data to be downloaded to fix out of memory error in KEYENCE Handy
                    /// **//
                    #region --raw query for getting total number of rows to be downloaded
                    string query = string.Format(@"SELECT COUNT(Mih_RRNo) [rowcount]
						                        FROM .[dbo].[T_MonthlyInventoryHandyStaging]
					                        LEFT JOIN T_ReceivingReportDetail
						                           ON Mih_RRNo = Rrd_RRNo
						                          AND Mih_RRSeqNo = Rrd_RRSeqNo
						                          AND Mih_RRotSeqNo = Rrd_LotSeqNo
						                          AND Mih_RRLocSeqNo = Rrd_RRlocseqno WHERE Rrd_LocaQuantity - Rrd_IssuedQTY > 0 AND Rrd_WarehouseCode = '{0}'", WarehouseCode);
                    DataTable dtx = CommonFunctions.GetData(query, true);
                    #endregion

                    #region --variables
                    var rowcount = Convert.ToInt16(dtx.Rows[0]["rowcount"]);
                    var rowlimit = 2000;
                    var numberOfLoops = rowcount / rowlimit;
                    int start = 1;
                    int end = 0;
                    string queryx = "";
                    string device = "BT";
                    int errorcounter = 0;

                    SQLDataHelper DB = new SQLDataHelper();
                    DataTable sourceDT = new DataTable();
                    DataTable cloneDT = new DataTable();
                    #endregion
                    #region --main codes

                    if (numberOfLoops < 1)
                    {
                        numberOfLoops = 1;
                    }
                    else
                    {
                        numberOfLoops = numberOfLoops + 1;
                    }

                    for (int x = 1; x <= numberOfLoops; x++)
                    {
                        
                        if (x > 1)
                        {
                            end = (end + rowlimit);
                        }
                        else
                        {
                            end = rowlimit;
                        }
                       
                            queryx = string.Format("EXEC [spHandyGetInventoryTable] '{0}','{1}','{2}','{3}'", start, end, WarehouseCode, device);
                            
                    EXEC:
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            if (CommonFunctions.IsConnected())
                            {
                                sourceDT = DB.ExecuteDataTable(queryx);
                            }
                            
                            if (sourceDT.Rows.Count > 0)
                            {
                                errorcounter = 0;
                                if (cloneDT.Columns.Count <= 0)
                                {
                                    cloneDT = sourceDT.Clone();
                                }

                               
                                cloneDT.Merge(sourceDT);
                                #region Comment--importing rows to table
                                //foreach (DataRow item in sourceDT.Rows)
                                //{
                                   
                                //    DataRow newRow = cloneDT.NewRow();
                                //    newRow = item;
                                //    cloneDT.ImportRow(item);
                                //}
                                #endregion
                            }
                        }
                        catch (SqlException ex)
                        {
                            ++errorcounter;
                            if (errorcounter < 5)
                            {
                                goto EXEC; //Retry executing sp for exception
                            }
                            else
                            {
                               
                                CommonFunctions.MessageShow("Connection Time-Out!!", CommonEnum.NotificationType.Error);
                                
                                cloneDT.Clear();
                                sourceDT.Clear();
                                cloneDT = null;
                                sourceDT = null;
                                ret = false;
                                break;
                                
                                
                            }
                        }
                        catch (Exception ex)
                        {
                            CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
                        }
                        finally
                        {
                            DB.CloseDB();
                        }
                        start = end + 1;

                    }
                   
                    #endregion

                    CommonFunctions.InventoryMaster = cloneDT.Clone();
                    CommonFunctions.InventoryMaster = cloneDT;
                    //CommonFunctions.InventoryMaster = CommonFunctions.GetData(string.Format("EXEC [spHandyGetInventoryTable] '{0}','{1}','{2}','{3}'", start, end, WarehouseCode, device));

                    //foreach (DataRow row in cloneDT)
                    //{
                    //    string InsertQuery = string.Format(CommonQueryStrings.Mobile.Insert.InventoryMaster
                    //                                         , row["StockType"]
                    //                                         , row["StockCodeInitial"]
                    //                                         , row["Count"]);
                    //    CommonFunctions.CeExecuteNonQuery(InsertQuery);
                    //}

                    if (CommonFunctions.InventoryMaster == null)
                        ret = false;
                    else
                    {
                        //Initialize searching to downloaded referece list
                        DataRow[] drLocalInventory;
                        #region --comment
      
                        #endregion
                        try
                        {
                            drLocalInventory = null;
                        }
                        catch { }
                        DataTable DtGenerationInfo = CommonFunctions.GetData(CommonQueryStrings.Remote.ViewFiltered.InventoryGeneratedby(CommonFunctions.Username));
                        if (DtGenerationInfo != null)
                        {
                            if (DtGenerationInfo.Rows.Count > 0)
                            {
                                
                                CommonFunctions.GeneratedDate = DtGenerationInfo.Rows[0]["GeneratedDate"].ToString().Trim();
                                CommonFunctions.GeneratedBy = DtGenerationInfo.Rows[0]["FirstName"].ToString().Trim() + " " + DtGenerationInfo.Rows[0]["LastName"].ToString().Trim();
                            }
                        }
                        DtGenerationInfo = null; 
                        CommonFunctions.GeneratedRowCnt = CommonFunctions.InventoryMaster.Rows.Count;
                        ret = true;
                        Cursor.Current = Cursors.Default;
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(CommonMsg.Success.d_GenerateInventoryMaster, CommonEnum.NotificationType.Success);
                    }
                }

            }
            
            catch (Exception ex)
            {
                ret = false;
            }
           
            Cursor.Current = Cursors.Default;
            return ret;
        }

        public static DataTable GetLatestTagNoRecursive()
        {
            DataTable RecursiveRRTabe = new DataTable();
            String RRNo = CommonFunctions.BarcodeRRNo;
            String RRSeq = CommonFunctions.BarcodeRRSeq;
            String RRLot = CommonFunctions.BarcodeRRLotSeq;
            String RRLoc = CommonFunctions.BarcodeRRLocSeq;
            CommonFunctions.LabelHistoryMaster = CommonFunctions.GetData(String.Format("EXEC dbo.[spHandyGetReceivingReportRecursiveTag] '{0}','{1}','{2}','{3}'", RRNo, RRSeq, RRLot, RRLoc));
            if (CommonFunctions.LabelHistoryMaster != null)
            {
                int i = 0;
                int count = 0;
                count = CommonFunctions.LabelHistoryMaster.Rows.Count;

                while (i < count)
                {
                    if (CommonFunctions.LabelHistoryMaster != null)
                    {
                        count = CommonFunctions.LabelHistoryMaster.Rows.Count;
                        if (count == 0)
                            break;
                    }

                    if (CommonFunctions.LabelHistoryMaster.Rows.Count > 1)
                    {
                        return CommonFunctions.LabelHistoryMaster;
                    }

                    String NewType = CommonFunctions.LabelHistoryMaster.Rows[i]["NewType"].ToString().Trim().ToUpper();
                    String OldType = CommonFunctions.LabelHistoryMaster.Rows[i]["OldType"].ToString().Trim().ToUpper();
                    if ((NewType.StartsWith("RM") && NewType.Equals(OldType))
                        || (NewType.StartsWith("FG") && OldType.Equals("FG")))
                    {
                        RecursiveRRTabe = CommonFunctions.LabelHistoryMaster;
                        CommonFunctions.ParsestrRRNoDisplay(CommonFunctions.LabelHistoryMaster.Rows[i]["NewRR"].ToString().Trim());
                        CommonFunctions.LabelHistoryMaster = CommonFunctions.GetData(String.Format("EXEC dbo.[spHandyGetReceivingReportRecursiveTag] '{0}','{1}','{2}','{3}'"
                                                                                                                                                        , CommonFunctions.strRRNo
                                                                                                                                                        , CommonFunctions.strRRSeqNo
                                                                                                                                                        , CommonFunctions.strRRLotSeq
                                                                                                                                                        , CommonFunctions.strRRLocSeq));
                        i = 0;
                    }
                    else
                    {
                        ++i;
                        break;
                    }
                }
            }
            return RecursiveRRTabe;
        }

        public static bool ReVerifyScannedItemBarcode()
        {
            bool _return = false;
            try
            {
                DataTable dtlocalMachineryList = new DataTable();
                Int32 Counts = 0;
                string BarcodeStockCode = CommonFunctions.BarcodeStockCode;
                StockDetail StockDetailResult = GetBarcodeStockDetail(BarcodeStockCode);



                if (StockDetailResult.StockCode == BarcodeStockCode)
                {
                    if (StockDetailResult.Warehouse != CommonEnum.GetStringValue(CommonFunctions.GeneratedWarehouse))
                    {

                        CommonFunctions.MessageShow(string.Format(CommonMsg.Info.ScannedWarehouseItem, CommonFunctions.GeneratedWarehouse), "Mismatch", CommonEnum.NotificationType.Information);
                        CommonFunctions.ValidityType = CommonEnum.GetStringValue(CommonEnum.ValidityType.Mismatch);
                        //ulysses modified to display the correct remarks (reference type) for mismatched scanned item. 11/21/13
                        //CommonFunctions.Remark = string.Format(CommonMsg.Info.InventoryNonExist, CommonEnum.GetStringValue(CommonEnum.StockType.Steel));
                        CommonFunctions.Remark = string.Format(CommonMsg.Info.InventoryNonExist, CommonEnum.GetStringValue(CommonFunctions.GeneratedStockType));
                        return _return;


                    }
                    else //issued
                    {
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Error.ItemalreadyIssued), "Issued", CommonEnum.NotificationType.Error);
                        CommonFunctions.ValidityType = CommonEnum.GetStringValue(CommonEnum.ValidityType.Issued);
                        CommonFunctions.Remark = CommonMsg.Info.InventoryIssued;
                        return _return;
                    }


                }
                else
                {
                    CommonFunctions.MessageShow(CommonMsg.Error.InventoryNotRetrieve, "Warning", CommonEnum.NotificationType.Error);
                    CommonFunctions.Remark = CommonMsg.Info.InventoryUnretrieved;
                    CommonFunctions.ValidityType = CommonEnum.GetStringValue(CommonEnum.ValidityType.Deleted);
                    return _return;
                }
                }
            
            catch (Exception ex)
            {
                _return = false;
            }

            return _return;
        }

        public static void ClearSelectedFromMachinery()
        {
            try
            {
                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.T_UpdateStockCodeInitial));
            }
            catch (Exception Err)
            {
                CommonFunctions.MessageShow(Err.Message, CommonEnum.NotificationType.Error);
            }
        }

        public static StockDetail GetBarcodeStockDetail(String StockCodeFirstFiveInitials)
        {
            StockDetail _StockDetail = new StockDetail();

          
                foreach (DataRow row in dtReceivingReportStockCodeList.Rows)
                {
                    if (row["StockCode"].ToString().Equals(StockCodeFirstFiveInitials, StringComparison.OrdinalIgnoreCase))
                    {
                        _StockDetail.StockType = row["Stocktype"].ToString();
                        _StockDetail.StockCode = row["StockCode"].ToString();
                        _StockDetail.Warehouse = row["warehouse"].ToString();
                        break;
                    }
                }
            
            return _StockDetail;
        }


        private static DataTable dtReceivingReportStockCodeList = new DataTable();

        public static void GetRecevingReportStockCodeList()
        {
            dtReceivingReportStockCodeList = CommonFunctions.GetData(CommonQueryStrings.Remote.ViewFiltered.ReceivingReportStockCodeList(CommonFunctions.GeneratedWarehouse));
            //DataTable dtRRMachineryStockCodeList = new DataTable();
            //dtRRMachineryStockCodeList = CommonFunctions.GetData(CommonQueryStrings.Remote.ViewFiltered.ReceivingReportStockCodeList(CommonEnum.StockType.Machinery));
            //dtReceivingReportStockCodeList.Merge(dtRRMachineryStockCodeList);
      
            dtReceivingReportStockCodeList.AcceptChanges();
        }

        public static string FormatFinalStoredProcedure()
        {
            string StoreProcedure = string.Empty;
            DataTable dtAddGeneratedList = new DataTable();

            dtAddGeneratedList = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.View.T_StockCodeInitialAdd);

            string itemchecked = String.Empty;

            int i = 0;

            foreach (DataRow Row in dtAddGeneratedList.Rows)
            {
                itemchecked += string.Format("OR Mih_StockCode like ''{0}%'' ", Row["Sci_StockInitial"].ToString());

                if (i == 0)
                {
                    itemchecked = itemchecked.Replace("OR", "");
                }
                ++i;
            }
            itemchecked = string.Format("AND (" + itemchecked + ")");

            StoreProcedure = CommonQueryStrings.StoredProc.spHandyGetInventoryTable(CommonEnum.Warehouse.StorageWarehouse, "" + itemchecked + "");

            return StoreProcedure;

        }

        public static bool InsertStockCodeInitial(DataTable DtStockCodeInitial)
        {
            bool _return = false;
            try
            {
                if (DtStockCodeInitial == null)
                    _return = false;

                Int32 Counts = 0;

                Counts = DtStockCodeInitial.Rows.Count;
                if (Counts > 0)
                {

                    foreach (DataRow row in DtStockCodeInitial.Rows)
                    {
                        string InsertQuery = string.Format(CommonQueryStrings.Mobile.Insert.T_StockCodeInitial
                                                               , row["StockType"]
                                                               , row["StockCodeInitial"]
                                                               , row["Count"]);
                        CommonFunctions.CeExecuteNonQuery(InsertQuery);
                    }
                    _return = true;
                }

            }
            catch (Exception ex)
            {
                _return = false;
            }
            return _return;

        }

        public static DataTable dtMachineryList = new DataTable();

        //public static void SaveToLocal(DataTable table)
        //{
        //    CESQLDataHelper dal = new CESQLDataHelper();
        //    try
        //    {
        //        dal.OpenDB();
        //        foreach(DataRow row in table.Rows)
        //        {
        //            dal.ExecuteNonQuery(string.Format());
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        CommonFunctions.MessageShow(CommonMsg.Error.d_UnabletoProcess, CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.Ok);
        //    }
        //    finally
        //    {

        //    }
        //}
    
    }
}
