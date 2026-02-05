using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.ComponentModel;

namespace DataHelper
{
    public class SQLDataHelper : BaseDataHelper
    {
        public SQLDataHelper()
        {
            base._DataSourceType = DataSourceType.SQLServer;
            base._Connection = GetConnection();
        }

        public SQLDataHelper(string connectionName)
        {
            base._DataSourceType = DataSourceType.SQLServer;
            base._Connection = GetConnection(connectionName);
        }
        
        /// <summary>
        /// Returns new instance of SQL connection using the first connection string found in App.config file.
        /// </summary>
        /// <returns>The new instance of SqlConnection class.</returns>
        protected SqlConnection GetConnection()
        {
            
            if (HandyConfiguration.Settings[0] == null)
                throw new Exception("No DB Connections defined in System Configuration");
            else
                return new SqlConnection(HandyConfiguration.Settings[0]);
        }

        /// <summary>
        /// Returns new instance of SQL connection using the named connection string found in App.config file.
        /// </summary>
        /// <param name="connectionName">The named connection string.</param>
        /// <returns>The new instance of SqlConnection class.</returns>
        protected SqlConnection GetConnection(string connectionName)
        {
            if (HandyConfiguration.Settings[connectionName] == null)
                throw new Exception(string.Format("Connection Name '{0}' not defined in System Configuration", connectionName));
            else
                return new SqlConnection(HandyConfiguration.Settings[connectionName]);
        }
        
    }
}
