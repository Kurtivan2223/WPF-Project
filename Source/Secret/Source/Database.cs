using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;
using System.IO;
using IniParser;
using IniParser.Model;

namespace Secret.Source
{
    public class Database
    {
        protected struct Settings
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

        private static MySqlConnection _Connection = new MySqlConnection(Secret.ToString());

        private static MySqlCommand _Command = new MySqlCommand(args, _Connection);

        private static void _GetConnectionString()
        {
            if (_DirectoryExists)
            {
                var parser = new FileIniDataParser();

                IniData data = parser.ReadFile("Config\\Data.ini");

                try
                {
                    Settings.ServerName = data["DATABASE"]["Server"];
                    Settings.ServerPort = Convert.ToUInt32(data["DATABASE"]["Port"], 16);
                    Settings.UserName = data["DATABASE"]["User"];
                    Settings.Password = data["DATABASE"]["Password"];
                    Settings.Database = data["DATABASE"]["DBName"];
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show(_Exception.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private static void _BuildConnectionString()
        {
            Secret.Server = Settings.ServerName;
            Secret.Port = Settings.ServerPort;
            Secret.UserID = Settings.UserName;
            Secret.Password = Settings.Password;
            Secret.Database = Settings.Database;
            Secret.SslMode = MySqlSslMode.Prefered;
        }

        private static void _ConnectDB()
        {
            _GetConnectionString();
            _BuildConnectionString();

            try
            {
                _Connection.Open();
                Logs._Logs("Connected To Server.");
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void _CloseConnection()
        {
            try
            {
                _Connection.Close();
                Logs._Logs("Connection Closed.");
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void _Insert()
        {
            try
            {
                _ConnectDB();
                _Command.ExecuteNonQuery();
                Logs._Logs("Executing SQL Insert Command.");
            }
            catch(Exception _Exception)
            {
                MessageBox.Show(_Exception.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _CloseConnection();
        }
    }
}