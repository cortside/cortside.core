using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cortside.Core.DAO;
using Cortside.Core.Types;

namespace Cortside.Core.Reporting {
    public class SqlSchemaDAO : Cortside.Core.DAO.SqlEntityDAO {

        private static readonly String CONNECTION_STRING_KEY = "ConnectionString";
        private static readonly Int32 COMMAND_TIMEOUT = 300;

        protected override String ConnectionStringKey {
            get {
                return CONNECTION_STRING_KEY;
            }
        }

        private static SqlObjectData GetSqlObjectDataFromReader(SqlDataReader dataReader) {
            SqlObjectData data = new SqlObjectData();
            if (dataReader.IsDBNull(dataReader.GetOrdinal("Name"))) {
                data.Name = StringType.UNSET;
            } else {
                data.Name = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("Name")));
            }
            if (dataReader.IsDBNull(dataReader.GetOrdinal("Type"))) {
                data.Type = StringType.UNSET;
            } else {
                data.Type = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("Type")));
            }

            return data;
        }

        private static SqlColumnData GetSqlColumnDataFromReader(SqlDataReader dataReader) {
            SqlColumnData data = new SqlColumnData();
            if (dataReader.IsDBNull(dataReader.GetOrdinal("Name"))) {
                data.Name = StringType.UNSET;
            } else {
                data.Name = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("Name")));
            }
            if (dataReader.IsDBNull(dataReader.GetOrdinal("Type"))) {
                data.Type = StringType.UNSET;
            } else {
                data.Type = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("Type")));
            }
            if (dataReader.IsDBNull(dataReader.GetOrdinal("SqlObject"))) {
                data.SqlObject = StringType.UNSET;
            } else {
                data.SqlObject = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("SqlObject")));
            }

            return data;
        }

        private static SqlReportData GetSqlReportDataFromReader(SqlDataReader dataReader) {
            SqlReportData data = new SqlReportData();
            if (dataReader.IsDBNull(dataReader.GetOrdinal("ReportName"))) {
                data.ReportName = StringType.UNSET;
            } else {
                data.ReportName = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("ReportName")));
            }
            if (dataReader.IsDBNull(dataReader.GetOrdinal("DisplayName"))) {
                data.DisplayName = StringType.UNSET;
            } else {
                data.DisplayName = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("DisplayName")));
            }
            if (dataReader.IsDBNull(dataReader.GetOrdinal("ParameterName"))) {
                data.ParameterName = StringType.UNSET;
            } else {
                data.ParameterName = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("ParameterName")));
            }
            if (dataReader.IsDBNull(dataReader.GetOrdinal("Type"))) {
                data.Type = StringType.UNSET;
            } else {
                data.Type = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("Type")));
            }
            if (dataReader.IsDBNull(dataReader.GetOrdinal("Query"))) {
                data.Query = StringType.UNSET;
            } else {
                data.Query = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("Query")));
                using (IDataReader queryDataReader = (new SqlSchemaDAO()).ExecuteReader(CONNECTION_STRING_KEY, data.Query)) {
                    while (queryDataReader.Read()) {
                        data.ExtensionData.Add(ReadExtensionData(queryDataReader));
                    }
                }
            }
            if (dataReader.IsDBNull(dataReader.GetOrdinal("Sequence"))) {
                data.Sequence = IntegerType.DEFAULT;
            } else {
                data.Sequence = new IntegerType(dataReader.GetInt32(dataReader.GetOrdinal("Sequence")));
            }
            return data;
        }

        private static KeyValuePair<IntegerType, StringType> ReadExtensionData(IDataReader dataReader) {
            IntegerType id = IntegerType.DEFAULT;
            StringType value = StringType.DEFAULT;
            if (dataReader.IsDBNull(dataReader.GetOrdinal("Id"))) {
                id = IntegerType.UNSET;
            } else {
                id = new IntegerType(dataReader.GetInt32(dataReader.GetOrdinal("Id")));
            }
            if (dataReader.IsDBNull(dataReader.GetOrdinal("Name"))) {
                value = StringType.UNSET;
            } else {
                value = StringType.Parse(dataReader.GetString(dataReader.GetOrdinal("Name")));
            }
            return new KeyValuePair<IntegerType, StringType>(id, value);
        }

        public static IList GetSqlObjects(IWhere whereClause, IOrderBy orderByClause) {
            SqlDataReader dataReader = (SqlDataReader)(new SqlSchemaDAO().GetListReader(CONNECTION_STRING_KEY, "vwSqlObject", whereClause, orderByClause));

            ArrayList list = new ArrayList();
            while (dataReader.Read()) {
                list.Add(GetSqlObjectDataFromReader(dataReader));
            }
            dataReader.Close();
            return list;
        }

        public static IList<SqlColumnData> GetSqlColumns(IWhere whereClause, IOrderBy orderByClause) {
            SqlDataReader dataReader = (SqlDataReader)(new SqlSchemaDAO().GetListReader(CONNECTION_STRING_KEY, "vwSqlColumn", whereClause, orderByClause));

            IList<SqlColumnData> list = new List<SqlColumnData>();
            while (dataReader.Read()) {
                list.Add(GetSqlColumnDataFromReader(dataReader));
            }
            dataReader.Close();
            return list;
        }

        public static IList<SqlReportData> GetSqlReportData(IWhere whereClause, IOrderBy orderByClause) {
            SqlDataReader dataReader = (SqlDataReader)(new SqlSchemaDAO().GetListReader(CONNECTION_STRING_KEY, "vwReportArgument", whereClause, orderByClause));

            IList<SqlReportData> list = new List<SqlReportData>();
            while (dataReader.Read()) {
                list.Add(GetSqlReportDataFromReader(dataReader));
            }
            dataReader.Close();
            return list;
        }

        public static SqlDataReader ExecuteReader(String sql) {
            SqlDataReader reader = (SqlDataReader)(new SqlSchemaDAO().ExecuteReader(CONNECTION_STRING_KEY, sql, COMMAND_TIMEOUT));
            return reader;
        }

    }
}