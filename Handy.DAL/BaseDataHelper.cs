using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace DataHelper
{
    public class BaseDataHelper : IDisposable
    {
        private const int BatchSize = 10;
        private SqlConnection dbConn;
        private SqlTransaction trans;
        private string _CallingTerminal = String.Empty;
        private bool _IsExecuting;

        #region Protected

        protected enum DataSourceType
        {
            SQLServer = 0
        }
        protected DataSourceType _DataSourceType;
        protected SqlConnection _Connection;

        protected SqlTransaction _Transaction;
        

        public BaseDataHelper()
        {
            this._Connection = this.GetConnection();
        }

        public void OpenDB()
        {
            if (this._Connection.State == ConnectionState.Closed)
                this._Connection.Open();  
        }

        public void CloseDB()
        {
            if (this._Connection.State == ConnectionState.Open)
                this._Connection.Close();
        }

        #endregion

        public void BeginTransaction()
        {
            if (this._Transaction == null)
                this._Transaction = this._Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this._Transaction.Commit();
            this._Transaction = null;
        }

        public void RollBackTransaction()
        {
            this._Transaction.Rollback();
            this._Transaction = null;
        }

        public void BeginTransactionSnapshot()
        {
            if (this._Transaction == null)
            {
                this._Transaction = this._Connection.BeginTransaction(IsolationLevel.Snapshot);

            }
        }

        public void CommitTransactionSnapshot()
        {
            this._Transaction.Commit();
        }

        public void RollBackTransactionSnapshot()
        {
            this._Transaction.Rollback();
        }

        public void Dispose()
        {
            try
            {
                if (_Connection != null)
                {
                    if (_Connection.State != ConnectionState.Closed)
                        _Connection.Close();

                    _Connection.Dispose();
                }
            }
            catch
            {
                
            }
        }

        //public int ExecuteNonQuery(string dbStatement)
        //{
        //    SqlCommand Command = this._Connection.CreateCommand();
        //    Command.CommandTimeout = 0;
        //    Command.CommandText = dbStatement;
        //    Command.CommandType = CommandType.Text;

        //    return Command.ExecuteNonQuery();
        //}

        public int ExecuteNonQuery(string dbStatement)
        {
            return this.ExecuteNonQuery(dbStatement, null);
        }

        public int ExecuteNonQuery(string dbStatement, params object[] paramValues)
        {
            string[] rawParameters = dbStatement.Split('@');
            ParameterInfo[] dbParameters = new ParameterInfo[paramValues.Length];

            int index = -1;
            foreach (string rawParameter in rawParameters)
            {
                if (index > -1)
                {
                    dbParameters[index] = new ParameterInfo(rawParameter.Substring(0, rawParameter.IndexOf(' ') == -1 ? rawParameter.Length : rawParameter.IndexOf(' ')), paramValues[index]);

                    if (index == paramValues.Length)
                        break;
                }
                index++;
            }

            return this.ExecuteNonQuery(dbStatement, dbParameters);
        }

        public int ExecuteNonQuery(string dbStatement, params ParameterInfo[] dbParameters)
        {
            SqlCommand Command = this._Connection.CreateCommand();
            Command.CommandTimeout = 0;
            Command.CommandText = dbStatement;
            Command.CommandType = CommandType.Text;

            if (this._Transaction != null)
                Command.Transaction = this._Transaction;

            if (dbParameters != null)
                foreach (ParameterInfo dbParameterInfo in dbParameters)
                {
                    SqlParameter dbParameter = Command.CreateParameter();
                    dbParameter.ParameterName = dbParameterInfo.Name;
                    dbParameter.Value = dbParameterInfo.Value;
                    dbParameter.DbType = dbParameterInfo.Type;
                    dbParameter.Size = dbParameterInfo.Size;

                    Command.Parameters.Add(dbParameter);
                }

            return Command.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string dbStatement)
        {
            SqlCommand Command = this._Connection.CreateCommand();
            Command.CommandTimeout = 0;
            Command.CommandText = dbStatement;
            Command.CommandType = CommandType.Text;

            SqlDataReader DataReader;
            DataReader = Command.ExecuteReader();
            //DataReader.Read();

            return DataReader;
        }

        public DataTable ExecuteDataTable(string dbStatement)
        {
            DataTable dt = new DataTable();
            
            SqlCommand Command = this._Connection.CreateCommand();
            Command.CommandTimeout = 0;
            Command.CommandText = dbStatement;
            Command.CommandType = CommandType.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = Command;
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

        #region Sql Dataset retreival modified by nilo

        //#region executeDataSet

        //public DataSet ExecuteDataSet(string sqlStatement)
        //{
        //    return this.ExecuteDataSet(sqlStatement, CommandType.Text, null);
        //}

        //public DataSet ExecuteDataSet(string sqlStatement, CommandType cmdType)
        //{
        //    return this.ExecuteDataSet(sqlStatement, cmdType, null);
        //}

        //public DataSet ExecuteDataSet(string sqlStatement, CommandType cmdType, ParameterInfo[] paramCol)
        //{
        //    _IsExecuting = true;
        //    DataSet dataSet = new DataSet();
        //    SqlCommand cmd = this.dbConn.CreateCommand();
        //    cmd.CommandTimeout = 0;
        //    cmd.CommandText = sqlStatement;
        //    cmd.CommandType = cmdType;

        //    if (this.trans != null)
        //        cmd.Transaction = this.trans;

        //    if (paramCol != null)
        //    {
        //        foreach (ParameterInfo prmInfo in paramCol)
        //        {
        //            SqlParameter prm = new SqlParameter();

        //            prm.ParameterName = prmInfo.Name;
        //            prm.SqlDbType = prmInfo.DataType;
        //            prm.Size = prmInfo.Size;
        //            prm.Value = prmInfo.Value;
        //            prm.Direction = prmInfo.Direction;

        //            cmd.Parameters.Add(prm);
        //        }
        //    }

        //    SqlDataAdapter adapter = new SqlDataAdapter();
        //    adapter.SelectCommand = cmd;
        //    adapter.Fill(dataSet);

        //    //arthur added 20070121 start
        //    //code below will trim all text fields 
        //    foreach (DataTable dt in dataSet.Tables)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            for (int i = 0; i < dt.Columns.Count; i++)
        //            {
        //                if (dt.Columns[i].DataType == Type.GetType("System.String", true))
        //                    row[i] = row[i].ToString().TrimEnd();
        //            }
        //        }
        //    }
        //    //end
        //    _IsExecuting = false;
        //    return dataSet;
        //}

        //#endregion//executeDataSet

        #endregion

        #region commented Dataset Retreival by lester
        public DataSet ExecuteDataSet(string dbStatement)
        {
            return this.ExecuteDataSet(dbStatement, null);
        }

        public DataSet ExecuteDataSet(string dbStatement, params object[] paramValues)
        {
            string[] rawParameters = dbStatement.Split('@');
            ParameterInfo[] dbParameters = new ParameterInfo[paramValues.Length];

            int index = -1;
            foreach (string rawParameter in rawParameters)
            {
                if (index > -1)
                {
                    dbParameters[index] = new ParameterInfo(rawParameter.Substring(0, rawParameter.IndexOf(' ') == -1 ? rawParameter.Length : rawParameter.IndexOf(' ')), paramValues[index]);

                    if (index == paramValues.Length)
                        break;
                }
                index++;
            }

            return this.ExecuteDataSet(dbStatement, dbParameters);
        }

        public DataSet ExecuteDataSet(string dbStatement, params ParameterInfo[] dbParameters)
        {
            DataSet value = new DataSet();

            SqlCommand Command = this._Connection.CreateCommand();
            Command.CommandTimeout = 0;
            Command.CommandText = dbStatement;
            Command.CommandType = CommandType.Text;

            if (this._Transaction != null)
                Command.Transaction = this._Transaction;


            if (dbParameters != null)
                foreach (ParameterInfo dbParameterInfo in dbParameters)
                {
                    SqlParameter dbParameter = Command.CreateParameter();
                    dbParameter.ParameterName = dbParameterInfo.Name;
                    dbParameter.Value = dbParameterInfo.Value;
                    dbParameter.DbType = dbParameterInfo.Type;
                    dbParameter.Size = dbParameterInfo.Size;

                    Command.Parameters.Add(dbParameter);
                }
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = Command;
            adapter.Fill(value);

            foreach (DataTable table in value.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (table.Columns[i].DataType == Type.GetType("System.String", true))
                            row[i] = row[i].ToString().TrimEnd();
                    }
                }
            }

            return value;
        }
        #endregion

        #region private

        private SqlConnection GetConnection()
        {
            string connectionString = HandyConfiguration.Settings["ERPDB"];

            return new SqlConnection(connectionString);
        }


        #endregion //private
    }
}
