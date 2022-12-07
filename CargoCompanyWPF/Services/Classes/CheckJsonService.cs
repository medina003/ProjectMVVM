using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoCompanyWPF.Services.Classes
{
    public static class CheckJsonService
    {
        public static bool Check(string path )
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            using var sr = new StreamReader(fs);
            string? json = sr.ReadToEnd();
            if(json == "") { return false; }  
            return true;
        }
    }
}
