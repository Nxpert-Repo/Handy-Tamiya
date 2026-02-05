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
    public class JobStartBase
    {
        public static void JobSheetReceivingReportList()
        {
            CommonFunctions.CeExecuteNonQuery("DELETE JobStart"); // clear recent values
            //Set new values
            using (DataTable dt = CommonFunctions.GetData(string.Format("EXEC dbo.spHandyGetJobStartRRList '{0}'", CommonFunctions.BarcodeJobSheetNo)))
            {
                if (dt.Rows.Count > 0)
                    foreach (DataRow row in dt.Rows)
                        CommonFunctions.CeExecuteNonQuery(string.Format(@"INSERT INTO JobStart (TagNo, RRNo, RRSeqNo, LotSeqNo, LocSeqNo, ScanFlag, SentFlag)
                                                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", row["TagNo"].ToString().Trim(), row["RRNo"].ToString().Trim(), row["RRSeqNo"].ToString().Trim(), row["RRLotSeqNo"].ToString().Trim(), row["RRLocSeqNo"].ToString().Trim(), 0, 0));
            }
        }

        public static bool IsJobSheetUpdated()
        {
            CommonFunctions.CeExecuteNonQuery(string.Format(@"UPDATE JobStart SET ScanFlag = 1 WHERE RRNo = '{0}' AND RRSeqNo = '{1}' AND LotSeqNo = '{2}' AND LocSeqNo = '{3}' AND ScanFlag = 0"
                                                            , CommonFunctions.BarcodeRRNo
                                                            , CommonFunctions.BarcodeRRSeq
                                                            , CommonFunctions.BarcodeRRLotSeq
                                                            , CommonFunctions.BarcodeRRLocSeq));

            DataTable dt = CommonFunctions.CEGetData("SELECT * FROM JobStart WHERE ScanFlag = 0");

            if (dt.Rows.Count == 0)
            {
                if (CommonFunctions.ExecuteNonQuery(string.Format("UPDATE T_JobOrderHeader SET Joh_Status = 'S', Joh_JobStartedDateTime = GETDATE() WHERE Joh_JobOrderNo = '{0}'", CommonFunctions.BarcodeJobSheetNo)))
                {
                    CommonFunctions.MessageShow(string.Format(CommonMsg.Info.JSNo
                                                            , CommonFunctions.BarcodeJobSheetNo), "Started");
                    CommonFunctions.BarcodeJobSheetNo = string.Empty;
                    dt.Dispose();
                    return true;
                }
                else
                {
                    dt.Dispose();
                    return false;
                }
            }
            else
            {
                DataTable dtUnscanned = CommonFunctions.CEGetData("SELECT '[' + TagNo + '] ' as TagNo FROM JobStart WHERE ScanFlag = 0");
                string UnscannedTagNo = string.Empty;
                if (dtUnscanned != null)
                {
                    if (dtUnscanned.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtUnscanned.Rows)
                        {
                            UnscannedTagNo += dr["TagNo"].ToString();
                        }
                    }
                    dtUnscanned = null;
                    CommonFunctions.MessageShow(string.Format("Item(s) need to be scanned.\n\n" + UnscannedTagNo), CommonEnum.NotificationType.Warning);
                }
                
                dt.Dispose();
                return false;
            }
        }

        public static void RevertJobSheet()
        {
            if (CommonFunctions.ExecuteNonQuery(string.Format("UPDATE T_JobOrderHeader SET Joh_Status = 'A', Joh_JobStartedDateTime = NULL WHERE Joh_JobOrderNo = '{0}'", CommonFunctions.BarcodeJobSheetNo)))
                CommonFunctions.MessageShow(string.Format(CommonMsg.Info.JSNo, CommonFunctions.BarcodeJobSheetNo)
                            , "JobSheet Unstarted"
                            , CommonEnum.MessageButtons.Ok);
            else
                CommonFunctions.MessageShow(string.Format(CommonMsg.Info.JSNo, CommonFunctions.BarcodeJobSheetNo)
                            , "Please try again"
                            , CommonEnum.NotificationType.Error, CommonEnum.MessageButtons.CloseOnly);
        }
    }
}
