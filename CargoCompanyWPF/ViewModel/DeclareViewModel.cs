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
    public class DeclareViewModel:ViewModelBase
    {
        public int? Index { get; set; }
        public User User { get; set; } = new();
        public Order Order { get; set; } = new();
        public Error Error { get; set; } = new();
        private INavigationService? _navigationService;
        private readonly IMessenger _messenger;
        public DeclareViewModel(INavigationService? navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                Index = param?.Message;
                if (Index != null) User = Users.All_users[(int)Index];
                //index = All_users

            });
        }

        public RelayCommand SaveCommand
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
                        Order.Declared_on_website = true;
                    Order.Status = "Ordered";
                    Order.OrderFin = Users.All_users[(int)Index].FIN;
                    Users.All_users[(int)Index].Orders.Add(Order);
                        Order.dateTime = DateTime.Now;
                        using var fs = new FileStream("UsersInfo.json", FileMode.Truncate);
                        JsonSerializer.Serialize(fs, Users.All_users);
                        _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = Index });
                    }

                

                //}


            });
        }




    }

}
