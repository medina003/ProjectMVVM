using CargoCompanyWPF.Message;
using CargoCompanyWPF.Model;
using CargoCompanyWPF.Services.Classes;
using CargoCompanyWPF.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.IO;
using System.Text.Json;

namespace CargoCompanyWPF.ViewModel
{
    public class IncreasingBalanceViewModel : ViewModelBase
    {
        public string Amount { get; set; } = String.Empty;
        public Error Error { get; set; } = new();
        public Card Card { get; set; } = new();
        private INavigationService? _navigationService;

        public IncreasingBalanceViewModel(INavigationService? navigationService)
        {
            _navigationService = navigationService;

        }

        public RelayCommand OrderCommand
        {
            get => new(() =>
            {
                var errors = IsValidCheckService.IsValidForIncreasingBalanceVM(Amount, Card);
                Error = errors!.Item1!;
                if (errors.Item2)
                {
                    Users.All_users[UserIndex.Index]!.Balance_on_acc!.Balance_for_purchase += Convert.ToDouble(Amount);
                    Amount = "";
                    Card = new();
                    Error = new();
                    _navigationService?.NavigateTo<UserdashboardViewModel>();
                    SerializeService.Serialize("UsersInfo.json", Users.All_users!);
                }

            });
        }
        public RelayCommand PackageCommand
        {
            get => new(() =>
            {


                var errors = IsValidCheckService.IsValidForIncreasingBalanceVM(Amount, Card);

                Error = errors!.Item1!;

                if (errors.Item2)
                {
                    Users.All_users[UserIndex.Index]!.Balance_on_acc!.Balance_for_delivery += Convert.ToDouble(Amount);
                    Amount = "";
                    Card = new();
                    Error = new();
                    _navigationService?.NavigateTo<UserdashboardViewModel>();
                    SerializeService.Serialize("UsersInfo.json", Users.All_users!);

                }

            });
        }
        public RelayCommand BackCommand
        {
            get => new(() =>
            {
                Amount = "";
                Card = new();
                Error = new();
                _navigationService?.NavigateTo<UserdashboardViewModel>();

            });
        }

    }
}
