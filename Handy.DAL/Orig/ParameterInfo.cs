using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace DataHelper
{
    public class ParameterInfo
    {
        string _Name = string.Empty;
        object _Value = DBNull.Value;
        DbType _Type = DbType.String;
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

        public DbType Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }

        public int Size
        {
            get { return this._Size; }
            set { this._Size = value; }
        }

        public ParameterInfo(string paramName)
            : this(paramName, DBNull.Value, DbType.String, 50)
        { }

        public ParameterInfo(string paramName, object paramValue)
            : this(paramName, paramValue, DbType.String, 50)
        { }

        public ParameterInfo(string paramName, DbType paramType)
            : this(paramName, DBNull.Value, paramType, 50)
        { }

        public ParameterInfo(string paramName, object paramValue, DbType paramType, int paramSize)
        {
            this.Name = paramName;
            this.Value = paramValue;
            this.Type = paramType;
            this.Size = paramSize;
        }

    }
}
