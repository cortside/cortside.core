using System;

namespace Cortside.Core.BusinessEntity {

    [Serializable]
    public abstract class BusinessEntity : Cortside.Core.DataObject.DataObject, IBusinessEntity {

        protected Boolean isNew = true;

        public Boolean IsNew {
            get {
                return this.isNew;
            }
        }
    }
}
