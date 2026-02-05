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
    public class StockReclassBase
    {
        public static void SendingThreadStocReclassorOpening()
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

                    CommonFunctions.NewLocSeqNo = "N";
                    string Query = string.Format("EXEC spHandyStockReclass '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'"
                                                    , CommonFunctions.BarcodeRRNo
                                                    , CommonFunctions.BarcodeRRSeq
                                                    , CommonFunctions.BarcodeRRLotSeq
                                                    , CommonFunctions.BarcodeRRLocSeq
                                                    , CommonFunctions.BarcodeStockCode
                                                    , CommonFunctions.BarcodeQuantity
                                                    , CommonFunctions.StockClassCode
                                                    , CommonFunctions.StockClassCodeNew
                                                    , CommonFunctions.HandyNo
                                                    , CommonFunctions.IsReclass.Equals(true) ? "1" : "0"
                                                    , CommonFunctions.Username
                                                    , CommonFunctions.CustomerCode);

                    String Result = CommonFunctions.DataReader(Query);
                    CommonFunctions.NewLocSeqNo = Result.ToUpper().Trim();
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

        public static void ServerActualProcessStockReclass()
        {
            try
            {
                #region Mobile Add Query
                string AddQuery = String.Format(CommonQueryStrings.Mobile.Insert.StockReclass
                                                , CommonFunctions.BarcodeRRNo
                                                , CommonFunctions.BarcodeRRSeq
                                                , CommonFunctions.BarcodeRRLotSeq
                                                , CommonFunctions.BarcodeRRLocSeq
                                                , CommonFunctions.BarcodeStockCode
                                                , CommonFunctions.BarcodeQuantity
                                                , CommonFunctions.BarcodePrintedDate
                                                , CommonFunctions.TagNo
                                                , CommonFunctions.StockType
                                                , CommonFunctions.StockClassCode
                                                , CommonFunctions.StockClassCodeNew
                                                , CommonFunctions.StockClass
                                                , CommonFunctions.StockClassNew
                                                , CommonFunctions.AvailableQty
                                                , CommonFunctions.RRStatus
                                                , CommonFunctions.LocatorCode
                                                , CommonFunctions.LocatorDesc
                                                , CommonFunctions.Thickness
                                                , CommonFunctions.Width
                                                , CommonFunctions.Length
                                                , CommonFunctions.Specs
                                                , CommonFunctions.Unit
                                                , CommonFunctions.GetDateTime()
                                                , "1"
                                                , "0");


                #endregion
                #region Mobile Update Query
                string UpdateQuery = String.Format(CommonQueryStrings.Mobile.Update.StockReclass
                                                    , CommonFunctions.BarcodeRRNo
                                                    , CommonFunctions.BarcodeRRSeq
                                                    , CommonFunctions.BarcodeRRLotSeq
                                                    , CommonFunctions.BarcodeRRLocSeq
                                                    , CommonFunctions.BarcodeStockCode
                                                    , CommonFunctions.BarcodeQuantity
                                                    , CommonFunctions.BarcodePrintedDate
                                                    , CommonFunctions.TagNo
                                                    , CommonFunctions.StockType
                                                    , CommonFunctions.StockClassCode
                                                    , CommonFunctions.StockClassCodeNew
                                                    , CommonFunctions.StockClass
                                                    , CommonFunctions.StockClassNew
                                                    , CommonFunctions.AvailableQty
                                                    , CommonFunctions.RRStatus
                                                    , CommonFunctions.LocatorCode
                                                    , CommonFunctions.LocatorDesc
                                                    , CommonFunctions.Thickness
                                                    , CommonFunctions.Width
                                                    , CommonFunctions.Length
                                                    , CommonFunctions.Specs
                                                    , CommonFunctions.Unit
                                                    , CommonFunctions.GetDateTime()
                                                    , "1"
                                                    , "0");
                #endregion
                //ENTRY
                if (string.IsNullOrEmpty(CommonFunctions.CEGetQuantity("StockReclass", "AvailableQty")))
                {

                    CommonFunctions.CeExecuteNonQuery(AddQuery);
                }
                else
                {
                    CommonFunctions.CeExecuteNonQuery(UpdateQuery);
                }
                //SEND
                if (CommonFunctions.IsReclass)
                {
                    CommonFunctions.SendingThread(CommonEnum.Function.StockReclass);
                }
                else
                {
                    CommonFunctions.SendingThread(CommonEnum.Function.StockPackingOpennig);
                }

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
                else if (CommonFunctions.NewLocSeqNo.Equals("S"))
                {
                    #region Mobile Update Query
                    CommonFunctions.CeExecuteNonQuery(String.Format(CommonQueryStrings.Mobile.Update.StockReclass
                                                    , CommonFunctions.BarcodeRRNo
                                                    , CommonFunctions.BarcodeRRSeq
                                                    , CommonFunctions.BarcodeRRLotSeq
                                                    , CommonFunctions.BarcodeRRLocSeq
                                                    , CommonFunctions.BarcodeStockCode
                                                    , CommonFunctions.BarcodeQuantity
                                                    , CommonFunctions.BarcodePrintedDate
                                                    , CommonFunctions.TagNo
                                                    , CommonFunctions.StockType
                                                    , CommonFunctions.StockClassCode
                                                    , CommonFunctions.StockClassCodeNew
                                                    , CommonFunctions.StockClass
                                                    , CommonFunctions.StockClassNew
                                                    , CommonFunctions.AvailableQty
                                                    , CommonFunctions.RRStatus
                                                    , CommonFunctions.LocatorCode
                                                    , CommonFunctions.LocatorDesc
                                                    , CommonFunctions.Thickness
                                                    , CommonFunctions.Width
                                                    , CommonFunctions.Length
                                                    , CommonFunctions.Specs
                                                    , CommonFunctions.Unit
                                                    , CommonFunctions.GetDateTime()
                                                    , "1"
                                                    , "1"));
                    #endregion
                    Audio.PlayOKBeep();
                    CommonFunctions.MessageShow(string.Format(CommonMsg.Success.SuccessReclass, CommonFunctions.TagNo, CommonFunctions.StockClassNew)
                                , CommonEnum.NotificationType.Success);
                }
            }
            catch (Exception ex)
            {
                Audio.PlayErrorBeep();
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }

        public static void GetStockClassList()
        {
            CommonFunctions.StockClassList = null;
            CommonFunctions.StockClassList = CommonFunctions.GetData(String.Format("EXEC [spHandyGetStockClassList] '{0}','{1}','{2}'"
                                                                                    , CommonFunctions.StockType
                                                                                    , CommonFunctions.StockClassCode
                                                                                    , CommonFunctions.IsReclass.Equals(true) ? "1" : "0"));
        }

        public static void GetCustomerList()
        { 
            if(CommonFunctions.IsBalanceClass)
                if (CommonFunctions.CustomerList == null)
                {
                    CommonFunctions.CustomerList = CommonFunctions.GetData(CommonQueryStrings.Remote.View.CustomerList);    
                }
        }

        public static string GetNewClass()
        {
            return CommonFunctions.CEDataReader(string.Format(CommonQueryStrings.Mobile.View.StockReclassField, "StockReclass"
                                                                                                                , CommonFunctions.BarcodeRRNo
                                                                                                                , CommonFunctions.BarcodeRRSeq
                                                                                                                , CommonFunctions.BarcodeRRLotSeq
                                                                                                                , CommonFunctions.BarcodeRRLocSeq
                                                                                                                , "NewClass"));
        }

    }
}
