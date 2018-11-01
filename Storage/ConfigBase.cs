using System;
using System.Configuration;

namespace Common
{
    class ConfigBase
    {
        protected string GetSetting(string settingName)
        {
            var setting = ConfigurationManager.AppSettings[settingName];
            if (string.IsNullOrEmpty(setting))
                throw new Exception($"key '{settingName}' not found in app config");

            return setting;
        }

        protected int GetIntSetting(string settingName)
        {
            int setting;
            if (int.TryParse(GetSetting(settingName), out setting) == false)
                throw new Exception($"key {settingName} is not integer");

            return setting;
        }
    }
}