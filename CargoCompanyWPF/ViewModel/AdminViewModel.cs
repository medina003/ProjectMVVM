using CargoCompanyWPF.Message;
using CargoCompanyWPF.Model;
using CargoCompanyWPF.Services.Classes;
using CargoCompanyWPF.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CargoCompanyWPF.ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        public int Index { get; set; }
        public ObservableCollection<Order?>? OrdersList { get; set; } = new();
        public Order? SelectedOrder { get; set; } = new();
        public int SelectedIndex { get; set; }  
        public bool InAbroad { get; set; }
        public bool InFillial { get; set; }
        public bool HandedOver { get; set; }
        public bool Paid { get ; set; } 
        public bool Ordered { get; set; }
        public bool Shipped { get; set; }

        public User User { get; set; } = new();
        public string Search { get; set; }
        //public string Search
        //{
        //    get
        //    {
        //        return
        //            _search;
        //    }
        //    set
        //    {
        //        _search = value;
        //        PostsView.Refresh();
        //    }
        //} 




        public bool IsAllSelected { get; set; }

        private INavigationService? _navigationService;
        //private string? _search = "";
        private readonly IMessenger _messenger;
        public ICollectionView PostsView { get; set; }

        public AdminViewModel(INavigationService? navigationService, IMessenger messenger)
        {
            if(CheckJsonService.Check("UserInfo.json")) Users.All_users = DeserializeService.Deserialize<List<User?>>();
            List<User?>? list = Users.All_users;

            //UsersList = new ObservableCollection<User?>(list);


            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<UsersMessage>(this, param =>
            {
                //List<User?>? list = param?.ListOfUsers;

                //UsersList = new ObservableCollection<User?>(list);
                foreach ( User user in param.ListOfUsers)
                {
                    foreach(Order order in user.Orders )
                    {
                        OrdersList.Add(order);
                    }
                }
                //PostsView = new CollectionViewSource { Source = OrdersList }.View;
                //PostsView.Filter = post => { if (Search.Trim() != "") { return ((Order)post).OrderFin?.ToLower() == Search?.ToLower(); } else return Search == ""; };
            });

        }
        public RelayCommand SearchCommand
        {

            get => new(() =>
            {
                if (Search != "")
                {
                    if (Users.All_users.Any(u => (u?.FIN)?.ToLower() == Search?.ToLower()))
                    {
                        int index = Users.All_users.FindIndex(u => (u?.FIN)?.ToLower() == Search?.ToLower());

                        OrdersList = (Users.All_users[index].Orders);
                        //UserIndex = Users.All_users.FindIndex(u => (u?.FIN)?.ToLower() == Search?.ToLower());
                        //UsersList.Clear();
                        //UsersList.Add(Users.All_users[(int)UserIndex]);

                    }

                    //App.Container.GetInstance<MainViewModel>().CurrentViewModel = App.Container.GetInstance<RegistrationViewModel>();
                    //_navigationService?.NavigateTo<PrivateInfoViewModel>(new ParameterMessage() { Message = UserIndex });
                } });
        }
        public RelayCommand ShippedCommand
        {

            get => new(() =>
            {
                
                   
                        //int index = Users.All_users.FindIndex(u => (u?.FIN)?.ToLower() == SelectedItem.FIN.ToLower());
                        //Users.All_users[SelectedItem].OrdersList[SelectedOrder].Status = "Shipped";
                    

                    //App.Container.GetInstance<MainViewModel>().CurrentViewModel = App.Container.GetInstance<RegistrationViewModel>();
                    //_navigationService?.NavigateTo<PrivateInfoViewModel>(new ParameterMessage() { Message = UserIndex });
                
            });
        }

        public RelayCommand RadioButtonCommand
        {
            get => new(() =>
            {
                int count = 0;
                        foreach(User user in Users.All_users)
                {

                    count += user.Orders.Count;
                }
                    if (IsAllSelected)
                    {
                    if(count == OrdersList.Count)
                    {
                        foreach(User user in Users.All_users)
                        {
                            foreach(Order order in user.Orders)
                            {
                            if (InAbroad)
                            {
                                order.Status = "In abroadwarehouse";
                            }
                           else if (InFillial)
                            {
                                order.Status = "In filial";
                            }
                            else if (Shipped)
                            {
                                order.Status = "Shipped";
                            }
                            else if (HandedOver)
                            {
                                order.Status = "Handed over";
                            }
                            else if (Paid)
                            {
                                order.Status = "Paid";
                            }
                            else if (Ordered)
                            {
                                order.Status = "Ordered";
                            }
                            }

                    }
                        OrdersList = new();
                        foreach (User user in Users.All_users)
                        {
                            foreach (Order order in user.Orders)
                            {

                                OrdersList.Add(order);
                            }
                        }
                        using var fs = new FileStream("UsersInfo.json", FileMode.Truncate);
                        JsonSerializer.Serialize(fs, Users.All_users);
                    }
                    else
                    {
                        Index = Users.All_users.FindIndex((u => (u?.FIN)?.ToLower() == OrdersList[0]?.OrderFin?.ToLower()));
                        foreach(Order order in Users.All_users[Index].Orders)
                        {
                            if (InAbroad)
                            {
                                order.Status = "In abroadwarehouse";
                            }
                            else if (InFillial)
                            {
                                order.Status = "In filial";
                            }
                            else if (Shipped)
                            {
                                order.Status = "Shipped";
                            }
                            else if (HandedOver)
                            {
                                order.Status = "Handed over";
                            }
                            else if (Paid)
                            {
                                order.Status = "Paid";
                            }
                            else if (Ordered)
                            {
                                order.Status = "Ordered";
                            }
                        }
                        OrdersList = new(Users.All_users[Index].Orders);                       

                    }


                }
                else 
                {



                    Index = Users.All_users.FindIndex((u => (u?.FIN)?.ToLower() == SelectedOrder?.OrderFin?.ToLower()));
                    int index1 =Users.All_users[Index].Orders.IndexOf(SelectedOrder);


                    if (InAbroad)
                    {
                        Users.All_users[Index].Orders[index1].Status = "In abroad warehouse";
                    }
                    else if (InFillial)
                    {
                        Users.All_users[Index].Orders[index1].Status = "In filial";
                    }
                    else if (Shipped)
                    {
                        Users.All_users[Index].Orders[index1].Status = "Shipped";
                    }
                    else if (HandedOver)
                    {
                        Users.All_users[Index].Orders[index1].Status = "Handed over";
                    }
                    else if (Paid)
                    {
                        Users.All_users[Index].Orders[index1].Status = "Paid";
                    }
                    else if (Ordered)
                    {
                        Users.All_users[Index].Orders[index1].Status = "Ordered";
                    }
                if (count == OrdersList.Count)

                {
                    OrdersList = new();
                    foreach (User user in Users.All_users)
                    {
                        foreach (Order order in user.Orders)
                        {

                            OrdersList.Add(order);
                        }
                    }
                    using var fs = new FileStream("UsersInfo.json", FileMode.Truncate);
                    JsonSerializer.Serialize(fs, Users.All_users);
                }
                else
                {
                    OrdersList = new(Users.All_users[Index].Orders);
                    using var fs = new FileStream("UsersInfo.json", FileMode.Truncate);
                    JsonSerializer.Serialize(fs, Users.All_users);
                
                }

                }                   

                   
                
            });

        }
        public RelayCommand LogOutCommand
        {

            get => new(() =>
            {
                _navigationService?.NavigateTo<LoginViewModel>();

            });
        }
        public RelayCommand ViewAllCommand
        {

            get => new(() =>
            {
                OrdersList.Clear();
                foreach (User user in Users.All_users)
                {
                    foreach (Order order in user.Orders)
                    {
                        OrdersList.Add(order);
                    }
                }
            });
        }
    }
}
