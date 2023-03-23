using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Secret.Source
{
    class Tools
    {
        public static Stopwatch sw = new Stopwatch();

        public static bool DExists(string Path)
        {
            return Directory.Exists(Path) ? true : false;
        }

        public static bool FExists(string file)
        {
            return File.Exists(file) ? true : false;
        }
    }
}
