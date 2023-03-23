using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;
using System.IO;
using System.Diagnostics;

namespace Secret.Source
{
    public class Database
    {
        public struct Config
        {
            public static string ServerName { get; set; }

            public static uint ServerPort { get; set; }

            public static string UserName { get; set; }

            public static string Password { get; set; }

            public static string Database { get; set; }
        }

        protected static string root = @"Config\\";

        protected static bool _DirectoryExists = (Directory.Exists(root)) ? true : false;

        public static string args { get; set; }

        protected static MySqlConnectionStringBuilder Secret = new MySqlConnectionStringBuilder();

        public static void Build()
        {
            Tools.sw = Stopwatch.StartNew();

            try
            {
                Secret.Server = Config.ServerName;
                Secret.Port = Config.ServerPort;
                Secret.UserID = Config.UserName;
                Secret.Password = Config.Password;
                Secret.Database = Config.Database;
                Secret.SslMode = MySqlSslMode.Prefered;

                Logs.Write("Building Connection String", 1);
                Logs.Write(Secret.ConnectionString, 1);

                Tools.sw.Stop();

                Logs.Write("Done Constructing Connection String at " + Tools.sw.ElapsedMilliseconds + "ms", 1);
            }
            catch (Exception ex)
            {
                Logs.Write(ex.Message.ToString(), 2);
                Environment.Exit(-1);
            }
        }
    }
}