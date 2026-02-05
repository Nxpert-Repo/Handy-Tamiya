using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.ComponentModel;
using DataHelper;

namespace CEDataHelper
{
    public class CESQLDataHelper : CEBaseDataHelper
    {
        public CESQLDataHelper()
        {
            base._DataSourceType = DataSourceType.SQLCeServer;
            base._Connection = GetConnection();
        }

        public CESQLDataHelper(string connectionName)
        {
            base._DataSourceType = DataSourceType.SQLCeServer;
            base._Connection = GetConnection(connectionName);
        }

        /// <summary>
        /// Returns new instance of SQL CE connection using the second connection string found in App.config file.
        /// </summary>
        /// <returns>The new instance of SqlCeConnection class.</returns>
        protected SqlCeConnection GetConnection()
        {
            if (HandyConfiguration.Settings[1] == null)
                throw new Exception("No DB Connections defined in System Configuration");
            else
                return new SqlCeConnection(HandyConfiguration.Settings[1]);
        }

        /// <summary>
        /// Returns new instance of SQL CE connection using the named connection string found in App.config file.
        /// </summary>
        /// <param name="connectionName">The named connection string.</param>
        /// <returns>The new instance of SqlCeConnection class.</returns>
        protected SqlCeConnection GetConnection(string connectionName)
        {
            if (HandyConfiguration.Settings[connectionName] == null)
                throw new Exception(string.Format("Connection Name '{0}' not defined in System Configuration", connectionName));
            else
                return new SqlCeConnection(HandyConfiguration.Settings[connectionName]);
        }
        
    }
}
