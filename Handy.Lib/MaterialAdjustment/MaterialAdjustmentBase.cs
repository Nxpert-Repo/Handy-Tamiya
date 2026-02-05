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
    public class MaterialAdjustmentBase
    {
        public static void SendingThreadMaterialAdjustment()
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

                    using (DataTable dt = CommonFunctions.CEGetData("SELECT * FROM Inventory WHERE SentFlag = 0 AND ScanFlag = 1 ORDER BY UniqueId"))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                CommonFunctions.Result = CommonFunctions.DataReader("EXEC dbo.spHandyMaterialAdjustment '"
                                    + row["RRNo"].ToString().Trim() + "', '"
                                    + row["RRSeqNo"].ToString().Trim() + "', '"
                                    + row["LotSeqNo"].ToString().Trim() + "', '"
                                    + row["LocSeqNo"].ToString().Trim() + "', '"
                                    + (decimal)row["Quantity"] + "', '"
                                    + row["MatAdjustProcess"].ToString().Trim() + "', '"
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
                CommonFunctions.MessageShow(ex.Message, string.Empty, CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
            }
        }

        public static void ServerActualProcessMaterialAdjustment()
        {
            try
            {
                //ENTRY
                if (string.IsNullOrEmpty(CommonFunctions.CEGetQuantity("Inventory")))
                {
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO Inventory (RRNo, RRSeqNo, LotSeqNo, LocSeqNo, AvailableQty, Quantity, MatAdjustProcess, RRStatus, SentFlag, ScanFlag)
                            VALUES('{0}','{1}','{2}', '{3}','{4}','{5}','{6}','Q', 0, 1)"
                                                                    , CommonFunctions.BarcodeRRNo
                                                                    , CommonFunctions.BarcodeRRSeq
                                                                    , CommonFunctions.BarcodeRRLotSeq
                                                                    , CommonFunctions.BarcodeRRLocSeq
                                                                    , CommonFunctions.ExpectedActualQty
                                                                    , CommonFunctions.VarianceQty
                                                                    , CommonFunctions.VarianceDesc));
                }
                else
                {
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE Inventory SET AvailableQty = '{0}', Quantity = '{1}', ScanFlag = 1, RRStatus = 'Q', MatAdjustProcess = '{6}'
                                                            WHERE RRNo = '{2}' AND RRSeqNo = '{3}' AND LotSeqNo = '{4}' AND LocSeqNo = '{5}' AND ScanFlag = 0 AND SentFlag = 0"
                                                                                                                        , CommonFunctions.ExpectedActualQty
                                                                                                                        , CommonFunctions.VarianceQty
                                                                                                                        , CommonFunctions.BarcodeRRNo
                                                                                                                        , CommonFunctions.BarcodeRRSeq
                                                                                                                        , CommonFunctions.BarcodeRRLotSeq
                                                                                                                        , CommonFunctions.BarcodeRRLocSeq
                                                                                                                        , CommonFunctions.VarianceDesc));

                }

                //SEND
                CommonFunctions.SendingThread(CommonEnum.Function.MaterialAdjustment);

                //STORE (BACK-UP)
                if (CommonFunctions.Result == "E")
                    CommonFunctions.MessageShow("Item not found", CommonEnum.NotificationType.Error);
                else
                {
                    CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE Inventory SET Quantity = '{0}', RRStatus = 'S', SentFlag = 1, MatAdjustProcess = '{5}'
                                      WHERE RRNo = '{1}' AND RRSeqNo = '{2}' AND LotSeqNo = '{3}' AND LocSeqNo = '{4}' AND ScanFlag = 1 AND SentFlag = 0"
                                                                                    , CommonFunctions.VarianceQty
                                                                                    , CommonFunctions.BarcodeRRNo
                                                                                    , CommonFunctions.BarcodeRRSeq
                                                                                    , CommonFunctions.BarcodeRRLotSeq
                                                                                    , CommonFunctions.BarcodeRRLocSeq
                                                                                    , CommonFunctions.VarianceDesc)); //changed to new LocSeqNo
                    CommonFunctions.MessageShow(CommonFunctions.MaterialAdjustmentMessage(), CommonFunctions.VarianceDesc);
                    //NILO ADDED TO Berify reprinting
                    CommonFunctions.ScannedLabelForReprinting(true, true, "", "MA");
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow(ex.Message, CommonEnum.NotificationType.Error);
            }
        }
    }
}
