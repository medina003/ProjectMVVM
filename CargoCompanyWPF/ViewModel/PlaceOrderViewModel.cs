using CargoCompanyWPF.Message;
using CargoCompanyWPF.Model;
using CargoCompanyWPF.Services.Classes;
using CargoCompanyWPF.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace CargoCompanyWPF.ViewModel
{
    public class PlaceOrderViewModel :ViewModelBase
    {
        public User? User { get; set; } = new();
        public Order? Order { get; set; } = new();
        public Error Error { get; set; } = new();
        private INavigationService? _navigationService;
        public PlaceOrderViewModel(INavigationService? navigationService, IMessenger? messenger=null)
        {
            _navigationService = navigationService;
           
        }

        public RelayCommand PayOffBalanceCommand
        {
            get => new(() =>
            {
            var errors = IsValid_check.IsValidForPlaceOrderVM(Order);

            Error = errors!.Item1!;

                if (errors.Item2)
                {
                    if (PaymentService.IsPayable(Order, User))
                    {
                        SerializeService.Serialize("UsersInfo.json", Users.All_users!);
                        _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = User });
                        Order = new();
                    }
                }
            });
        }
        public RelayCommand BackCommand
        {
            get => new(() =>
            {
                Order = new();
                Error = new();
                _navigationService?.NavigateTo<UserdashboardViewModel>();

            });
        }



    }
}
