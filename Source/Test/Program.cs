using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Test
{
    public class Program
    {
        protected static bool _IsOpen { get; set; }
        protected static bool _Use { get; set; }

        protected static MySqlConnectionStringBuilder _Build = new MySqlConnectionStringBuilder
        {
            Server = "127.0.0.1",
            Port = 3306,
            UserID = "root",
            Database = "pets",
            SslMode = MySqlSslMode.Prefered
        };

        protected static MySqlConnection _Connect = new MySqlConnection
        {
           ConnectionString  = _Build.ToString()
        };

        private static void _Control()
        {
            if(_Use)
            {
                try
                {
                    _Connect.Open();
                    _IsOpen = true;
                }
                catch(MySqlException _Exception)
                {
                    Console.WriteLine("[Error]: {0}", _Exception.Message.ToString());
                }
            }
            else
            {
                try
                {
                    _Connect.Close();
                    _IsOpen = false;
                }
                catch(MySqlException _Exception)
                {
                    Console.WriteLine("[Error]: {0}", _Exception.Message.ToString());
                }
            }
        }

        public static void Main(string[] args)
        {
            string m_Option;
            int _Option;

            Console.WriteLine("[1]Connect to Database\n[2]Cancel\n: ");
            m_Option = Console.ReadLine();
            _Option = Convert.ToInt32(m_Option);


            switch (_Option)
            {
                case 1:
                    _Use = true;
                    break;
                case 2:
                    _Use = false;
                    break;
            }

            _Control();

            Console.ReadLine();
        }
    }
}
