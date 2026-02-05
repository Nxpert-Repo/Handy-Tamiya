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
    //20130403 Allen Added: Issuance Base Class
    public class IssuanceBase
    {
        public static bool InvalidProjectNo()
        {
            bool _return = false;
            if (CommonFunctions.RRListWithUnmatchProjCode != null)
            {
                foreach (DataRow row in CommonFunctions.RRListWithUnmatchProjCode.Rows)
                {
                    string RRUnmatchProjNo = string.Format("{0}-{1}-{2}-{3}"
                                                           , row["Rrd_RRNo"].ToString().Trim()
                                                           , row["Rrd_RRSeqNo"].ToString().Trim()
                                                           , row["Rrd_LotSeqNo"].ToString().Trim()
                                                           , row["Rrd_RRlocseqno"].ToString().Trim());
                    if (RRUnmatchProjNo.Equals(CommonFunctions.RRNoDisplay))
                    {
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_MismatchProjNo, row["Rrd_ProjectNo"].ToString().Trim()), CommonEnum.NotificationType.Warning);
                        _return = true;
                        break;
                    }
                }
            }
            return _return;
        }

        public static DataTable SelectedRowDisplayTable(DataTable table, string filter)
        {
            //copy the schema of source table
            DataTable FilteredTable = table.Clone();

            //get only the rows you want
            DataRow[] results = table.Select(filter);

            //populate new destination table
            foreach (DataRow dr in results)
            {
                FilteredTable.ImportRow(dr);
            }
            FilteredTable.AcceptChanges();
            return FilteredTable;
        }

        public static bool GetWRISList()
        {
            bool _return = false;

            if (CommonFunctions.IsConnected())
            {
                //Getting WRIS List of stocks
                try { CommonFunctions.WRISTable.Dispose(); } catch { }
                CommonFunctions.WRISTable = CommonFunctions.GetData(string.Format(CommonQueryStrings.StoredProc.spHandyGetStockIssueList, CommonFunctions.BarcodeWHReqControlNo));

                if (CommonFunctions.WRISTable != null)
                {
                    if (CommonFunctions.WRISTable.Rows.Count <= 0)
                    {
                        CommonFunctions.MessageShow(string.Format(CommonMsg.Error.d_NoInformation, CommonFunctions.BarcodeWHReqControlNo), CommonEnum.NotificationType.Warning);
                        _return = false;
                    }
                    else
                    {
                        if (CommonFunctions.WRISTable.Rows[0]["EXT_Remark"].ToString().Trim().Equals("CANCELLED"))
                        {
                            CommonFunctions.MessageShow(string.Format(CommonMsg.Warning.d_WRISCANCELLED, CommonFunctions.BarcodeWHReqControlNo), CommonEnum.NotificationType.Warning);
                            CommonFunctions.WRISTable = null;
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

        public static void GetRRListWithReservedProjNo()
        {
            //Nilo Added 10022012
            //This will get the list of RR that is valid stock code but is not with in the project no
            try
            {
                CommonFunctions.RRListWithUnmatchProjCode.Dispose();
            }
            catch { }
            CommonFunctions.RRListWithUnmatchProjCode = CommonFunctions.GetData(string.Format(CommonQueryStrings.StoredProc.spHandyGetStockIssueListWithProjNo, CommonFunctions.BarcodeWHReqControlNo));
        }

        public static void IssueItem()
        {
            try
            {
                CommonFunctions.SendingThread(CommonEnum.Function.MaterialIssuance);
            }
            catch (Exception ex)
            {
                CommonFunctions.MessageShow(ex.Message);
            }
        }

        public static bool GetWRISSplitList()
        {
            try
            {
               CommonFunctions.WRISTableSplitList.Dispose();
            }
            catch { }
            CommonFunctions.WRISTableSplitList = CommonFunctions.GetData(string.Format(CommonQueryStrings.StoredProc.spHandyGetStockIssueList, CommonFunctions.BarcodeWHReqControlNo));
            if (CommonFunctions.WRISTableSplitList.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
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

        //Checking
        public static int InsertNotExist(DataTable InserttoTable, DataRow InsertRow, string filter)
        {
            int affected = 0;
            DataRow[] InsertRows = InserttoTable.Select(filter);
            if (InsertRows.Length < 1)
            {
                InserttoTable.ImportRow(InsertRow);
                InserttoTable.AcceptChanges();
                ++affected;
            }
            return affected;
        }
    }
}
