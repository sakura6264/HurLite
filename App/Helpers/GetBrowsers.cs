using HurLite.BrowserSelector.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HurLite.BrowserSelector.Helpers
{
    public static class GetBrowsers
    {
        public static List<Browser> FromSettingsFile(bool includeHidden = false)
        {
            List<Browser> _browsersList = null;

            try
            {
                var _settingsFile = SettingsFile.TryLoading();
                _browsersList = _settingsFile.SettingsObject.Browsers;
            }
            catch (FileNotFoundException)
            {
                SettingsFile.New(new List<Browser>());
            }

            return (from b in _browsersList
                    where b.Name != null && b.ExePath != null && b.Hidden != true
                    select b).ToList();
        }

        public static List<Browser> FromSettingsFile(Settings settings, bool includeHidden = false)
        {
            return (from b in settings.Browsers
                    where b.Name != null && b.ExePath != null && b.Hidden != true
                    select b).ToList();
        }
    }

}
