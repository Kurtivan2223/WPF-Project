using System;
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
            //Example
            Database.args = "INSERT INTO `pets` (pNo, pName, pCategory, pBreed) VALUES ('1', 'Micky', 'Dog', 'Husky')";
            Database._Insert();
        }
    }
}
