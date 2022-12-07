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

namespace CargoCompanyWPF.ViewModel
{
    public class PrivateInfoViewModel:ViewModelBase
    {
        public int? Index { get; set; }
        public User User { get; set; } = new();
        public Error Error { get; set; } = new();
        private INavigationService? _navigationService;
        private readonly IMessenger _messenger;
        public PrivateInfoViewModel(INavigationService? navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                Index = param?.Message;
                if(Index!=null) User = Users.All_users[(int)Index];
                //index = All_users

            });
        }

        public RelayCommand SaveCommand
        {
            get => new(() =>
            {
                var errors = IsValid_check.IsValidForRegistrationVM(User);

                Error = errors.Item1;
                if (errors.Item2)
                {
                Users.All_users[(int)Index] = User;
                using var fs = new FileStream("UsersInfo.json", FileMode.Truncate);
                JsonSerializer.Serialize(fs, Users.All_users);
                _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = Index });
                }


            });
        }
        public RelayCommand BackCommand
        {
            get => new(() =>
            {

                _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = Index });

            });
        }
    }
}
