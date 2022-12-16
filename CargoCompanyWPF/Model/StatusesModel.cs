using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoCompanyWPF.Model
{
    public  class Statuses
    {
        public static ObservableCollection<string> OrderStatuses { get; set; } = new() { "All", "Paid", "Ordered" };
        public static ObservableCollection<string> PackageStatuses { get; set; } = new() { "All", "Ordered","Declared", "In abroad warehouse", "Shipped", "In filial", "Handed over" };

    }
}
