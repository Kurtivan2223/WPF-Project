using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Diagnostics;

namespace Secret.Source
{
    class Config
    {
        public static void CreateIni()
        {
            try
            {
                var ini = new Ini(@"Config\\Settings.ini");

                ini.Write("HOST", "127.0.0.1", "DATABASE");
                ini.Write("PORT", "3306", "DATABASE");
                ini.Write("USERNAME", "root", "DATABASE");
                ini.Write("PASSWORD", "", "DATABASE");
                ini.Write("DBName", "", "DATABASE");
            }
            catch (Exception ex)
            {
                Logs.Write(ex.Message.ToString(), 2);
                Environment.Exit(-1);
            }
            Logs.Write("Successfully Created Configuration Settings", 1);
        }

        public static void SaveSettings()
        {
            try
            {
                var ini = new Ini(@"Config\\Settings.ini");

                ini.Write("HOST", Database.Config.ServerName, "DATABASE");
                ini.Write("PORT", Database.Config.ServerPort.ToString(), "DATABASE");
                ini.Write("USERNAME", Database.Config.UserName, "DATABASE");
                ini.Write("PASSWORD", Database.Config.Password, "DATABASE");
                ini.Write("DBName", Database.Config.Database, "DATABASE");
            }
            catch (Exception ex)
            {
                Logs.Write(ex.Message.ToString(), 2);
                Environment.Exit(-1);
            }
            Logs.Write("Successfully Created Configuration Settings", 1);
        }

        public static void ReadIni()
        {
            try
            {
                Tools.sw = Stopwatch.StartNew();

                var ini = new Ini(@"Config\\Settings.ini");

                Logs.Write("Loading up Configuration", 1);

                if (Tools.FExists(@"Config\\Settings.ini"))
                {
                    Database.Config.ServerName = ini.Read("HOST", "DATABASE");
                    Database.Config.ServerPort = Convert.ToUInt32(ini.Read("PORT", "DATABASE"));
                    Database.Config.UserName = ini.Read("USERNAME", "DATABASE");
                    Database.Config.Password = ini.Read("PASSWORD", "DATABASE");
                    Database.Config.Database = ini.Read("DBName", "DATABASE");
                }
                else
                {
                    Logs.Write("Directory doesn't Exists!", 2);
                    Environment.Exit(-1);
                }

                Tools.sw.Stop();

                Logs.Write("Configuration Loaded at " + Tools.sw.ElapsedMilliseconds + "ms", 1);
            }
            catch (Exception ex)
            {
                Logs.Write(ex.Message.ToString(), 2);
                Environment.Exit(-1);
            }
        }
    }
}
