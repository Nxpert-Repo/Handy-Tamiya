using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CEDataHelper
{
    public class CEParameterInfo
    {
        string _Name = string.Empty;
        object _Value = DBNull.Value;
        SqlDbType _Type = SqlDbType.VarChar;
        int _Size = 50;

        public string Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }
        public object Value
        {
            get { return this._Value; }
            set { this._Value = value; }
        }

        public SqlDbType Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }

        public int Size
        {
            get { return this._Size; }
            set { this._Size = value; }
        }

        public CEParameterInfo(string paramName)
            : this(paramName, DBNull.Value, SqlDbType.VarChar, 50)
        { }

        public CEParameterInfo(string paramName, object paramValue)
            : this(paramName, paramValue, SqlDbType.VarChar, 50)
        { }

        public CEParameterInfo(string paramName, SqlDbType paramType)
            : this(paramName, DBNull.Value, paramType, 50)
        { }

        public CEParameterInfo(string paramName, object paramValue, SqlDbType paramType, int paramSize)
        {
            this.Name = paramName;
            this.Value = paramValue;
            this.Type = paramType;
            this.Size = paramSize;
        }

    }
}
