using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;
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

        public static string args { get; set; }

        protected static MySqlConnectionStringBuilder Secret = new MySqlConnectionStringBuilder();

        

        public static MySqlConnection _Connection = new MySqlConnection(Secret.ToString());

        public static MySqlCommand _Command = new MySqlCommand(args, _Connection);

        private static void _GetConnectionString()
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
                MessageBox.Show(_Exception.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void _CloseConnection()
        {
            try
            {
                _Connection.Close();
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void _Insert()
        {
            try
            {
                _ConnectDB();
                _Command.ExecuteNonQuery();
            }
            catch(Exception _Exception)
            {
                MessageBox.Show(_Exception.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _CloseConnection();
        }
    }
}
