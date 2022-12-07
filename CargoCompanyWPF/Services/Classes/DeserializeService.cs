using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CargoCompanyWPF.Services.Classes
{
    public static class DeserializeService
    {
        public static T Deserialize<T>()
        {
            using var fs = new FileStream("UsersInfo.json", FileMode.OpenOrCreate);
            using var sr = new StreamReader(fs);

            var json = sr.ReadToEnd();
            var res = JsonSerializer.Deserialize<T>(json);
            if (res != null)
            {
                return res;
            }
            throw new SerializationException();
        }
    }
}
