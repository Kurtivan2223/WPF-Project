using System;
using System.IO;
using System.Windows;
using System.Globalization;

namespace Secret.Source
{
    public class Logs
    {
        #region Logs
        protected static string root = @"Logs\\";

        protected static bool _DirectoryExists = (Directory.Exists(root)) ? true : false;

        protected static string _LogName { get; set; }

        private static void _CreateFolder()
        {
            try
            {
                if(!Directory.Exists(root))
                {
                    Directory.CreateDirectory("Logs");
                }
            }
            catch(IOException _Exception)
            {
                MessageBox.Show(_Exception.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void _ConstructFileName(string _Path)
        {
            string _Name = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + "_Logs.txt";
           
            _LogName = _Name;
        }

        //Single Use Bullshit
        public static void _Logs(string _Message)
        {
            _CreateFolder();
            _ConstructFileName(root);

            try
            {
                StreamWriter _File = new StreamWriter(root + _LogName, true);

                _File.WriteLine("[Logs]" + DateTime.Now.ToString() + " " + _Message);
                _File.Close();
            }
            catch(Exception _Exception)
            {
                MessageBox.Show(_Exception.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}