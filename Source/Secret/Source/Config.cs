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
    }
}
