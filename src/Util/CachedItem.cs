using System;

namespace Spring2.Core.Util {
    /// <summary>
    /// Summary description for CachedItem.
    /// </summary>
    public class CachedItem {
	private Object cachedValue;
	private DateTime expirationTime;


	public CachedItem(Object cacheItemValue, DateTime expireTime) {
	    cachedValue = cacheItemValue;
	    expirationTime = expireTime;
	}

	public DateTime ExpirationTime{
	    get{return expirationTime;}
	    set{expirationTime = value;}
	}
	
	public Object Value{
	    get {return cachedValue;}
	    set{cachedValue = value;}
	}



	
    }
}
