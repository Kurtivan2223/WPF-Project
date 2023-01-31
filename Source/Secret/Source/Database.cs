using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Secret.Source
{
    public class Database
    {
        protected static string Secret { get; set; }
        public static string args { get; set; }

        public static MySqlConnection _Connection = new MySqlConnection(Secret);

        public static MySqlCommand _Command = new MySqlCommand(args, _Connection);

        private static void _GetConnectionString()
        {
            Secret = "server=localhost;user=root;database=test;port=3306;";
        }

        private static void _ConnectDB()
        {
            _GetConnectionString();

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
