using System;
using System.Data;
using System.Data.SqlClient;

namespace Spring2.Core.DAO {
    /// <summary>
    /// Summary description for SqlEqualityPredicate.
    /// </summary>
    public class SqlEqualityPredicate : SqlPredicate {
    	
    	private EqualityOperatorEnum _operator;
    	private String columnName;
    	private Object value;
    	private SqlDbType dbType;
		private int length;
		private byte precision;
		private byte scale;
    		
	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Int64 value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.BigInt, 0, 0, 0);
	}
    	
	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Int32 value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.Int, 0, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Int16 value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.SmallInt, 0, 0, 0);
	}
    	
	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, DateTime value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.DateTime, 0, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, String value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.VarChar, 0, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, String value, int length) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.VarChar, length, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Decimal value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.Decimal, 0, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Decimal value, byte precision, byte scale) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.Decimal, 0, precision, scale);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Double value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.Float, 0, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Double value, byte precision, byte scale) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.Float, 0, precision, scale);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Single value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.Real, 0, 0, 0);
	}
    	
	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Boolean value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.Bit, 0, 0, 0);
	}
    	
	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Byte value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.TinyInt, 0, 0, 0);
	}
    	
	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Byte[] value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.Image, 0, 0, 0);
	}
    	
	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Guid value) {
	    SetInternalValues(columnName, _operator, value, SqlDbType.UniqueIdentifier, 0, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, DBNull value) {
	    SetInternalValues(columnName, _operator, null, SqlDbType.Variant, 0, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, DBNull value, int length) {
	    SetInternalValues(columnName, _operator, null, SqlDbType.Variant, length, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, DBNull value, byte precision, byte scale) {
	    SetInternalValues(columnName, _operator, null, SqlDbType.Variant, 0, precision, scale);
	}
	
	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Object value) {
		Init(columnName, _operator, value, 0, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Object value, int length) {
		Init(columnName, _operator, value, length, 0, 0);
	}

	public SqlEqualityPredicate(String columnName, EqualityOperatorEnum _operator, Object value, byte precision, byte scale) {
		Init(columnName, _operator, value, 0, precision, scale);
	}
	
	private void Init(String columnName, EqualityOperatorEnum _operator, Object value, int length, byte precision, byte scale) {
	    if (value is DBNull) {
		SetInternalValues(columnName, _operator, null, SqlDbType.Variant, length, precision, scale);
	    } else if (value is Int64) {
		SetInternalValues(columnName, _operator, value, SqlDbType.BigInt, length, precision, scale);
	    } else if (value is Int32) {
		SetInternalValues(columnName, _operator, value, SqlDbType.Int, length, precision, scale);
	    } else if (value is Int16) {
		SetInternalValues(columnName, _operator, value, SqlDbType.SmallInt, length, precision, scale);
	    } else if (value is DateTime) {
		SetInternalValues(columnName, _operator, value, SqlDbType.DateTime, length, precision, scale);
	    } else if (value is String) {
		SetInternalValues(columnName, _operator, value, SqlDbType.VarChar, length, precision, scale);
	    } else if (value is Decimal) {
		SetInternalValues(columnName, _operator, value, SqlDbType.Decimal, length, precision, scale);
	    } else if (value is Double) {
		SetInternalValues(columnName, _operator, value, SqlDbType.Float, length, precision, scale);
	    } else if (value is Single) {
		SetInternalValues(columnName, _operator, value, SqlDbType.Real, length, precision, scale);
	    } else if (value is Boolean) {
		SetInternalValues(columnName, _operator, value, SqlDbType.Bit, length, precision, scale);
	    } else if (value is Byte) {
		SetInternalValues(columnName, _operator, value, SqlDbType.TinyInt, length, precision, scale);
	    } else if (value is Byte[]) {
		SetInternalValues(columnName, _operator, value, SqlDbType.Image, length, precision, scale);
	    } else if (value is Guid) {
		SetInternalValues(columnName, _operator, value, SqlDbType.UniqueIdentifier, length, precision, scale);
	    } else {
	    	throw new ArgumentException(value.GetType().ToString() + " is not an allowed type");
	    }
	}		
    	
    	private void SetInternalValues(String columnName, EqualityOperatorEnum _operator, Object value, SqlDbType dbType, int length, byte precision, byte scale) {
	    this.columnName = columnName;
	    this._operator = _operator;
	    this.value = value;
	    this.dbType = dbType;
		this.length = length;
		this.precision = precision;
		this.scale = scale;
    	}

	public override String Expression {
	    get {
		if (_operator.Equals(EqualityOperatorEnum.Equal) && value == null) {
		    return String.Format("({0} IS NULL)", Escape(columnName));
		} else if (_operator.Equals(EqualityOperatorEnum.NotEqual) && value == null) {
		    return String.Format("({0} IS NOT NULL)", Escape(columnName));
		} else {
		    return String.Format("({0} {1} @{2})", Escape(columnName), GetSqlOperator(_operator), ReplaceSpecialCharacters(columnName).Replace(".", "_"));
		}
	    }
	}

	public override IDataParameterCollection Parameters {
	    get {
		SqlParameterList parameters = new SqlParameterList();
		if (_operator.Equals(EqualityOperatorEnum.Equal) && value == null) {
		    // do not add parameter
		} else if (_operator.Equals(EqualityOperatorEnum.NotEqual) && value == null) {
		    // do not add parameter
		} else {
			SqlParameter param = new SqlParameter("@" + ReplaceSpecialCharacters(columnName).Replace(".","_"), value);
		    param.SqlDbType = dbType;
			if (length > 0) {
				param.Size = length;
			}
			if (precision > 0) {
				param.Precision = precision;
			}
			if (scale > 0) {
				param.Scale = scale;
			}

		    parameters.Add(param);
		}
		return parameters;
	    }
	}

	private String GetSqlOperator(EqualityOperatorEnum op) {
	    switch (op) {
	    	case EqualityOperatorEnum.Equal :
	    	    return "=";
		case EqualityOperatorEnum.NotEqual :
		    return "<>";
	    	case EqualityOperatorEnum.LessThan :
	    	    return "<";
	    	case EqualityOperatorEnum.LessThanOrEqual :
	    	    return "<=";
	    	case EqualityOperatorEnum.GreaterThan :
	    	    return ">";
	    	case EqualityOperatorEnum.GreaterThanOrEqual :
	    	    return ">=";
	    	case EqualityOperatorEnum.Like :
	    	    return "LIKE";
	    	case EqualityOperatorEnum.NotLike :
	    	    return "NOT LIKE";
		default:
		    throw new ArgumentOutOfRangeException();
	    }
	}
    }
}
