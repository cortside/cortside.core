using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Spring2.Core.DAO {
    /// <summary>
    /// Summary description for SqlParameterCollection.
    /// </summary>
    public class SqlParameterList : CollectionBase, IDataParameterCollection {

        // Indexer implementation.
        public SqlParameter this[int index] {
            get { return (SqlParameter)List[index]; }
            set {
                List[index] = value;
            }
        }

        public void Add(String parameterName, SqlDbType dbType, Object value) {
            SqlParameter parameter = new SqlParameter(parameterName, dbType);
            parameter.Value = value;
            List.Add(parameter);
        }

        public void Add(SqlParameter value) {
            List.Add(value);
        }

        public Boolean Contains(SqlParameter value) {
            return List.Contains(value);
        }

        public Int32 IndexOf(SqlParameter value) {
            return List.IndexOf(value);
        }

        public void Insert(Int32 index, SqlParameter value) {
            List.Insert(index, value);
        }

        public void Remove(int index) {
            if (index > Count - 1 || index < 0) {
                throw new IndexOutOfRangeException();
            } else {
                List.RemoveAt(index);
            }
        }

        public void Remove(SqlParameter value) {
            List.Remove(value);
        }

        public void AddRange(System.Collections.IList list) {
            foreach (Object o in list) {
                if (o is SqlParameter) {
                    Add((SqlParameter)o);
                } else {
                    throw new System.InvalidCastException("object in list could not be cast to SqlParameter");
                }
            }
        }
        #region IDataParameterCollection Members

        object System.Data.IDataParameterCollection.this[string parameterName] {
            get {
                foreach (SqlParameter o in List) {
                    if (o.ParameterName.Equals(parameterName)) {
                        return o;
                    }
                }

                // not found
                return null;
            }
            set {
                // TODO:  Add SqlParameterList.System.Data.IDataParameterCollection.this setter implementation
            }
        }

        public void RemoveAt(string parameterName) {
            // TODO:  Add SqlParameterList.RemoveAt implementation
        }

        bool System.Data.IDataParameterCollection.Contains(string parameterName) {
            foreach (SqlParameter o in List) {
                if (o.ParameterName.Equals(parameterName)) {
                    return true;
                }
            }

            // not found
            return false;
        }

        int System.Data.IDataParameterCollection.IndexOf(string parameterName) {
            for (Int32 i = 0; i < List.Count; i++) {
                SqlParameter o = List[i] as SqlParameter;
                if (o.ParameterName.Equals(parameterName)) {
                    return i;
                }
            }

            // not found
            return -1;
        }

        #endregion
    }
}
