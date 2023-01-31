﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Secret.Source;

namespace Secret
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void Main()
        {
            Database._ConnectDB();

            Database._CloseConnection();
        }
    }
}
