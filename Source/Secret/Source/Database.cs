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

        public static string args { get; set; }

        protected static MySqlConnectionStringBuilder Secret = new MySqlConnectionStringBuilder();

        private static MySqlConnection _Connection = new MySqlConnection(Secret.ToString());

        private static MySqlCommand _Command = new MySqlCommand(args, _Connection);

        private static void _BuildConnectionString()
        {
            Secret.Server = Configuration.ServerName;
            Secret.Port = Configuration.ServerPort;
            Secret.UserID = Configuration.UserName;
            Secret.Password = Configuration.Password;
            Secret.Database = Configuration.Database;
            Secret.SslMode = MySqlSslMode.Prefered;
        }

        private static void _ConnectDB()
        {
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
