using System;
using System.IO;
using System.Windows;
using System.Globalization;

namespace Secret.Source
{
    public class Logs
    {
        private static string GetTimeStamp(DateTime value)
        {
            return value.ToString("yyyy MM dd HH:mm:ss.ffff");
        }

        private static string BuildLogName(DateTime value)
        {
            return value.ToString("yyyy_MM_dd");
        }

        public static void Write(string Text, int code)
        {
            string timestamp = GetTimeStamp(DateTime.Now);
            string LogName = BuildLogName(DateTime.Now);

            switch (code)
            {
                case 1:
                    File.AppendAllText(@"Logs\\Logs_" + LogName + ".txt", "[INFO] " + timestamp + " " + Text + Environment.NewLine);
                    break;
                case 2:
                    File.AppendAllText(@"Logs\\Logs_" + LogName + ".txt", "[ERROR] " + timestamp + " " + Text + Environment.NewLine);
                    break;
                case 3:
                    File.AppendAllText(@"Logs\\Logs_" + LogName + ".txt", "[WARNING] " + timestamp + " " + Text + Environment.NewLine);
                    break;
                case 4:
                    File.AppendAllText(@"Logs\\Logs_" + LogName + ".txt", "[DEBUG] " + timestamp + " " + Text + Environment.NewLine);
                    break;
            }
        }
    }
}