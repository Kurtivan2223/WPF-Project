using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Secret.Source;
using System.Diagnostics;
using System.IO;

namespace Secret
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!Tools.DExists(@"Logs"))
            {
                Directory.CreateDirectory("Logs");
            }

            if (!Tools.DExists(@"Config"))
            {
                Directory.CreateDirectory("Config");
            }

            if (!Tools.FExists(@"Config\\Settings.ini"))
            {
                Logs.Write("Setting Up Configs!", 1);
                Config.CreateIni();
            }

            Config.ReadIni();
            Database.Build();
        }
    }
}
