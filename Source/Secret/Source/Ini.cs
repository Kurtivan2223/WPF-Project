using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;


namespace Secret.Source
{
    class Ini
    {
        private string Path;

        private string Exe = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public Ini(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? Exe + ".ini").FullName;
        }
        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? Exe, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? Exe, Key, Value, Path);
        }


        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? Exe);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? Exe);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
