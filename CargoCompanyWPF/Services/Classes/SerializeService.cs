using CargoCompanyWPF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CargoCompanyWPF.Services.Classes
{
    public static class SerializeService
    {
        public static void Serialize(string path,List<User> List)
        {
            using var fs = new FileStream(path, FileMode.Truncate);
            JsonSerializer.Serialize(fs, Users.All_users);
        }
    }
}
