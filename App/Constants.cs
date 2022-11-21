using System;
using System.IO;

namespace HurLite.BrowserSelector
{
    public class Constants
    {
        public const string NAME = "HurLite";
        public const string DESCRIPTION = "HurLite - A tool to select the browsers dynamically";
        public const string VERSION = "0.7.1";

        public static string APP_PARENT_DIR = Directory.GetParent(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName).FullName;
        public static string APP_LAUNCH_PATH = Environment.GetCommandLineArgs()[0];
        public static string ROAMING = APP_PARENT_DIR;
        public static string SettingsFilePath = Path.Combine(ROAMING, "Settings", "UserSettings.json");
        public static string APP_SETTINGS_DIR = Path.Combine(ROAMING, "Settings");

        public const string NEW_LINE = "1&#x0a;";

    }
}
