using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System;

namespace Spring2.Core.DAO {
    public class ColumnMetaData {
	private string name = "";
	private string sqlName = "";
	private DbType dbType = DbType.Int32;
	private SqlDbType sqlDBType = SqlDbType.Int;
	private int length = 0;
	private byte precision = 0;
	private byte scale = 0;

	public ColumnMetaData(string name, string sqlName, DbType dbType, SqlDbType sqlDBType, int length, byte precision,
			      byte scale) {
	    this.name = name;
	    this.sqlName = sqlName;
	    this.dbType = dbType;
	    this.sqlDBType = sqlDBType;
	    this.length = length;
	    this.precision = precision;
	    this.scale = scale;
	}

	public string Name {
	    get { return name; }
	}

	public string SqlName {
	    get { return sqlName; }
	}

	public DbType DBType {
	    get { return dbType; }
	}

	public SqlDbType SQLDBType {
	    get { return sqlDBType; }
	}

	public int Length {
	    get { return length; }
	}

	public byte Precision {
	    get { return precision; }
	}

	public byte Scale {
	    get { return scale; }
	}
    }
}
