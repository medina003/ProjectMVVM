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
        public int? Index { get; set; }
        public User User { get; set; } = new();
        public Order Order { get; set; } = new();
        public Error Error { get; set; } = new();
        private INavigationService? _navigationService;
        private readonly IMessenger _messenger;
        public PlaceOrderViewModel(INavigationService? navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                Index = param?.Message;
                if(Index!=null)User = Users.All_users[(int)Index];
                //index = All_users

            });
        }

        public RelayCommand PayOffBalanceCommand
        {
            get => new(() =>
            {
                //var errors = IsValid_check.IsValidForRegistrationVM(User);
                
                //Error = errors.Item1;
                //if (errors.Item2)
                //{


                   if ((Convert.ToDouble(Users.All_users[(int)Index].Balance_on_acc.Balance_for_purchase) < (Convert.ToDouble(Order.Amount) * Convert.ToDouble(Order.Quantity))))
                    {
                        MessageBox.Show("You don't have enough money on the balance");
                    }
                   else
                    {
                        if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        {
                            //
                        }
                        else
                        {
                            Users.All_users[(int)Index].Balance_on_acc.Balance_for_purchase -= Convert.ToDouble(Order.Amount );
                            Order.Ordered = true;
                        Order.Status = "Paid";
                        Order.OrderFin = Users.All_users[(int)Index].FIN;
                            Users.All_users[(int)Index].Orders.Add(Order);
                            Order.dateTime = DateTime.Now;
                            using var fs = new FileStream("UsersInfo.json", FileMode.Truncate);
                            JsonSerializer.Serialize(fs, Users.All_users);
                            
                            _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = Index });

                        Order = new();

                    }

                    }

                //}


            });
        }




    }
}
