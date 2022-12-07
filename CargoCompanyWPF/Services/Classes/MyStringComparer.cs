using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoCompanyWPF.Services.Classes
{
    public class MyStringComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x is null || y is null) return false;
            return x.ToLower() == y.ToLower();

        }

        public int GetHashCode(string obj) => obj.ToLower().GetHashCode();
    }
}
