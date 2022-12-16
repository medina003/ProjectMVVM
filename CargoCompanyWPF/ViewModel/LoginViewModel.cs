using CargoCompanyWPF.Message;
using CargoCompanyWPF.Model;
using CargoCompanyWPF.Services.Classes;
using CargoCompanyWPF.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CargoCompanyWPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public User? User { get; set; } = new();
        public Error? Error { get; set; } = new();
        private INavigationService? _navigationService;
        private readonly IMessenger? _messenger;
        public LoginViewModel(INavigationService? navigationService, IMessenger? messenger = null)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger!.Register<ParameterMessage>(this, param =>
            {
                User = param?.Message as User;

            });
        }
        public RelayCommand LoginCommand
        {

            get => new(() =>
            {
                if (CheckJsonService.Check("UsersInfo.json"))
                {
                    Users.All_users = DeserializeService.Deserialize<List<User?>>();
                    var errors = IsValid_check.IsValidForLoginVM(User);
                    Error = errors.Item1;
                    if (errors.Item2)
                    {
                        Error = new();
                        if (User?.Email == "admin" && User?.Password == "admin")
                        {
                            _navigationService?.NavigateTo<AdminViewModel>(new UsersMessage() { ListOfUsers = Users.All_users });
                        }

                        else if (Users.All_users.Any(u => (u?.Email)?.ToLower() == User?.Email?.ToLower()))
                        {

                            int index = Users.All_users.FindIndex(u => (u?.Email)?.ToLower() == User?.Email?.ToLower());
                            if (Users.All_users[index]?.Password == User?.Password)
                            {
                                UserIndex.Index = index;
                                _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = User });
                            }
                            else MessageBox.Show("Wrong password!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else MessageBox.Show("No such user!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(User?.Email)) MessageBox.Show("No such user!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                    else MessageBox.Show("Fill in field!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error); ;
                }
            });
        }
        public RelayCommand Not_user
        {
            get => new(() =>
            {
                if (CheckJsonService.Check("UsersInfo.json"))
                {
                    Users.All_users = DeserializeService.Deserialize<List<User?>>();
                }
                User = new();
                _navigationService?.NavigateTo<RegistrationViewModel>();
            });
        }
    }
}

