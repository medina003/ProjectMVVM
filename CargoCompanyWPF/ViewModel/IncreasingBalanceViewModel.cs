using CargoCompanyWPF.Message;
using CargoCompanyWPF.Model;
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
    public class IncreasingBalanceViewModel:ViewModelBase
    {
        public float Amount{ get; set; }
        public int? Index { get; set; }
        public Error Error { get; set; } = new();
        private INavigationService? _navigationService;
        private readonly IMessenger _messenger;
        public IncreasingBalanceViewModel(INavigationService? navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                Index = param?.Message;
                //if (UserIndex != null) User = Users.All_users[(int)UserIndex];
                //index = All_users

            });
        }

        public RelayCommand PackageCommand
        {
            get => new(() =>
            {
                //var errors = IsValid_check.IsValidForRegistrationVM(User);

                //Error = errors.Item1;
                //if (errors.Item2)
                //{


                if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    //
                }
                else
                {
                    Users.All_users[(int)Index].Balance_on_acc.Balance_for_purchase += Amount;
                    using var fs = new FileStream("UsersInfo.json", FileMode.Truncate);
                    JsonSerializer.Serialize(fs, Users.All_users);
                    _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = Index });
                }



                //}


            });
        }
            public RelayCommand OrderCommand
        {
            get => new(() =>
            {
                //var errors = IsValid_check.IsValidForRegistrationVM(User);

                //Error = errors.Item1;
                //if (errors.Item2)
                //{


                if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    //
                }
                else
                {
                    Users.All_users[(int)Index].Balance_on_acc.Balance_for_delivery += Amount;
                    using var fs = new FileStream("UsersInfo.json", FileMode.Truncate);
                    JsonSerializer.Serialize(fs, Users.All_users);
                    _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = Index });
                }



                //}


            });
        }

    }
}
