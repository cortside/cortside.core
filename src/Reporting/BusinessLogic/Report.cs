using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Cortside.Core.DAO;
using Cortside.Core.Types;

namespace Cortside.Core.Reporting {
    public class Report {
        private Report() {
        }

        private static IList<String> NumericDbTypes = new List<String>() {
            "bigint", "bit", "decimal", "int", "money", "numeric", "smallint", "smallmoney", "tinyint", "float", "real"
        };

        public static IList GetISqlReports(StringType prefix) {
            return SqlSchemaDAO.GetSqlObjects(new WhereClause("type='P' and name like '" + prefix.ToString() + "%'"), new OrderByClause("Name"));
        }

        public static IList GetISqlReportArguments(StringType sqlObject) {
            return GetISqlReportArgumentList(sqlObject) as IList;
        }

        public static IList<SqlColumnData> GetISqlReportArgumentList(StringType sqlObject) {
            return SqlSchemaDAO.GetSqlColumns(new WhereClause("SqlObject", sqlObject.ToString()), new OrderByClause("OrdinalPosition"));
        }

        public static IList<SqlReportData> GetISqlReportArgumentListWithExtensionData(StringType sqlObject) {
            return SqlSchemaDAO.GetSqlReportData(new WhereClause("ReportName", sqlObject.ToString()), null);
        }

        public static SqlDataReader ExecuteISqlReport(StringType sqlObject, Dictionary<string, object> args) {
            string sql = BuildExecuteSqlStatement(sqlObject, args);
            return SqlSchemaDAO.ExecuteReader(sql);
        }

        public static SqlDataReader ExecuteISqlReport(StringType sqlObject, Hashtable args) {
            string sql = BuildExecuteSqlStatement(sqlObject, args);
            return SqlSchemaDAO.ExecuteReader(sql);
        }

        private static string BuildExecuteSqlStatement(StringType sqlObject, IDictionary args) {
            String sql = String.Empty;
            bool isNumeric;

            IEnumerable<SqlColumnData> columns = GetISqlReportArgumentList(sqlObject);
            SqlColumnData tempColumn = null;

            foreach (DictionaryEntry arg in args) {
                if (!sql.Equals(String.Empty)) {
                    sql += ", ";
                }

                if (string.IsNullOrEmpty(arg.Value as string)) {
                    sql += arg.Key.ToString() + "=null";
                    continue;
                }

                tempColumn = columns.FirstOrDefault(c => string.Equals(c.Name, arg.Key as string, StringComparison.CurrentCultureIgnoreCase));
                isNumeric = tempColumn != null && NumericDbTypes.Any(t => string.Equals(t, tempColumn.Type, StringComparison.CurrentCultureIgnoreCase));

                if (!isNumeric) {
                    sql += arg.Key.ToString() + "='" + arg.Value.ToString() + "'";
                } else {
                    sql += arg.Key.ToString() + "=" + arg.Value.ToString();
                }
            }

            sql = "exec " + sqlObject + " " + sql;
            return sql;
        }
    }
}
