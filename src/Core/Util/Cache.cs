using System;
using System.Collections;

namespace Cortside.Core.Util  {

    /// <summary>
    /// Implements a cache mechanism that can cache objects with timeout
    /// in either windows or web environments.
    /// </summary>
    public class Cache : IEnumerable  {

	internal Hashtable cachedItems = new Hashtable();
	private Int32 defaultExpirationMinutes; 
	private Int32 flushFrequencyMinutes;

	private DateTime lastFlushTime = DateTime.Now;

	internal Cache(Int32 defaultExpireMinutes, Int32 flushFrequency) {
	    defaultExpirationMinutes = defaultExpireMinutes;
	    flushFrequencyMinutes = flushFrequency;
	}
    
	public DateTime LastFlushTime{
	    get{return lastFlushTime;}
	}
	public Int32 FlushFrequency{
	    get{return flushFrequencyMinutes;}
	}

	public Object this [Int32 index]{
	    get{
		if (DateTime.Now > this.LastFlushTime.AddMinutes(this.FlushFrequency)){
		    this.Flush();
		}
		CachedItem item = (CachedItem) cachedItems[index];
		return item.Value;
	    }
	    set{
		if (DateTime.Now > this.LastFlushTime.AddMinutes(this.FlushFrequency)){
		    this.Flush();
		}
		CachedItem item = (CachedItem) cachedItems[index];
		item.Value = value;
	    }
	}

	public Object this [Object key]{
	    get{
		if (DateTime.Now > this.LastFlushTime.AddMinutes(this.FlushFrequency)){
		    this.Flush();
		}
		CachedItem item = (CachedItem) cachedItems[key];
		return item.Value;
	    }
	    set{
		if (DateTime.Now > this.LastFlushTime.AddMinutes(this.FlushFrequency)){
		    this.Flush();
		}
		CachedItem item = (CachedItem) cachedItems[key];
		item.Value = value;
	    }
	}

	/// <summary>
	/// COM friendly method since an indexer is not visible for automation
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public Object GetItem(Object key) {
	    return this[key];
	}

	public void AddItem(Object key, Object item){
	    Add(key, item, DateTime.Now.AddMinutes(defaultExpirationMinutes));
	}

	public void Add(Object key, Object item, DateTime expiration){
	    if (DateTime.Now > this.LastFlushTime.AddMinutes(this.FlushFrequency)){
		this.Flush();
	    }
	    CachedItem newItem = new CachedItem(item, expiration);
	    cachedItems.Add(key, newItem);
	}

	/// <summary>
	/// removes (flushes) all expired items using the current time as a reference point
	/// </summary>
	public void Flush(){
	    Flush(DateTime.Now);
	}

	
	/// <summary>
	/// removes all items which expired previous to the passed in cutoff date
	/// </summary>
	/// <param name="olderThan"></param>
	public void Flush(DateTime olderThan){
	    lock (this) {
		ArrayList removedItemKeys = new ArrayList();
		foreach (Object someCacheItemKey in cachedItems.Keys){
		    CachedItem item = (CachedItem)cachedItems[someCacheItemKey];
		    if (item.ExpirationTime < olderThan){
			removedItemKeys.Add(someCacheItemKey);
		    }
		}

		foreach (Object someCacheItemKey in removedItemKeys){
		    cachedItems.Remove(someCacheItemKey);
		}

		lastFlushTime = DateTime.Now;
	    }
	}

	/// <summary>
	/// Clears the cache of all objects without regard to expiration
	/// </summary>
	public void Clear(){
	    lock (this) {
		cachedItems.Clear();
		lastFlushTime = DateTime.Now;
	    }
	}

	public Int32 DefaultExpiration{
	    get {return defaultExpirationMinutes;}
	    set {defaultExpirationMinutes = value;}
	}

	public Boolean ItemExists(Object key){
	    return cachedItems.ContainsKey(key);
	}

	public Int32 Size{
	    get{return cachedItems.Count;}
	}

	public ICollection Keys {
	    get { return cachedItems.Keys; }
	}

	/// <summary>
	/// Returns keys to all of the caches
	/// </summary>
	public ArrayList AllKeys {
	    get { 
		ArrayList keys = new ArrayList();

		foreach(Object o in cachedItems.Keys) {
		    keys.Add(o.ToString());
		}

		return keys;
	    }
	}

	public DateTime MinExpirationTime {
	    get {
		DateTime min = DateTime.MaxValue;
		foreach (Object key in cachedItems.Keys){
		    CachedItem item = (CachedItem)cachedItems[key];
		    if (item.ExpirationTime < min) {
			min = item.ExpirationTime;
		    }
		}

		return min;
	    }
	}

	public DateTime MaxExpirationTime {
	    get {
		DateTime max = DateTime.MinValue;
		foreach (Object key in cachedItems.Keys){
		    CachedItem item = (CachedItem)cachedItems[key];
		    if (item.ExpirationTime > max) {
			max = item.ExpirationTime;
		    }
		}

		return max;
	    }
	}

	#region custom enumerator needed to add enumeration to this hashtable based collection object
	public IEnumerator GetEnumerator() {
	    return new CacheItemEnumerator(this);
	}

	
	class CacheItemEnumerator : IEnumerator {
	    private Int32 incrementor;
	    private Cache targetCollection;
	    public CacheItemEnumerator ( Cache collectionToEnumerate ) {
		incrementor = -1;
		targetCollection = collectionToEnumerate;
	    }

	    public object Current {
		get {
		    return targetCollection.cachedItems[incrementor]; 
		}
	    }

	    public bool MoveNext( ) {
		if (incrementor < targetCollection.cachedItems.Count - 1) {
		    incrementor++;
		    return true;
		}
		else
		    return false;
	    }

	    public void Reset() {
		incrementor = -1;
	    }
	}
	#endregion

    }
}


