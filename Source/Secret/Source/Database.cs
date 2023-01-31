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

        public static void _ConnectDB()
        {
            Secret = "server=localhost;" +
                "user=root;database=test;" +
                "port=3306;";

            try
            {
                _Connection.Open();
            }
            catch (Exception _Exception)
            {
                MessageBox.Show("L" + _Exception, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void _CloseConnection()
        {
            try
            {
                _Connection.Close();
            }
            catch (Exception _Exception)
            {
                MessageBox.Show("L" + _Exception, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
