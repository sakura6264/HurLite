using HurLite.BrowserSelector.Helpers;
using System;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HurLite.BrowserSelector.Models
{
    public class Browser
    {

        public string Name { get; set; }

        public string ExePath { get; set; }

        public string LaunchArgs { get; set; } = null;

        public bool Hidden { get; set; } = false;

        public AlternateLaunch[] AlternateLaunches { get; set; } = new AlternateLaunch[0];

        public string CustomIconPath { get; set; } = null;

        [JsonIgnore]
        public ImageSource GetIcon
        {
            get
            {
                if (!string.IsNullOrEmpty(CustomIconPath))
                {
                    return new BitmapImage(new Uri(CustomIconPath));
                }
                else if (!string.IsNullOrEmpty(ExePath))
                {
                    Icon RawIcon = ExePath.StartsWith('"'.ToString())
                                ? IconExtractor.FromFile(ExePath.Substring(1, ExePath.Length - 2))
                                : IconExtractor.FromFile(ExePath);

                    return IconUtilites.ToImageSource(RawIcon);
                }
                else
                    return null;
            }
        }

        [JsonIgnore]
        public Visibility ShowAdditionalBtn
        {
            get
            {
                if (AlternateLaunches == null || AlternateLaunches.Length == 0)
                    return Visibility.Hidden;
                else return Visibility.Visible;
            }
        }

        public string Linkx { get; set; }
    }

    //[JsonObject(MemberSerialization.OptOut)]
    public class AlternateLaunch
    {
        public AlternateLaunch() { }

        public AlternateLaunch(string ItemName, string LaunchArgs)
        {
            this.ItemName = ItemName;
            this.LaunchArgs = LaunchArgs;
            //this.IsPath = false;
        }

        //public AlternateLaunch(string ItemName, string ExePath, string LaunchArgs)
        //{
        //    this.ItemName = ItemName;
        //    this.LaunchExe = ExePath;
        //    this.LaunchArgs = LaunchArgs;
        //    this.IsPath = true;
        //}

        public string ItemName { get; set; }

        //[JsonInclude]
        //public string LaunchExe { get; set; }

        public string LaunchArgs { get; set; }

        //[JsonInclude]
        //public bool IsPath { get; set; }
    }

    public enum BrowserSourceType
    {
        Registry,
        User
    }
}
