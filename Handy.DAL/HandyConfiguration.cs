using System;
using System.Xml;
using System.IO;
using System.Collections.Specialized;
using System.Reflection;

namespace DataHelper
{
    /// <summary>
    /// Reads App.config file and from <appSettings>  </appSettings> gets the key/value pair and add it into Settings property
    /// </summary>
    public static class HandyConfiguration
    {
        /// <summary>
        /// Contains key/value pair from <appSettings></appSettings> section of App.config file
        /// </summary>
        public static NameValueCollection Settings;

        /// <summary>
        /// Reads App.config file and from <appSettings></appSettings> gets the key/value pair and add it into Settings property
        /// </summary>
        static HandyConfiguration()
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string configFile = Path.Combine(appPath, "App.config");

            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException(string.Format("Application configuration file '{0}' not found.", configFile));
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(configFile);
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("appSettings");
            Settings = new NameValueCollection();

            foreach (XmlNode node in nodeList)
            {
                foreach (XmlNode key in node.ChildNodes)
                {
                    Settings.Add(key.Attributes["key"].Value, key.Attributes["value"].Value);
                }
            }
        }
    }
}
