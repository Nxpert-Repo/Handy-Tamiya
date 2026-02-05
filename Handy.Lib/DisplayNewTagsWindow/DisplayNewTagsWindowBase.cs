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
    public class DisplayNewTagsWindowBase
    {
        /// <summary>
        /// Returns data table from T_ReceivingReportDetail for the specified parameters.
        /// </summary>
        /// <param name="BarcodeRRNo"></param>
        /// <param name="BarcodeRRSeqNo"></param>
        /// <param name="BarcodeRRLotSeqNo"></param>
        /// <param name="BarcodeRRLocSeqNo"></param>
        /// <returns></returns>
        public static DataTable GetTagNoByRRNo(string BarcodeRRNo, string BarcodeRRSeqNo, string BarcodeRRLotSeqNo, string BarcodeRRLocSeqNo) 
        {
            DataTable dt = null;

            try
            {
                dt = CommonFunctions.GetData(string.Format("SELECT Rrd_TagNo TagNo, Rrd_TagSeqNo TagSeqNo, Rrd_locatorcode LocatorCode FROM T_ReceivingReportDetail WHERE Rrd_RRNo =  '{0}' AND Rrd_RRSeqNo =  '{1}' AND Rrd_LotSeqNo= '{2}' AND Rrd_RRlocseqno =  '{3}'", BarcodeRRNo, BarcodeRRSeqNo, BarcodeRRLotSeqNo, BarcodeRRLocSeqNo));
            }catch(Exception e){
            }

            return dt;
        }

        /// <summary>
        /// Retrieves top 20 valid tag numbers from T_ReceivingReportDetail. Returns data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllNewTagNumbers() 
        {
            DataTable dt = null;

            try
            {
                dt = CommonFunctions.GetData(string.Format("SELECT TOP 20 Rrd_TagNo TagNo, Rrd_TagSeqNo TagSeqNo, Rrd_locatorcode LocatorCode FROM T_ReceivingReportDetail WHERE Rrd_TagNo <> '000000' AND Rrd_TagNo <> '' AND Rrd_TagSeqNo <> '000'"));
            }
            catch (Exception)
            {
            }

            return dt;
        }

        /// <summary>
        /// Calls spHandyGetLatestBarcodeList for the given RR Info. Returns data table of lastest barcodes for the specified RR.
        /// </summary>
        /// <param name="BarcodeRRNo"></param>
        /// <param name="BarcodeRRSeqNo"></param>
        /// <param name="BarcodeRRLotSeqNo"></param>
        /// <param name="BarcodeRRLocSeqNo"></param>
        /// <returns></returns>
        public static DataTable GetAllNewTagNumbers(string BarcodeRRNo, string BarcodeRRSeqNo, string BarcodeRRLotSeqNo, string BarcodeRRLocSeqNo)
        {
            DataTable dt = null;

            try
            {
                dt = CommonFunctions.GetData(string.Format("EXEC spHandyGetLatestBarcodeList '{0}', '{1}', '{2}', '{3}'", BarcodeRRNo, BarcodeRRSeqNo, BarcodeRRLotSeqNo, BarcodeRRLocSeqNo));
            }
            catch (Exception)
            {
            }

            return dt;
        }
    }
}
