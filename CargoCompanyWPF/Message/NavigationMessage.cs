﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoCompanyWPF.Services.Interfaces;
namespace CargoCompanyWPF.Message
{
    public class NavigationMessage
    {
        public Type? ViewModelType { get; set; }
    }
}
