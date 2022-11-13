using CargoCompanyWPF.Message;
using CargoCompanyWPF.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;

namespace CargoCompanyWPF.ViewModel
{
    public class RegistrationViewModel:ViewModelBase
    {
        private readonly INavigationService? _navigationService;

        public RegistrationViewModel(INavigationService? service)
        {
            _navigationService = service;
         
        }
       
    }
}
