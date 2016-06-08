using System;
using System.Configuration;
using System.Web.Configuration;

namespace SampleWebApp.Models
{
    public interface IFeatureToggle
    {
        bool IsEnabled(string feature);
    }

    public class FeatureToggle : IFeatureToggle
    {
        public bool IsEnabled(string feature)
        {
            var isEnabled = ConfigurationManager.Instance.Get<bool>(feature);
            return isEnabled;
        }
    }

    public class ConfigurationManager
    {
        private static ConfigurationManager _instance;

        public static ConfigurationManager Instance
        {
            get { return _instance ?? (_instance = new ConfigurationManager()); }
        }

        private ConfigurationManager()
        {
            
        }

        public void Toggle(string key, string value)
        {
            var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            var section = (AppSettingsSection)configuration.GetSection("appSettings");
            if (section.Settings[key] == null)
            {
                section.Settings.Add(new KeyValueConfigurationElement(key, value));
            }
            else
            {
                section.Settings[key].Value = value;
            }
            configuration.Save();
        }

        public T Get<T>(string key)
        {
            try
            {
                var result = WebConfigurationManager.AppSettings[key];
                if (result != null)
                {
                    return (T)Convert.ChangeType(result, typeof(T));
                }
                return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}