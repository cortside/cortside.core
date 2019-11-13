using System;
using System.Collections.Specialized;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Cortside.Core.DAO {
    public class DefaultConnectionStringStrategy : IConnectionStringStrategy {
        private static StringDictionary connectionStrings = new StringDictionary();
        public String GetConnectionString(String key) {

            String connectionString;

            lock (connectionStrings.SyncRoot) {
                // look to see if the connection string has already been cached
                if (connectionStrings[key] != null) {
                    return connectionStrings[key];
                }

                //if (key.ToLower().StartsWith("registry")) {
                //    String subkey = key.Substring(key.LastIndexOf(":") + 1);
                //    subkey = subkey.Substring(0, subkey.LastIndexOf("\\"));
                //    String value = key.Substring(key.LastIndexOf("\\") + 1);
                //    String hive = key.Substring(9, 4).ToUpper();
                //    RegistryKey rkey;
                //    if (hive.Equals("HKLM")) {
                //        rkey = Registry.LocalMachine.OpenSubKey(subkey);
                //    } else if (hive.Equals("HKCU")) {
                //        rkey = Registry.CurrentUser.OpenSubKey(subkey);
                //    } else {
                //        throw new Exception("Unable to determine hive from registry type connection key.  Hive understood: " + hive + "  Key used was: " + key);
                //    }
                //    if (rkey == null) {
                //        throw new Exception("Specified subkey was not found.  Subkey: " + subkey);
                //    }
                //    connectionString = rkey.GetValue(value).ToString();
                //} else if (ConfigurationManager.ConnectionStrings[key] != null) {
                //    connectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;
                //} else {
                //    connectionString = ConfigurationManager.AppSettings[key];
                //}

                // TODO: this is not right -- can't assume that config files will always be json and named this -- need to get to IConfiguration or IConfigurationRoot somehow
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                var config = builder.Build();
                connectionString = config.GetConnectionString(key);

                // Cache the connection string by key for fast lookup later.
                connectionStrings.Add(key, connectionString);
            }

            return connectionString;
        }
    }
}
