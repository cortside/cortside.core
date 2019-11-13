using System;

namespace Spring2.Core.BusinessEntity {

    [Serializable]
    public abstract class BusinessEntity : Spring2.Core.DataObject.DataObject, IBusinessEntity {

        protected Boolean isNew = true;

        public Boolean IsNew {
            get {
                return this.isNew;
            }
        }
    }
}
