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
    public class StockMovementBase
    {
        public static void SendingThreadStockMovement()
        {
            //OLD LOGIC

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

                    using (DataTable dt = CommonFunctions.CEGetData(String.Format(CommonQueryStrings.Mobile.ViewFiltered.StockMovementUnsent
                                                                                                                            ,CommonFunctions.BarcodeRRNo
                                                                                                                            ,CommonFunctions.BarcodeRRSeq
                                                                                                                            ,CommonFunctions.BarcodeRRLotSeq
                                                                                                                            ,CommonFunctions.BarcodeRRLocSeq)))
                    {                        
                        if (dt.Rows.Count > 0)
                        {
                            //sequence
                            foreach (DataRow row in dt.Rows)
                            {
                                CommonFunctions.NewLocSeqNo = CommonFunctions.DataReader(string.Format("EXEC dbo.spHandyStockMovement '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'"
                                                                                                      , row["RRNo"].ToString().Trim()
                                                                                                      , row["RRSeqNo"].ToString().Trim()
                                                                                                      , row["LotSeqNo"].ToString().Trim()
                                                                                                      , row["LocSeqNo"].ToString().Trim()
                                                                                                      , row["Locatorcode"].ToString().Trim()
                                                                                                      , CommonFunctions.GeneratedWarehouse
                                                                                                      , row["Quantity"]
                                                                                                      , CommonFunctions.Username));
                                
                                //For New update
                                //CommonFunctions.NewLocSeqNo = CommonFunctions.DataReader(string.Format("EXEC dbo.spHandyStockMovement '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}'"
                                //                                                                      , row["RRNo"].ToString().Trim() 
                                //                                                                      , row["RRSeqNo"].ToString().Trim() 
                                //                                                                      , row["LotSeqNo"].ToString().Trim()
                                //                                                                      , row["LocSeqNo"].ToString().Trim()
                                //                                                                      , row["Locatorcode"].ToString().Trim() 
                                //                                                                      , "000"
                                //                                                                      , row["Quantity"] 
                                //                                                                      , CommonFunctions.Username 
                                //                                                                      , row["StockCode"].ToString().Trim()
                                //                                                                      , row["OldLocatorCode"].ToString().Trim() 
                                //                                                                      , CommonFunctions.Unit));
                            }
                        }
                        else //if (dt.Rows.Count == 0)
                            CommonFunctions.MessageShow(string.Empty
                                        , CommonMsg.Info.DataUpdated
                                        , CommonEnum.NotificationType.Information
                                        , CommonEnum.MessageButtons.CloseOnly);
                    }
                }
                else
                    CommonFunctions.NewLocSeqNo = "N";
            }
            catch (Exception ex)
            {
                Audio.PlayErrorBeep();
                CommonFunctions.MessageShow(ex.Message, string.Empty, CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
                CommonFunctions.NewLocSeqNo = "N";
            }
        }
        //Cleaning Datatable
        public static DataTable DatatableDelete(DataTable table, string filter)
        {
            DataRow[] rows = table.Select(filter);
            foreach (DataRow row in rows)
            {
                row.Delete();
            }
            table.AcceptChanges();
            return table;
        }

        public static void ServerActualProcessStockMovement()
        {
            //OLD LOGIC

            try
            {
                //ENTRY
                MobiledbStockMovementProcess();   
                //SEND
                CommonFunctions.SendingThread(CommonEnum.Function.StockMovement);
                //STORE (BACK-UP)
                if (CommonFunctions.NewLocSeqNo == "E")
                {
                    Audio.PlayErrorBeep();
                    CommonFunctions.MessageShow(CommonMsg.Error.ItemnotFound
                                , CommonEnum.NotificationType.Error);
                }
                else if (CommonFunctions.NewLocSeqNo == "N")
                {
                    //11-07-2012
                    //Nilo Added to exit if Send Thread Exception was encountered or disconnected
                    return;
                }
                else
                {
                    //Update or create new
                    if (CommonFunctions.AvailableQty == CommonFunctions.InputQty)
                    {
                        CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.StockMovement  , CommonFunctions.BarcodeRRNo
                                                                                                                        , CommonFunctions.BarcodeRRSeq
                                                                                                                        , CommonFunctions.BarcodeRRLotSeq
                                                                                                                        , CommonFunctions.BarcodeRRLocSeq
                                                                                                                        , CommonFunctions.BarcodeQuantity
                                                                                                                        , CommonFunctions.BarcodeStockCode
                                                                                                                        , CommonFunctions.BarcodePrintedDate
                                                                                                                        , CommonFunctions.OldLocatorCode
                                                                                                                        , CommonFunctions.BarcodeLocatorCode
                                                                                                                        , CommonFunctions.AvailableQty
                                                                                                                     , "A", "1", "1"));
                        Audio.PlayOKBeep();
                        CommonFunctions.MessageShow(string.Format("{0}\n{1}", CommonMsg.Success.ItemUpdated, CommonFunctions.NewRRInfo(CommonFunctions.LocatorCode, CommonFunctions.InputQty, true))
                                    , CommonEnum.NotificationType.Default);
                    }
                    else
                    {
                        #region Code not used in MMSteel since there is no splitting
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO {0} (Locatorcode, RRNo, RRSeqNo, LotSeqNo, LocSeqNo, Quantity, AvailableQty, RRStatus, ScanFlag, SentFlag) 
                                                        VALUES('{1}','{2}','{3}','{4}','{5}', '{6}', '0','S', 1, 1)", "StockMovement"
                                                                                                                    , CommonFunctions.LocatorCode
                                                                                                                    , CommonFunctions.BarcodeRRNo
                                                                                                                    , CommonFunctions.BarcodeRRSeq
                                                                                                                    , CommonFunctions.BarcodeRRLotSeq
                                                                                                                    , CommonFunctions.NewLocSeqNo
                                                                                                                    , CommonFunctions.InputQty)); //changed to new LocSeqNo
                        //SET NEXT
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE {0} SET ScanFlag = 0
                                                            WHERE RRNo = '{1}' AND RRSeqNo = '{2}' AND LotSeqNo = '{3}' AND LocSeqNo = '{4}' AND ScanFlag = 1 AND SentFlag = 0", "StockMovement"
                                                                                                                                                                               , CommonFunctions.BarcodeRRNo
                                                                                                                                                                               , CommonFunctions.BarcodeRRSeq
                                                                                                                                                                               , CommonFunctions.BarcodeRRLotSeq
                                                                                                                                                                               , CommonFunctions.BarcodeRRLocSeq));

                        Audio.PlayOKBeep();
                        CommonFunctions.MessageShow(string.Format("{0}\n{1}", CommonMsg.Success.NewRR, CommonFunctions.NewRRInfo(CommonFunctions.LocatorCode, CommonFunctions.InputQty, true)));
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                Audio.PlayErrorBeep();
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

        public static void MobiledbStockMovementProcess()
        {
            if (string.IsNullOrEmpty(CommonFunctions.CEGetQuantity("StockMovement")))
            {
                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Insert.StockMovement, CommonFunctions.BarcodeRRNo
                                                                                                                , CommonFunctions.BarcodeRRSeq
                                                                                                                , CommonFunctions.BarcodeRRLotSeq
                                                                                                                , CommonFunctions.BarcodeRRLocSeq
                                                                                                                , CommonFunctions.InputQty
                                                                                                                , CommonFunctions.BarcodeStockCode
                                                                                                                , CommonFunctions.BarcodePrintedDate
                                                                                                                , CommonFunctions.OldLocatorCode
                                                                                                                , CommonFunctions.LocatorCode
                                                                                                                , CommonFunctions.AvailableQty
                                                                                                                , "A", "1", "0"));
            }
            else
            {
                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.StockMovement, CommonFunctions.BarcodeRRNo
                                                                                                                , CommonFunctions.BarcodeRRSeq
                                                                                                                , CommonFunctions.BarcodeRRLotSeq
                                                                                                                , CommonFunctions.BarcodeRRLocSeq
                                                                                                                , CommonFunctions.InputQty
                                                                                                                , CommonFunctions.BarcodeStockCode
                                                                                                                , CommonFunctions.BarcodePrintedDate
                                                                                                                , CommonFunctions.OldLocatorCode
                                                                                                                , CommonFunctions.LocatorCode
                                                                                                                , CommonFunctions.AvailableQty
                                                                                                                , "A", "1", "0"));
            }
        }

        public static void ServerdbStockMovementProcess(ref bool NoPending)
        {
            try
            {
                using (DataTable dt = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.ViewFiltered.StockMovementUnsentAll, false))
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            bool Success = false;
                            CommonFunctions.DataReader(CommonQueryStrings.StoredProc.StockMovement(
                                                        row["RRNo"].ToString().Trim()
                                                      , row["RRSeqNo"].ToString().Trim()
                                                      , row["LotSeqNo"].ToString().Trim()
                                                      , row["LocSeqNo"].ToString().Trim()
                                                      , row["Locatorcode"].ToString().Trim()
                                                      , row["Quantity"].ToString().Trim()
                                                      , CommonFunctions.Username)
                                                      , false
                                                      , ref Success);
                            if (Success)
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Delete.StockMovementSent
                                                                          , row["RRNo"].ToString()
                                                                          , row["RRSeqNo"].ToString()
                                                                          , row["LotSeqNo"].ToString()
                                                                          , row["LocSeqNo"].ToString())
                                                                          , false
                                                                          , false);

                                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.TaggedListFlag
                                                                  , row["RRNo"].ToString()
                                                                  , row["RRSeqNo"].ToString()
                                                                  , row["LotSeqNo"].ToString()
                                                                  , row["LocSeqNo"].ToString()
                                                                  , "Sent"
                                                                  , "1")
                                                                  , false
                                                                  , false);
                            }
                        }
                    }
                    else
                    {
                        NoPending = true;
                    }
                }
            }
            catch
            {}
        }

        public static bool GetStockMovement()
        {
            bool _return = false;

            if (CommonFunctions.IsConnected())
            {
                //Getting Movement List of stocks
                try { CommonFunctions.StockMovementTable.Dispose(); }
                catch { }
                CommonFunctions.StockMovementTable = CommonFunctions.GetData(string.Format(CommonQueryStrings.StoredProc.spHandyGetStockMovementBatchList, CommonFunctions.TransferNo));

                if (CommonFunctions.StockMovementTable != null)
                {
                    if (CommonFunctions.StockMovementTable.Rows.Count <= 0)
                    {
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Error.d_NoInformation, CommonFunctions.TransferNo), CommonEnum.NotificationType.Warning);
                        _return = false;
                    }
                    else
                    {
                        if (CommonFunctions.WRISTable.Rows[0]["EXT_Remark"].ToString().Trim().Equals("CANCELLED"))
                        {
                            CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_TRANSCANCELLED, CommonFunctions.TransferNo), CommonEnum.NotificationType.Warning);
                            CommonFunctions.StockMovementTable = null;
                            _return = false;
                        }
                        else
                        {
                            _return = true;
                        }
                    }
                }
            }

            return _return;
        }

        public static bool isWarehouseCodeMatch()
        {
            SQLDataHelper dal = new SQLDataHelper();
            DataTable dt = new DataTable();

            try
            {
                dal.OpenDB();
                dt = dal.ExecuteDataTable(string.Format(CommonQueryStrings.Remote.ViewFiltered.StockMovementRRWarehouseMatching
                                                                               ,CommonFunctions.LocatorCode
                                                                               ,CommonFunctions.BarcodeRRNo
                                                                               ,CommonFunctions.BarcodeRRSeq
                                                                               ,CommonFunctions.BarcodeRRLotSeq
                                                                               ,CommonFunctions.BarcodeRRLocSeq));
            }
            catch (Exception e)
            {
                CommonFunctions.MessageShow(CommonMsg.Error.d_UnabletoProcess + "\n" + e.ToString(), CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.Ok);
            }
            finally
            {
                dal.CloseDB();
            }

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString().Equals("1"))
                    return true;
            }
            return false;
        }
    }
}
