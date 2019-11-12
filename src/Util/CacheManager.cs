using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Spring2.Core.Util {
    /// <summary>
    /// Summary description for CacheManager.
    /// </summary>
    [GuidAttribute("795E05E0-3C1F-4165-99E8-61998ADFA60F")]
    public class CacheManager {
	internal static Hashtable caches = new Hashtable();
	

	//new caches and cache items not given an expiration date will expire this many minutes 
	//	from when they were created
	private const Int32 DEFAULT_EXPIRATION_MINUTES = 240; 

	//if a flush frequency is not supplied for a cache then the default will be this many minutes. 
	//Flushing is the act of removing expired cache items.
	private const Int32 DEFAULT_FLUSH_FREQUENCY_MINUTES = 3;  

	static CacheManager() {
	    //this would be where you start a timer to control flushing
	}

	public CacheManager() {
	    // use MDC to set the hostname for log messages -- MDC is thread specific
	    // TODO: can this be done by probing for log4net?
	    System.Reflection.Assembly _log4net;
	    try {
		_log4net = System.Reflection.Assembly.Load("log4net");
		System.Runtime.Remoting.ObjectHandle mdc =  AppDomain.CurrentDomain.CreateInstance("log4net", "log4net.MDC");
		Type type = Type.GetType("log4net.MDC");
		System.Reflection.MethodInfo method = type.GetMethod("Set", Type[]{typeof(String), typeof(String)});
	    	//log4net.MDC.Set("hostname", Environment.MachineName);
	    } catch(Exception) {
		// could not load log4net, don't worry about it
	    }
	}

	public static void CreateCache(Object key, Int32 defaultExpiration, Int32 flushFrequencyMinutes){
	    caches.Add(key, new Cache(defaultExpiration, flushFrequencyMinutes));
	}
	public static void CreateCache(Object key, Int32 defaultExpiration){
	    CreateCache(key, defaultExpiration, DEFAULT_FLUSH_FREQUENCY_MINUTES);
	}

	public static void CreateCache(Object key){
	    CreateCache(key, DEFAULT_EXPIRATION_MINUTES, DEFAULT_FLUSH_FREQUENCY_MINUTES);
	
	}


	public static void FlushExpiredCacheItems(){
	    foreach(Object someCacheKey in caches.Keys){
		Cache someCache = (Cache) caches[someCacheKey];
		//if the current time is greater than the last flush time + frequency then flush
		if (DateTime.Now > someCache.LastFlushTime.AddMinutes(someCache.FlushFrequency)){
		    someCache.Flush();
		}
	    }
	}

	public static Boolean CacheExists(Object key){
	    return caches.ContainsKey(key);
	}

	public static Cache GetCache(Object key){
	    return (Cache)caches[key];
	}
	
	public static Int32 Size{
	    get{return caches.Count;}
	}

	/// <summary>
	/// Returns keys to all of the caches
	/// </summary>
	public static ICollection Keys {
	    get { return caches.Keys; }
	}

	#region COM friendly methods
	public Cache GetCacheFromKeyString(String key){
	    return (Cache)caches[key];
	}

	public Boolean CacheExistsForKeyString(String key){
	    return caches.ContainsKey(key);
	}
	public void CreateCacheUsingKeyString(String key, Int32 defaultExpiration, Int32 flushFrequencyMinutes){
	    CreateCache(key, defaultExpiration, flushFrequencyMinutes);
	}

	/// <summary>
	/// Returns keys to all of the caches
	/// </summary>
	public ArrayList AllKeys {
	    get { 
		ArrayList keys = new ArrayList();

		foreach(Object o in caches.Keys) {
		    keys.Add(o.ToString());
		}

		return keys;
	    }
	}

	public Int32 CacheSize {
	    get{ return caches.Count; }
	}

	public void FlushAllCaches(){
	    FlushAll();
	}

	public void ClearAllCaches(){
	    ClearAll();
	}
	#endregion

	public static void FlushAll(){
	    foreach(Object someCacheKey in caches.Keys){
		Cache someCache = (Cache) caches[someCacheKey];
		someCache.Flush();
	    }
	}

	public static void ClearAll(){
	    foreach(Object someCacheKey in caches.Keys){
		Cache someCache = (Cache) caches[someCacheKey];
		someCache.Clear();
	    }
	}

    }

}
