using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoCompanyWPF.Model
{
    public class ItemsView
    {
        public ICollectionView? Orders { get; set; }
        public ICollectionView? Packages { get; set; }
    }
}
