using System;

using Spring2.Core.Types;

namespace Spring2.Core.DataObject {

    public interface IEntityDataObject {

	DateType CreationDate {
	    get;
	    set;
	}

	StringType CreationUserName {
	    get;
	    set;
	}

	IdType CreationUserId {
	    get;
	    set;
	}

	DateType LastModifiedDate {
	    get;
	    set;
	}

	StringType LastModifiedUserName {
	    get;
	    set;
	}

	IdType LastModifiedUserId {
	    get;
	    set;
	}
    }
}
