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
    //Nilo Added 20130130 : Locator Tagging Base Functions
    public class LocatorTaggingBase
    {
        public static void SendingThreadTagging()
        {
            //OLD LOGIC
            try
            {
                if(CommonFunctions.IsConnected())
                {
                    /***** Nilo Commented 20130627 : Transferred to getreceivingreportinfo checking only for issued items *****/
                    //if (CommonFunctions.IsBarcodeOutDated())
                    //{
                    //    CommonFunctions.NewLocSeqNo = "N";
                    //    return;
                    //}

                    using (DataTable dt = CommonFunctions.CEGetData(String.Format(CommonQueryStrings.Mobile.ViewFiltered.LocatorTagingUnsent
                                                                                                                        ,CommonFunctions.BarcodeRRNo
                                                                                                                        ,CommonFunctions.BarcodeRRSeq
                                                                                                                        ,CommonFunctions.BarcodeRRLotSeq
                                                                                                                        ,CommonFunctions.BarcodeRRLocSeq)))
                    {
                        int ctr = dt.Rows.Count;
                        if (ctr > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                CommonFunctions.NewLocSeqNo = CommonFunctions.DataReader("EXEC dbo.spHandyLocatorTagging '" + row["RRNo"].ToString() + "', '" + row["RRSeqNo"].ToString() + "', '" + row["LotSeqNo"].ToString() + "', '" + row["LocSeqNo"].ToString() + "', '" + row["Locatorcode"] + "', '" + row["Quantity"] + "', '" + CommonFunctions.Username + "'");
                            }
                        }
                        if (ctr == 0)
                        {
                            CommonFunctions.MessageShow(string.Empty
                                        , CommonMsg.Info.DataUpdated
                                        , CommonEnum.NotificationType.Information
                                        , CommonEnum.MessageButtons.CloseOnly);
                        }

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

        public static void TextfileLocatorTagging(TextParameterInfo[] TextParamInfo)
        {
            bool Append = Logger.isFileExist(Logger.HandyPath, Logger.HandyTaggingFile);
            if (Logger.WriteTextData(Logger.HandyPath, Logger.HandyTaggingFile, TextParamInfo, true, Append, '~'))
            {
                //MessageShow(CommonMsg.Success.d_LocalSave + string.Format(CommonMsg.Info.d_RRCommonInfo, RRNoDisplay, _BarcodeStockCode, _InputQty), CommonEnum.NotificationType.Sucess);
            }
            else
            {
                //MessageShow(CommonMsg.Error.d_Unsave + string.Format(CommonMsg.Info.d_RRCommonInfo, RRNoDisplay, _BarcodeStockCode, _InputQty), CommonEnum.NotificationType.Warning);
            }
        }

        public static void ServerActualProcessLocatorTagging()
        {
            //OLD LOGIC
            try
            {
                //ENTRY
                MobiledbLocatorTaggingProcess();
                //SEND
                CommonFunctions.SendingThread(CommonEnum.Function.LocatorTagging);

                //STORE (BACK-UP)
                if (CommonFunctions.NewLocSeqNo == "T")
                {
                    Audio.PlayOKBeep();
                    CommonFunctions.MessageShow(CommonMsg.Success.ItemTagged
                                , CommonEnum.NotificationType.Information);
                }
                else
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
                        //if (CommonFunctions.BarcodeRRLocSeq == "999")
                        //{
                            CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.TaggingSent
                                                                          , "Tagging"
                                                                          , CommonFunctions.LocatorCode
                                                                          , CommonFunctions.InputQty
                                                                          , CommonFunctions.BarcodeRRNo
                                                                          , CommonFunctions.BarcodeRRSeq
                                                                          , CommonFunctions.BarcodeRRLotSeq
                                                                          , CommonFunctions.BarcodeRRLocSeq)); //changed to new LocSeqNo
                            Audio.PlayOKBeep();
                            CommonFunctions.MessageShow(string.Format("{0}\n{1}", CommonMsg.Success.ItemTagged, CommonFunctions.NewRRInfo(CommonFunctions.LocatorCode, CommonFunctions.InputQty, false))
                                        , CommonEnum.NotificationType.Default);
                        //}
                        //else
//                        {
//                            CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO {0} (Locatorcode, RRNo, RRSeqNo, LotSeqNo, LocSeqNo, Quantity, UntaggedQuantity, RRStatus, ScanFlag, SentFlag) 
//                                                        VALUES('{1}','{2}','{3}','{4}','{5}', '{6}', '0','S', 1, 1)", "Tagging", CommonFunctions.LocatorCode, CommonFunctions.BarcodeRRNo, CommonFunctions.BarcodeRRSeq, CommonFunctions.BarcodeRRLotSeq, CommonFunctions.NewLocSeqNo, CommonFunctions.InputQty)); //changed to new LocSeqNo
//                            //SET NEXT
//                            CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE {0} SET ScanFlag = 0
//                                                            WHERE RRNo = '{1}' AND RRSeqNo = '{2}' AND LotSeqNo = '{3}' AND LocSeqNo = '{4}' AND ScanFlag = 1 AND SentFlag = 0", "Tagging", CommonFunctions.BarcodeRRNo, CommonFunctions.BarcodeRRSeq, CommonFunctions.BarcodeRRLotSeq, CommonFunctions.BarcodeRRLocSeq));
//                            Audio.PlayOKBeep();
//                            CommonFunctions.MessageShow(string.Format("{0}\n{1}", CommonMsg.Success.NewRR, CommonFunctions.NewRRInfo(CommonFunctions.LocatorCode, CommonFunctions.InputQty, false)));
//                        }
                    }
            }
            catch (Exception ex)
            {
                Audio.PlayErrorBeep();
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
            //InsertDataTagging(LocatorCode, ConvertStringDecimal(Quantity), UntaggedQty);
        }

        public static void ServerdbLocatorTaggingProcess()
        {
            IsTaggingThreadBusy = true;

            try
            {
                if (CommonFunctions.IsConnected(false))
                {
                    bool NoPendingTag = false;
                    bool NoPendingMove = false;

                    //START LOOPING TAGGED ITEMS

                    using (DataTable dtTaggedItem = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.ViewFiltered.LocatorTagingUnsentAll, false))
                    {
                        try
                        {
                            if (dtTaggedItem.Rows.Count == 0) NoPendingTag = true;
                        }
                        catch
                        { }
                        foreach (DataRow row in dtTaggedItem.Rows)
                        {
                            bool Success = false;
                            //Update Server Data
                            CommonFunctions.DataReader(CommonQueryStrings.StoredProc.LocatorTagging(row["RRNo"].ToString()
                                                                                                   , row["RRSeqNo"].ToString()
                                                                                                   , row["LotSeqNo"].ToString()
                                                                                                   , row["LocSeqNo"].ToString()
                                                                                                   , row["Locatorcode"].ToString()
                                                                                                   , Convert.ToDecimal(row["Quantity"].ToString()).ToString()
                                                                                                   , CommonFunctions.Username )
                                                                                                   , false
                                                                                                   , ref Success);

                            //Update Local Data
                            if (Success)
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Delete.LocatorTaggingSent
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

                    //START LOOPING MOVED ITEMS
                    StockMovementBase.ServerdbStockMovementProcess(ref NoPendingMove);

                    if (NoPendingTag && NoPendingMove)
                    {
                        try
                        {
                            //Convertable to int and greater than 0
                            if (Convert.ToInt16(CommonFunctions.CEDataReader(CommonQueryStrings.Mobile.ViewFiltered.TaggedListPendigCount, false)) > 0)
                            {
                                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.TaggedListFlagAll, "Sent", "1"), false, false);
                            }
                        }
                        catch
                        { }
                    }
                }
            }
            catch
            { }

            IsTaggingThreadBusy = false;
        }

        public static void MobiledbLocatorTaggingProcess()
        {
            //ENTRY
            if (CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.Tagging
                                                              , "Tagging"
                                                              , CommonFunctions.UntaggedQty
                                                              , CommonFunctions.InputQty
                                                              , CommonFunctions.LocatorCode
                                                              , CommonFunctions.BarcodeRRNo
                                                              , CommonFunctions.BarcodeRRSeq
                                                              , CommonFunctions.BarcodeRRLotSeq
                                                              , CommonFunctions.BarcodeRRLocSeq)) == 0)
            {
                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Insert.Tagging
                                                              , "Tagging"
                                                              , CommonFunctions.BarcodeRRNo
                                                              , CommonFunctions.BarcodeRRSeq
                                                              , CommonFunctions.BarcodeRRLotSeq
                                                              , CommonFunctions.BarcodeRRLocSeq
                                                              , CommonFunctions.LocatorCode
                                                              , CommonFunctions.InputQty
                                                              , CommonFunctions.UntaggedQty));
            }
                
        }

        public static void ProcessLocatorCode()
        {

            SQLDataHelper dal = new SQLDataHelper();
            CommonFunctions.ExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.LocatorUpdate, CommonFunctions.BarcodeRRNo
                                                                                                            , CommonFunctions.BarcodeRRSeq
                                                                                                            , CommonFunctions.BarcodeRRLotSeq
                                                                                                            , CommonFunctions.BarcodeRRLocSeq
                                                                                                            , CommonFunctions.LocatorCode
                                                                                                            , CommonFunctions.BarcodeQuantity
                                                                                                            , CommonFunctions.Username
                                                                                                            ));
        }
        public static void MobiledbLocatorTaggedListProcess(bool Sent)
        {
            if (CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Update.TaggedList 
                                                              , CommonFunctions.BarcodeRRNo
                                                              , CommonFunctions.BarcodeRRSeq
                                                              , CommonFunctions.BarcodeRRLotSeq
                                                              , CommonFunctions.BarcodeRRLocSeq
                                                              , CommonFunctions.BarcodeQuantity
                                                              , CommonFunctions.BarcodeStockCode
                                                              , CommonFunctions.BarcodePrintedDate
                                                              , CommonFunctions.TagNo
                                                              , CommonFunctions.InputQty
                                                              , CommonFunctions.LocatorCode
                                                              , CommonFunctions.LocatorDesc
                                                              , CommonFunctions.RRStatus
                                                              , Sent ? "Sent" : "Pending"
                                                              , CommonFunctions.ScannedDate
                                                              , "1", Sent ? "1" : "0")) == 0)
            {
                CommonFunctions.CeExecuteNonQuery(string.Format(CommonQueryStrings.Mobile.Insert.TaggedList
                                                              , CommonFunctions.BarcodeRRNo
                                                              , CommonFunctions.BarcodeRRSeq
                                                              , CommonFunctions.BarcodeRRLotSeq
                                                              , CommonFunctions.BarcodeRRLocSeq
                                                              , CommonFunctions.BarcodeQuantity
                                                              , CommonFunctions.BarcodeStockCode
                                                              , CommonFunctions.BarcodePrintedDate
                                                              , CommonFunctions.TagNo
                                                              , CommonFunctions.InputQty
                                                              , CommonFunctions.LocatorCode
                                                              , CommonFunctions.LocatorDesc
                                                              , CommonFunctions.RRStatus
                                                              , Sent ? "Sent" : "Pending"
                                                              , CommonFunctions.ScannedDate
                                                              , "1", Sent ? "1" : "0"
                                                              , CommonFunctions.LotCode));
            }
        }

        public static DataTable MobiledbTaggedListView()
        {
            DataTable Dt = new DataTable();
            try
            {
                Dt = CommonFunctions.CEGetData(CommonQueryStrings.Mobile.View.TaggedList);
            }
            catch
            {
                Dt = null;
            }
            return Dt;
        }

        public static void MobiledbClearTagging()
        {
            //CommonFunctions.CeExecuteNonQuery(CommonQueryStrings.Mobile.Delete.LocatorTagging);
            //CommonFunctions.CeExecuteNonQuery(CommonQueryStrings.Mobile.Delete.StockMovement);
            CommonFunctions.CeExecuteNonQuery(CommonQueryStrings.Mobile.Delete.LocatorTaggedList);
        }

        public static int CountTaggedList()
        {
            string strCount = CommonFunctions.CEDataReader(String.Format(CommonQueryStrings.Mobile.View.Count,CommonQueryStrings.Mobile.Table.TaggedList));
            int Count = 0;
            try
            {
                Count = string.IsNullOrEmpty(strCount) ? 0 : Convert.ToInt32(strCount);
            }
            catch { }
            return Count;
        }

        public static bool GetLocatorTaggingInfo()
        {
            if (CommonFunctions.IsReceivingReportInfoGenerated())
            {
                if (CommonFunctions.LocatorQty == 0)
                {
                    //Nilo Added to verify if scanned label is updated <06/07/2012>
                    return (CommonFunctions.ScannedLabelForReprinting(false, true, "", "LT-H" + CommonFunctions.HandyNo)) ? false : CommonFunctions.IsLocatorTaggingRRInfoGenerated();
                }
                else
                {
                    return (CommonFunctions.ScannedLabelForReprinting(false, true, "", "SM-H" + CommonFunctions.HandyNo)) ? false : CommonFunctions.IsStockMovementRRInfoGenerated();
                }
            }
            else
                return false;
        }

        public static DataTable ListUntagRRNumber(String RRListFilter)
        {
            DataTable dt = new DataTable();
            if (CommonFunctions.IsConnected())
            {
                string query = string.Format(CommonQueryStrings.Remote.View.UntagRRNumber, RRListFilter);

                dt = CommonFunctions.GetData(query);
            }
            else
                dt = null;

            return dt;
        }

        public static DataTable ListUntagTagNo(String RRNo)
        {
            DataTable dt = new DataTable();
            if (CommonFunctions.IsConnected())
            {
                String Query = String.Format(CommonQueryStrings.Remote.View.UntagTagNo, RRNo);
                dt = CommonFunctions.GetData(Query);
            }
            else
                dt = null;

            return dt;
        }



        //Nilo Added 20130905 : New Locator Tagging Functions

        public static bool IsLocatorTaggingInfoGenerated()
        {
            if (IsReceivingReportInfoGenerated_RROnly())
            {
                GetReceiveingReportDetails(CommonFunctions.BarcodeStockCode);
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsReceivingReportInfoGenerated_RROnly()
        {
            try
            {
                DataTable dt = CommonFunctions.GetData(string.Format("EXEC spHandyGetReceivingReportInfo_RROnly '{0}','{1}','{2}','{3}'"
                                                    , CommonFunctions.BarcodeRRNo
                                                    , CommonFunctions.BarcodeRRSeq
                                                    , CommonFunctions.BarcodeRRLotSeq
                                                    , CommonFunctions.BarcodeRRLocSeq));
                if (dt == null)
                    return false;

                if (dt.Rows.Count > 0)
                {
                    CommonFunctions.TagNo = dt.Rows[0]["TagNo"].ToString().Trim();
                    CommonFunctions.Thickness = (decimal)dt.Rows[0]["Thickness"];
                    CommonFunctions.Width = (decimal)dt.Rows[0]["Width"];
                    CommonFunctions.Height = (decimal)dt.Rows[0]["Height"];
                    CommonFunctions.Length = (decimal)dt.Rows[0]["Length"];
                    CommonFunctions.Specs = dt.Rows[0]["Specs"].ToString().Trim();
                    CommonFunctions.Mill = dt.Rows[0]["Mill"].ToString().Trim();
                    CommonFunctions.Works = dt.Rows[0]["Works"].ToString().Trim();
                    CommonFunctions.Unit = dt.Rows[0]["Unit"].ToString().Trim();
                    CommonFunctions.StockType = dt.Rows[0]["StockType"].ToString().Trim();
                    CommonFunctions.IssuedQty = (decimal)dt.Rows[0]["IssuedQty"];
                    CommonFunctions.StockClassCode = dt.Rows[0]["StockClassCode"].ToString().Trim();
                    CommonFunctions.StockDescription = dt.Rows[0]["StockDescription"].ToString().Trim();
                    CommonFunctions.IsHalfFinished = (bool)dt.Rows[0]["IsHalfFinished"];
                    CommonFunctions.OldLocatorCode = dt.Rows[0]["OldLocatorCode"].ToString().Trim();
                    CommonFunctions.LocatorQty = (decimal)dt.Rows[0]["LocatorQty"];
                    CommonFunctions.LotQty = (decimal)dt.Rows[0]["LotQty"];
                    CommonFunctions.RRStatus = dt.Rows[0]["Status"].ToString().Trim();
                    CommonFunctions.LotCode = (string)dt.Rows[0]["LotCode"].ToString().Trim();
                    CommonFunctions.StockName = (string)dt.Rows[0]["StockName"].ToString().Trim();
                    CommonFunctions.StockSpecs = (string)dt.Rows[0]["Specification"].ToString().Trim();
                    CommonFunctions.Specs = (string)dt.Rows[0]["Specs"].ToString().Trim();
                    CommonFunctions.Expiry = (DateTime)dt.Rows[0]["Expiry"];
                    CommonFunctions.OldLocatorDesc = dt.Rows[0]["OldLocatorDesc"].ToString().Trim();
                  
                    //Nilo Added 20130218 : Reprint Flag in for reprint
                    bool IsReprint = false;
                    IsReprint = (bool)dt.Rows[0]["IsReprint"];
                    CommonFunctions.ScannedDate = (DateTime)dt.Rows[0]["ScannedDate"];
                    //End
                    //Primary validation
                    /***** Nilo Added : Validate if issued material is processed to new labels *****/
                    //if (!string.IsNullOrEmpty(CommonFunctions.OldLocatorCode) && CommonFunctions.LocatorQty > 0 && CommonFunctions.IssuedQty > 0 && (CommonFunctions.LocatorQty - CommonFunctions.IssuedQty <= 0))
                    //{
                    //    if (CommonFunctions.IsBarcodeOutDated())
                    //        return false;
                    //}
                    //Other validations
                    if (CommonFunctions.RRStatus.Trim().ToUpper().Equals(CommonEnum.GetStringValue(CommonEnum.RRStatus.Cancelled)))
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(CommonMsg.Warning.ItemCancelled, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.CloseOnly);
                        dt = null; //releasing
                        return false;
                    }
                    else if (CommonFunctions.RRStatus.Trim().ToUpper().Equals(CommonEnum.GetStringValue(CommonEnum.RRStatus.Delivered)))
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(CommonMsg.Warning.ItemIssued, CommonEnum.NotificationType.Information, CommonEnum.MessageButtons.CloseOnly);
                        dt = null; //releasing
                        return false;
                    }
                    else if (CommonFunctions.RRStatus.Trim().ToUpper().Equals(CommonEnum.GetStringValue(CommonEnum.RRStatus.Temp)))
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(CommonMsg.Warning.ItemTemp, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.CloseOnly);
                        dt = null; //releasing
                        return false;
                    }
                    else if (CommonFunctions.RRStatus.Trim().ToUpper().Equals(CommonEnum.GetStringValue(CommonEnum.RRStatus.New)))
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(CommonMsg.Warning.ItemNotYetApproved, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.CloseOnly);
                        dt = null; //releasing
                        return false;
                    }
                    else if (IsReprint)
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_Reprint, CommonFunctions.TagNo), CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.CloseOnly);
                        dt = null; //releasing
                        return false;
                    }
                    else if (CommonFunctions.RRStatus.Trim().ToUpper().Equals(CommonEnum.GetStringValue(CommonEnum.RRStatus.Reprint)))
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(CommonMsg.Warning.Reprint, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.CloseOnly);
                        dt = null; //releasing
                        return false;
                    }
                    else if (CommonFunctions.RRStatus.Trim().ToUpper().Equals(CommonEnum.GetStringValue(CommonEnum.RRStatus.Fulfilled)))
                    {
                        Audio.PlayErrorBeep();
                        CommonFunctions.MessageShow(CommonMsg.Info.ItemFulfilled, CommonEnum.NotificationType.Warning, CommonEnum.MessageButtons.CloseOnly);
                        dt = null; //releasing
                        return false;
                    }

                    dt.Dispose();
                    return true;
                }
                else
                {
                    CommonFunctions.MessageShow(string.Format(CommonMsg.Error.InventoryNotRetrieveRR, CommonFunctions.RRNoDisplay), CommonEnum.NotificationType.Warning);
                    dt.Dispose();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Audio.PlayErrorBeep();
                CommonFunctions.MessageShow(ex.Message
                            , string.Empty
                            , CommonEnum.NotificationType.Error
                            , CommonEnum.MessageButtons.CloseOnly);
                return false;
            }
        }

        private static void GetReceiveingReportDetails(string StockCode)
        {
            try
            {
                //GET AVAILABLE QUANTITY
                if (CommonFunctions.LocatorQty == 0)
                {
                    //Is for tagging
                    CommonFunctions.AvailableQty = CommonFunctions.LotQty;
                }
                else
                {
                    //Is for movement
                    CommonFunctions.AvailableQty = CommonFunctions.LocatorQty;
                }

                CommonFunctions.Unit = CommonFunctions.GetData(CommonQueryStrings.Remote.ViewFiltered.GetUnit(StockCode)).Rows[0][0].ToString();
               
                

                //GET DIMENSION
                //COMMENTED BY DEV1521-FRANCIS SANCHEZ 
                //THIS CODE IS ONLY APPLICABLE FOR MMSTEEL
                //DataTable dtSpecDetail = CommonFunctions.GetData(CommonQueryStrings.Remote.ViewFiltered.Specification(StockCode));
                //GetReceiveingReportDetails(dtSpecDetail);
                //dtSpecDetail.Dispose();
            }
            catch (Exception ex)
            {
                Audio.PlayErrorBeep();
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

        private static void GetReceiveingReportDetails(DataTable dtSpecDetail)
        {
            try
            {
                //GET SPECS DESCRIPTION
                foreach (DataRow drDimension in dtSpecDetail.Rows)
                {
                    CommonFunctions.Thickness = (decimal)drDimension["Thickness"];
                    CommonFunctions.Width = (decimal)drDimension["Width"];
                    CommonFunctions.Height = (decimal)drDimension["Height"];
                    CommonFunctions.Length = (decimal)drDimension["Length"];
                    if (String.IsNullOrEmpty(CommonFunctions.Specs.Trim()))
                    {
                        CommonFunctions.Specs = drDimension["Specs"].ToString().Trim();
                        //GET SPECS DESCRIPTION FROM CACHE
                        if (!GetSpecs())
                        {
                            //Thread Renew list
                            GenericMasterThreadProcess();
                        }
                    }
                   
                    //GET STOCK CLASS DESCRIPTION
                    if (!GetClassDesc())
                    {
                        //Thread Renew list
                        StockClassDesThreadProcess();
                    }

                    //GET OLD LOCATOR DESCRIPTION
                    foreach (DataRow drLocator in CommonFunctions.LocatorListTable.Rows)
                    {
                        if (CommonFunctions.OldLocatorCode.Equals(drLocator["Lmt_Locatorcode"].ToString().Trim(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            CommonFunctions.OldLocatorDesc = drLocator["Lmt_Locatordesc"].ToString().Trim();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Audio.PlayErrorBeep();
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

        private static bool GetSpecs()
        {
            bool ret = false;

            try
            {
                //Get from cached data
                if (CommonFunctions.GenericMasterList != null)
                {
                    foreach (DataRow drGeneric in CommonFunctions.GenericMasterList.Rows)
                    {
                        if (CommonFunctions.Specs.Equals(drGeneric["SpecsCode"].ToString().Trim(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            CommonFunctions.Specs = drGeneric["SpecsDesc"].ToString().Trim();
            
                            ret = true;
                            break;
                        }
                    }
                }

                if (!ret)
                {
                    //Try retrieving from server
                    bool Success = false;
                    string _filter = string.Format("AND Gmt_Genericcode = '{0}'", CommonFunctions.Specs);
                    string _specs = CommonFunctions.DataReader(CommonQueryStrings.Remote.View.GenericMasterList + _filter, false, ref Success);
                    if (Success)
                    {
                        CommonFunctions.Specs = _specs;
                    }
                }
            }
            catch { }

            return ret;
        }

        private static bool GetClassDesc()
        {
            bool ret = false;
            try
            {
                //Get from cached data
                if (CommonFunctions.StockClassDescList != null)
                {
                    foreach (DataRow drClass in CommonFunctions.StockClassDescList.Rows)
                    {
                        if (CommonFunctions.StockClassCode.Equals(drClass["ClassCode"].ToString().Trim(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            CommonFunctions.StockDescription = drClass["ClassDesc"].ToString().Trim();
                            ret = true;
                            break;
                        }
                    }
                }

                if (!ret)
                {
                    //Try retrieving from server
                    bool Success = false;
                    string _filter = string.Format("AND Scm_StockClassCode = '{0}'", CommonFunctions.StockClassCode);
                    string _StockClassDesc = CommonFunctions.DataReader(CommonQueryStrings.Remote.View.StockClassDescList + _filter, false, ref Success);
                    if (Success)
                    {
                        CommonFunctions.StockDescription = _StockClassDesc;
                    }
                }

            }
            catch { }
            return ret;
        }

        
        private static void GetGenericMasterList()
        {
            IsGenericMasterThreadBusy = true;

            CommonFunctions.GenericMasterList = CommonFunctions.GetData(CommonQueryStrings.Remote.View.GenericMasterList, false);

            IsGenericMasterThreadBusy = false;
        }

        private static void GetStockClassDescList()
        {
            IsStockClassThreadBusy = true; 

            CommonFunctions.StockClassDescList = CommonFunctions.GetData(CommonQueryStrings.Remote.View.StockClassDescList, false);

            IsStockClassThreadBusy = false;
        }

        //Threading functions

        private static System.Threading.Thread TaggingThread;
        private static bool IsTaggingThreadBusy = false;
        public static void TaggingThreadProcess()
        {
            try
            {
                if (!IsTaggingThreadBusy)
                {
                    TaggingThread = new System.Threading.Thread(LocatorTaggingBase.ServerdbLocatorTaggingProcess);
                    TaggingThread.Start();
                }
            }
            catch(Exception ex)
            {
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

        private static System.Threading.Thread StockClassThread;
        private static bool IsStockClassThreadBusy;
        public static void StockClassDesThreadProcess()
        {
            try
            {
                if (!IsStockClassThreadBusy)
                {
                    StockClassThread = new System.Threading.Thread(LocatorTaggingBase.GetStockClassDescList);
                    StockClassThread.Start();
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

        private static System.Threading.Thread GenericMasterThread;
        private static bool IsGenericMasterThreadBusy;
        public static void GenericMasterThreadProcess()
        {
            try
            {
                if (!IsGenericMasterThreadBusy)
                {
                    GenericMasterThread = new System.Threading.Thread(LocatorTaggingBase.GetGenericMasterList);
                    GenericMasterThread.Start();
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

        public static void OnloadStartBackGroundTransactions()
        {
            //Download Generic Master
            if (CommonFunctions.GenericMasterList == null)
            {
                LocatorTaggingBase.GenericMasterThreadProcess();
            }
            else if (CommonFunctions.GenericMasterList.Rows.Count == 0)
            {
                LocatorTaggingBase.GenericMasterThreadProcess();
            }

            //Download Stock Class Master
            if (CommonFunctions.StockClassDescList == null)
            {
                LocatorTaggingBase.StockClassDesThreadProcess();
            }
            else if (CommonFunctions.StockClassDescList.Rows.Count == 0)
            {
                LocatorTaggingBase.StockClassDesThreadProcess();
            }

            //Try Saving Pending Items 
            LocatorTaggingBase.TaggingThreadProcess();
        }

        public static bool IsRRTagged(string rrno, string rrseqno, string lotseqno, string locseqno)
        {
            SQLDataHelper dal = new SQLDataHelper();
            DataTable dt = new DataTable();

            try
            {
                dal.OpenDB();
                dt = dal.ExecuteDataTable(CommonQueryStrings.Remote.ViewFiltered.IsRRTagged(rrno, rrseqno, lotseqno, locseqno));
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
                if (dt.Rows[0][0].ToString().Equals(""))
                    return false;
            }
            return true;
        }

        public static bool isRRBarcodeOutdated()
        {
            SQLDataHelper dal = new SQLDataHelper();
            DataTable dt = new DataTable();

            try
            {
                dal.OpenDB();
                dt = dal.ExecuteDataTable(CommonQueryStrings.Remote.ViewFiltered.GetCurrentRRAvailableQuantity(CommonFunctions.BarcodeRRNo,
                                                                                                               CommonFunctions.BarcodeRRSeq,
                                                                                                               CommonFunctions.BarcodeRRLotSeq,
                                                                                                               CommonFunctions.BarcodeRRLocSeq));
            }
            catch (Exception e)
            {
                CommonFunctions.MessageShow(CommonMsg.Error.d_UnabletoProcess + "\n" + e.ToString(), CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.Ok);
            }
            finally
            {
                dal.CloseDB();
            }

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return CommonFunctions.ConvertStringDecimal(dt.Rows[0][0].ToString()) != 0 && CommonFunctions.ConvertStringDecimal(dt.Rows[0][0].ToString()) != CommonFunctions.ConvertStringDecimal(CommonFunctions.BarcodeQuantity);                        
                }
            }

            return false;
        }        
    }
}
