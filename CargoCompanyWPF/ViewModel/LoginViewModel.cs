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
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using CargoCompanyWPF.Message;
using CargoCompanyWPF.Model;

namespace CargoCompanyWPF.ViewModel
{
    public class LoginViewModel : ViewModelBase

    {


        public User? User { get; set; } = new();
        public Error? Error { get; set; } = new();
        public int? Index { get; set; }
        private INavigationService? _navigationService;
        private readonly IMessenger _messenger;
        public LoginViewModel(INavigationService? navigationService, IMessenger messenger = null)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                Index = param?.Message;

            });
        }
        public RelayCommand LoginCommand
        {

            get => new(() =>
            {
                
                
                if (CheckJsonService.Check("UsersInfo.json")) {
                    Users.All_users = DeserializeService.Deserialize<List<User?>>();
                    //if (Users.All_users.Any(u => u.Email == Email))
                    //{
                    //    int index = Users.All_users.FindIndex(u => (u?.Email)?.ToLower() == Email?.ToLower());
                    //    if (Users.All_users[index]?.Password == Password)
                    //    {
                    //        UserIndex = index;
                    //        _navigationService?.NavigateTo<UserDashboardViewModel>(new ParameterMessage() { Message = index });


                    //    }
                    //}
                    //else Email_error = "No such user";
                    var errors = IsValid_check.IsValidForLoginVM(User);
                    Error = errors.Item1;
                    //Password_error = IsValid_check.IsValidForLoginVM(Email, Password).Item2;
                    if (errors.Item2)
                    {
                        if (User.Email == "a" && User.Password == "a")
                        {
                            _navigationService?.NavigateTo<AdminViewModel>(new UsersMessage() { ListOfUsers = Users.All_users });
                        }


                        else if (Users.All_users.Any(u => (u?.Email)?.ToLower() == User?.Email?.ToLower()))
                        {
                            int index = Users.All_users.FindIndex(u => (u?.Email)?.ToLower() == User?.Email?.ToLower());
                            if (Users.All_users[index]?.Password == User?.Password)
                            {
                                Index = index;
                                _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = index });


                            }
                            else { Error.Password_error = "Wrong password"; }

                        }
                        else Error.Email_error = "No such user";
                    }
                    

                }
                else
                { 
                    if (User?.Email != null || User?.Email != "") Error.Email_error = "No such user";
                    else Error.Email_error = "Fill in field"; 
                }
                

                //User? user_info = new();

                //Users.All_users.Add(user_info);
                //Users.All_users[0].Email = Email;
                //MessageBox.Show(Users.All_users[0].Email);
                //bool contains = Users.All_users.Any(u => u.Email == Email);
                //if (contains)
                //{
                //    MessageBox.Show(Users.All_users[0].Email);
                //}
                //if(Users.All_users.Contains.Any(user_info.Email==Email))
                //{

                //}
                //App.Container.GetInstance<MainViewModel>().CurrentViewModel = App.Container.GetInstance<RegistrationViewModel>();
                //_navigationService?.NavigateTo<RegistrationViewModel>();
            });
        }
        public RelayCommand Not_user
        {

            get => new(() =>
            {
                //App.Container.GetInstance<MainViewModel>().CurrentViewModel = App.Container.GetInstance<RegistrationViewModel>();
                if (CheckJsonService.Check("UsersInfo.json"))
                {
                    Users.All_users = DeserializeService.Deserialize<List<User?>>();

                }
                _navigationService?.NavigateTo<RegistrationViewModel>();
            });
    } } }
     
