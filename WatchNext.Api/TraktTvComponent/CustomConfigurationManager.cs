using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraktTvComponent
{
    class CustomConfigurationManager
    {
        public string this[string key]
        {
            get
            {
                Configuration config = null;
                string exeConfigPath = this.GetType().Assembly.Location;
                try
                {
                    config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
                }
                catch (Exception ex)
                {
                    throw new ConfigurationErrorsException("Satelite Configuration File Is Missing", ex);
                }
                
                string setting = "";

                if (config != null)
                {
                    setting = GetAppSetting(config, key);
                }

                return setting;
            }
        }

        string GetAppSetting(Configuration config, string key)
        {
            KeyValueConfigurationElement element = config.AppSettings.Settings[key];
            if (element != null)
            {
                string value = element.Value;
                if (!string.IsNullOrEmpty(value))
                    return value;
            }
            return string.Empty;
        }
    }
}
