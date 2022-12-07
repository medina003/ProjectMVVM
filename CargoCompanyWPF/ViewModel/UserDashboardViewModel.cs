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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CargoCompanyWPF.ViewModel
{
    public class UserdashboardViewModel:ViewModelBase
    {
        public string? Name { get; set; }
        public int? Index { get; set; }
        public User User { get; set; } = new();
        public Balance? Balance { get; set; } = new();
        public IEnumerable<Order> Ordered { get; set; } 
        public List<Order> Declared { get; set; } = new();

        public ICollectionView PostsView { get; set; }
        public ICollectionView PostsView2 { get; set; }

        public ObservableCollection<Order> Items { get; set; } = new();
        public ObservableCollection<string> Strings { get; set; } = new();
        public ObservableCollection<string> Strings2 { get; set; } = new();

        private INavigationService? _navigationService;
        private string _selectedvalue = "All";
        private string _selectedvalue2 = "All";

        private readonly IMessenger _messenger;
        public UserdashboardViewModel(INavigationService? navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                Index = param?.Message;
                if (Index != null) { Name = Users.All_users[(int)Index]?.FirstName; 
                                Balance = Users.All_users[(int)Index]?.Balance_on_acc;
                    User = new();
                    User = Users.All_users[(int)Index];
                    Ordered = User.Orders.Where(order => order.Ordered == true);
                    Strings = User.Statuses.OrderStatuses;
                    Strings2 = User.Statuses.PackageStatuses;
                    //Items = User.Orders;
                    PostsView = new CollectionViewSource { Source = User.Orders }.View;
                    PostsView.Filter = post => { if (SelectedValue == "All") { return ((Order)post).Status != "" && ((Order)post).Ordered == true; } else return SelectedValue == null || SelectedValue == ((Order)post).Status; };
                    PostsView2 = new CollectionViewSource { Source = User.Orders }.View;
                    PostsView2.Filter = post => { if (SelectedValue2 == "All") { return ((Order)post).Status != ""; } else return SelectedValue2 == null || SelectedValue2 == ((Order)post).Status; };



                }
                //index = All_users
            });
        }
        public string SelectedValue
        {
            get
            {
                return _selectedvalue;
            }
            set
            {
                _selectedvalue = value;
                PostsView.Refresh();
            }
        }
        public string SelectedValue2
        {
            get
            {
                return _selectedvalue2;
            }
            set
            {
                _selectedvalue2 = value;
                PostsView2.Refresh();
            }
        }
        public RelayCommand PrivateInfoCommand
        {
            get => new(() =>
            {
                //App.Container.GetInstance<MainViewModel>().CurrentViewModel = App.Container.GetInstance<RegistrationViewModel>();
                _navigationService?.NavigateTo<PrivateInfoViewModel>(new ParameterMessage() { Message = Index });
            });
        }
        public RelayCommand PlaceOrderCommand
        {
            get => new(() =>
            {
                //App.Container.GetInstance<MainViewModel>().CurrentViewModel = App.Container.GetInstance<RegistrationViewModel>();
                _navigationService?.NavigateTo<PlaceOrderViewModel>(new ParameterMessage() { Message = Index });
            });
        }
        public RelayCommand DeclareCommand
        {
            get => new(() =>
            {
                //App.Container.GetInstance<MainViewModel>().CurrentViewModel = App.Container.GetInstance<RegistrationViewModel>();
                _navigationService?.NavigateTo<DeclareViewModel>(new ParameterMessage() { Message = Index });
            });
        }
        public RelayCommand IncreasingBalanceCommand
        {
            get => new(() =>
            {
                //App.Container.GetInstance<MainViewModel>().CurrentViewModel = App.Container.GetInstance<RegistrationViewModel>();
                _navigationService?.NavigateTo<IncreasingBalanceViewModel>(new ParameterMessage() { Message = Index });
            });
        }

        public RelayCommand LogOutCommand
        {
            get => new(() =>
            {
                //App.Container.GetInstance<MainViewModel>().CurrentViewModel = App.Container.GetInstance<RegistrationViewModel>();
                _navigationService?.NavigateTo<LoginViewModel>();
            });
        }



    }
}
