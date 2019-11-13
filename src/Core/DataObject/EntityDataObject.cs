using System;
using System.Data;

using Spring2.Core.Types;

namespace Spring2.Core.DataObject {

    public abstract class EntityDataObject : DataObject, IEntityDataObject {

	private DateType creationDate = DateType.DEFAULT;
	private StringType creationUserName = StringType.DEFAULT;
	private IdType creationUserId = IdType.DEFAULT;
	private DateType lastModifiedDate = DateType.DEFAULT;
	private StringType lastModifiedUserName = StringType.DEFAULT;
	private IdType lastModifiedUserId = IdType.DEFAULT;

	public const String CREATION_USER_ID = "creationUserId";
	public const String CREATION_DATE = "creationDate";
	public const String LAST_MODIFIED_DATE = "lastModifiedDate";
	public const String LAST_MODIFIED_USER_ID = "lastModifiedUserId";
	public const String CREATION_USER_NAME = "creationUserName";
	public const String LAST_MODIFIED_USER_NAME = "lastModifiedUserName";

	public EntityDataObject() {}

	public EntityDataObject(IDataReader reader) {
	    creationDate = new DateType(reader.GetDateTime(reader.GetOrdinal(CREATION_DATE)));
	    creationUserName = StringType.Parse(reader.GetString(reader.GetOrdinal(CREATION_USER_NAME)));
	    creationUserId = new IdType(reader.GetInt32(reader.GetOrdinal(CREATION_USER_ID)));
	    lastModifiedDate = new DateType(reader.GetDateTime(reader.GetOrdinal(LAST_MODIFIED_DATE)));
	    lastModifiedUserName = StringType.Parse(reader.GetString(reader.GetOrdinal(LAST_MODIFIED_USER_NAME)));
	    lastModifiedUserId = new IdType(reader.GetInt32(reader.GetOrdinal(LAST_MODIFIED_USER_ID)));
	}

	public DateType CreationDate {
	    get { return creationDate; }
	    set { creationDate = value; }
	}

	public StringType CreationUserName {
	    get { return creationUserName; }
	    set { creationUserName = value; }
	}

	public IdType CreationUserId {
	    get { return creationUserId; }
	    set { creationUserId = value; }
	}

	public DateType LastModifiedDate {
	    get { return lastModifiedDate; } 
	    set { lastModifiedDate = value; }
	}

	public StringType LastModifiedUserName {
	    get { return lastModifiedUserName; }
	    set { lastModifiedUserName = value; }
	}

	public IdType LastModifiedUserId {
	    get { return lastModifiedUserId; }
	    set { lastModifiedUserId = value; }
	}
    }
}
