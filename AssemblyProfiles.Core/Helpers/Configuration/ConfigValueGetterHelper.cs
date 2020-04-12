using System;
using System.Configuration;

namespace AssemblyProfiles.Core.Helpers
{
    public static class ConfigValueGetterHelper
    {
        public static string GetValueByKeyFromConfiguration(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (appSetting != null)
            {
                return appSetting;
            }
            throw new Exception($"Не существует ключ {key} в в файле конфигурации");
        }
    }
}
