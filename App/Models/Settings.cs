using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HurLite.BrowserSelector.Models
{
    public class Settings
    {
        public string Version { get; set; } = Constants.VERSION;

        public string LastUpdated { get; set; } = DateTime.Now.ToString();

        public List<Browser> Browsers { get; set; }

        public AppSettings AppSettings { get; set; }
    }

    public class AppSettings
    {
        public bool DisableAcrylic { get; set; } = false;

        public List<Byte> BackgroundRGB { get; set; } = new List<byte> { 51, 51, 51 };

        public bool LaunchUnderMouse { get; set; } = false;

        public bool UseWhiteBorder { get; set; } = true;

        public string BackgroundType { get; set; } = "mica";
    }

    public class AppAutoSettings
    {
        public int[] WindowSize { get; set; }
    }
}
