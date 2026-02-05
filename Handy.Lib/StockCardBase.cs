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


namespace Handy.Lib.StockCard
{
   public class StockCardBase
    {
        public static DataTable getRR(string stockcode)
        {
            DataTable Dt = new DataTable();
            try
            {
                Dt = CommonFunctions.GetData(CommonQueryStrings.Remote.View.StockCardView(stockcode));
            }
            catch
            {
                Dt = null;
           } 
            return Dt;
        }

        public static DataTable getStockType()
        {
            DataTable Dt = new DataTable();
            try
            {
                Dt = CommonFunctions.GetData(CommonQueryStrings.Remote.View.getStockType());
            }
            catch
            {
                Dt = null;
            }
            return Dt;
        }

      public static DataTable getStocks(string stocktype)
      {
          DataTable Dt = new DataTable();
          try
          {
              Dt = CommonFunctions.GetData(CommonQueryStrings.Remote.View.getStocks(stocktype));
          }
          catch
          {
              Dt = null;
          }
          return Dt;
      }

      public static DataTable getStockCodeFromBarCode(string rrBarcode)
      {
          DataTable Dt = new DataTable();
          try
          {
              Dt = CommonFunctions.GetData(CommonQueryStrings.Remote.View.getStockCodeFromBarcode(rrBarcode));
          }
          catch
          {
              Dt = null;
          }
          return Dt;
      
      }
    }
}
