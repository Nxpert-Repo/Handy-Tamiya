using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using System.ComponentModel;
using System.Data.SqlClient;


namespace DataHelper
{
    public class SQLDataHelper : BaseDataHelper
    {
        public SQLDataHelper()
        {
            base._DataSourceType = DataSourceType.SQLServer;
            base._Connection = GetConnection();
            this.DBName = _Connection.DataSource + "/" + _Connection.Database;
            //base._DataAdapter = new SqlDataAdapter();
        }

        public string DBName = string.Empty;

        public SQLDataHelper(string connectionName)
        {
            base._DataSourceType = DataSourceType.SQLServer;
            base._Connection = GetConnection(connectionName);
            //base._DataAdapter = new SqlDataAdapter();          
        }

        protected SqlConnection GetConnection()
        {
            //MessageBox.Show(HandyConfiguration.Settings[1]);
            if (HandyConfiguration.Settings[0] == null)
                throw new Exception("No DB Connections defined in System Configuration");
            else
                return new SqlConnection(HandyConfiguration.Settings[0]);
                //return new SqlConnection(@"Data Source=NILO-PC; Initial Catalog=ERP;Integrated Security=SSPI;User ID=sa;Password=systemadmin");
        }

        protected SqlConnection GetConnection(string connectionName)
        {
            if (HandyConfiguration.Settings[connectionName] == null)
                throw new Exception(string.Format("Connection Name '{0}' not defined in System Configuration", connectionName));
            else
                return new SqlConnection(HandyConfiguration.Settings[connectionName]);
        }
        
    }
}
