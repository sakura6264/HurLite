﻿using System.IO;
using System.Threading.Tasks;

namespace HurLite.BrowserSelector.Helpers
{
    public class CliArgs
    {
        public bool IsSecondInstance = false;
        public bool IsRunAsMin = false;
        public bool IsProtocolActivated = false;
        public string Url { get; set; } = string.Empty;
        public string[] otherArgs;

        private CliArgs(string[] Args, bool SecondInstanceArgs)
        {
            var ArgsLength = Args.Length;
            if (ArgsLength > 0)
            {
                string whatever = Args[0];

                if (Args[0] == "--minimized")
                {
                    IsRunAsMin = true;
                }

                if (SecondInstanceArgs)
                {
                    IsSecondInstance = true;
                    if (ArgsLength >= 2)
                        whatever = Args[1];
                }

                if (whatever.StartsWith("HurLite://"))
                {
                    IsProtocolActivated = true;
                    Url = whatever.Substring(7);
                }
                //else if(whatever.StartsWith("https://" || "http://"))
                else
                {
                    otherArgs = Args.Length > 2 ? Args[2..] : null;
                    Url = whatever.Contains(' ') ? $"\"{whatever}\"" : whatever;
                }
            }
        }

        public static CliArgs GatherInfo(string[] Args, bool SecondInstanceArgs)
        {
#if DEBUG
            Task.Run(() =>
            {
                var ArgsStoreFile = Path.Combine(Constants.ROAMING, "Settings", "args.txt");
                var StrFormat = $"\n\n{SecondInstanceArgs} --- {Args.Length} - {string.Join("__", Args)}";
                if (!File.Exists(ArgsStoreFile))
                {
                    var Dir = Path.GetDirectoryName(ArgsStoreFile);
                    if (!Directory.Exists(Dir))
                    {
                        Directory.CreateDirectory(Dir);
                    }
                    File.Create(ArgsStoreFile).Close();
                }
                File.AppendAllText(ArgsStoreFile, StrFormat);
            });
#endif

            return new CliArgs(Args, SecondInstanceArgs);
        }

    }
}
