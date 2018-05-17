using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace LegacySessionManager
{
    internal class ApplicationConfiguration
    {
        public static string SessionDatabase => ApplicationConfigSetting<string>("SessionDatabase");

        public static int SessionTimeout => ApplicationConfigSetting<int>("SessionTimeout",20);

        private static T ApplicationConfigSetting<T>(string settingName, object defaultValue = null)
        {
            var assemLocation = Assembly.GetExecutingAssembly().Location;
            var configLocation = assemLocation + ".config";

            if (!System.IO.File.Exists(configLocation ))
            {
                var fileInfo = new System.IO.FileInfo(assemLocation);
                configLocation = System.Web.HttpRuntime.AppDomainAppPath + fileInfo.Name + ".config";
            }

            T value;

            try
            {
                var configMap = new ExeConfigurationFileMap()
                {
                    ExeConfigFilename = configLocation,
                };
                var appConfig = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

                var setting = appConfig.AppSettings.Settings[settingName];

                value = (T)Convert.ChangeType(setting.Value, typeof(T));
            }
            catch (Exception)
            {
                value = (T)Convert.ChangeType(defaultValue, typeof(T));
            }

            if (value == null)
                throw new NullReferenceException(
                    $"Missing configuration in the config file (*.config) under <appSettings> tag. \r\nKey = {settingName}. \r\nAssembly Location = {assemLocation}\r\nConfig Location = {configLocation}");

            return value;
        }


    }
}