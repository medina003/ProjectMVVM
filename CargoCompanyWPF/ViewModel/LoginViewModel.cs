using CargoCompanyWPF.Services.Interfaces;
using CargoCompanyWPF.Services.Classes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoCompanyWPF.ViewModel;

namespace CargoCompanyWPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private INavigationService? _navigationService;

        public LoginViewModel(INavigationService? navigationService)
        {
            _navigationService = navigationService;

        }
        public RelayCommand Not_user
        {
          
            get => new(()=>
            {
                _navigationService?.NavigateTo<RegistrationViewModel>();
            });
        }
    }
}
