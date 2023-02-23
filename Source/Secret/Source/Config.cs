using System;
using System.Data;
using System.Windows;
using System.IO;
using IniParser;
using IniParser.Model;

namespace Secret.Source
{
    public class Config
    {
    
       protected enum _Bool
       {
          True,
          False
       }
       
       public struct Configuration
       {
            public static string ServerName { get; set; }

            public static uint ServerPort { get; set; }

            public static string UserName { get; set; }

            public static string Password { get; set; }

            public static string Database { get; set; }
           
            public static bool Pool { get; set; }
       }
       
       public static void _CreateConfiguration()
       {
          ['DATABASE']['ServerName'] = '127.0.0.1';
          ['DATABASE']['ServerPort'] = 3306;
          ['DATABASE']['UserName'] = 'root';
          ['DATABASE']['Password'] = '';
          ['DATABASE']['Database'] = 'User';
          ['CONFIG']['POOLING'] = _Bool.False;
       }
        
       public static void _LoadConfig()
       {
           //check directory
           if(Directory.Exists(@"Config\\"))
           {
                try
                {
                    var parser = new FileIniDataParser();
                    
                    IniData data = parser.ReadFile("Config\\Data.ini");
                    
                    Configuration.ServerName = data["DATABASE"]["Server"];
                    Configuration.ServerPort = Convert.ToUInt32(data["DATABASE"]["Port"], 16);
                    Configuration.UserName = data["DATABASE"]["User"];
                    Configuration.Password = data["DATABASE"]["Password"];
                    Configuration.Database = data["DATABASE"]["DBName"];
                    Configuration.Pool = data["CONFIG"]["POOLING"];
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show(_Exception.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
           }
       }
    }
}
