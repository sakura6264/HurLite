using HurLite.BrowserSelector.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace HurLite.BrowserSelector.Helpers
{
    public class SettingsFile
    {
        public Settings SettingsObject;

        private SettingsFile(Settings settings)
        {
            this.SettingsObject = settings;
        }

        public static SettingsFile TryLoading()
        {
            return new SettingsFile(GetSettings());
        }

        public static Settings GetSettings()
        {
            try
            {
                return JsonOperations.FromJsonToModel<Settings>(Constants.SettingsFilePath);
            }
            catch (Exception e)
            {
                switch (e)
                {
                    case FileNotFoundException _:
                    case DirectoryNotFoundException _:
                        return New(new List<Browser>()).SettingsObject;
                    default:
                        throw;
                }
            }
        }

        public static SettingsFile New(List<Browser> browsers)
        {
            Directory.CreateDirectory(Constants.APP_SETTINGS_DIR);

            var _settings = new Settings()
            {
                Browsers = browsers,
            };

            JsonOperations.FromModelToJson(_settings, Constants.SettingsFilePath);
            return new SettingsFile(_settings);
        }

        public void Update()
        {
            SettingsObject.LastUpdated = DateTime.Now.ToString();
            JsonOperations.FromModelToJson(SettingsObject, Constants.SettingsFilePath);
        }
    }
}
