using System;

using Spring2.Core.Types;

namespace Spring2.Core.Reporting {
    public class SqlObjectData : Spring2.Core.DataObject.DataObject {

        private StringType name = StringType.DEFAULT;
        private StringType type = StringType.DEFAULT;

        public static readonly String NAME = "Name";
        public static readonly String TYPE = "Type";

        public StringType Name {
            get { return this.name; }
            set { this.name = value; }
        }

        public StringType Type {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
