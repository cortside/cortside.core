using System;
using System.Collections.Generic;
using Spring2.Core.Types;

namespace Spring2.Core.Reporting {
    public class SqlReportData : Spring2.Core.DataObject.DataObject {
        private StringType reportName = StringType.DEFAULT;
        private StringType displayName = StringType.DEFAULT;
        private StringType parameterName = StringType.DEFAULT;
        private StringType type = StringType.DEFAULT;
        private StringType query = StringType.DEFAULT;
        private IList<KeyValuePair<IntegerType, StringType>> extensionData = new List<KeyValuePair<IntegerType, StringType>>();
        private IntegerType sequence = IntegerType.DEFAULT;

        public static readonly String REPORTNAME = "ReportName";
        public static readonly String DISPLAYNAME = "DisplayName";
        public static readonly String PARAMETERNAME = "ParameterName";
        public static readonly String TYPE = "Type";
        public static readonly String QUERY = "Query";
        public static readonly String SEQUENCE = "Sequence";

        public StringType ReportName {
            get { return this.reportName; }
            set { this.reportName = value; }
        }

        public StringType DisplayName {
            get { return this.displayName; }
            set { this.displayName = value; }
        }

        public StringType ParameterName {
            get { return this.parameterName; }
            set { this.parameterName = value; }
        }

        public StringType Type {
            get { return this.type; }
            set { this.type = value; }
        }

        public StringType Query {
            get { return this.query; }
            set { this.query = value; }
        }

        public IList<KeyValuePair<IntegerType, StringType>> ExtensionData {
            get { return this.extensionData; }
            set { this.extensionData = value; }
        }

        public IntegerType Sequence {
            get { return this.sequence; }
            set { this.sequence = value; }
        }
    }
}
