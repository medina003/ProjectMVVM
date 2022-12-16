using CargoCompanyWPF.Message;
using CargoCompanyWPF.Model;
using CargoCompanyWPF.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Data;

namespace CargoCompanyWPF.ViewModel
{
    public class UserdashboardViewModel : ViewModelBase
    {

        public User? User { get; set; } = new();
        public ItemsView? ItemsView { get; set; } = new();
        public Statuses? Statuses { get; set; }

        private INavigationService? _navigationService;
        private readonly IMessenger? _messenger;
        private string _selectedvalue = "All";
        private string _selectedvalue2 = "All";
        public string SelectedValue
        {
            get
            {
                return _selectedvalue;
            }
            set
            {
                _selectedvalue = value;
                ItemsView?.Orders?.Refresh();
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
                ItemsView?.Packages?.Refresh();
            }
        }
        public UserdashboardViewModel(INavigationService? navigationService, IMessenger? messenger = null)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger?.Register<ParameterMessage>(this, param =>
            {
                User = (param?.Message) as User;
                if (User != null)
                {

                    User = Users.All_users[UserIndex.Index]?.Copy();
                    Statuses = new();
                    ItemsView.Orders = new CollectionViewSource { Source = User?.Orders }.View;
                    ItemsView.Orders.Filter = post => { if (SelectedValue == "All") { return ((Order)post).Status != "" && ((Order)post).Ordered == true; } else return SelectedValue == null || SelectedValue == ((Order)post).Status; };
                    ItemsView.Packages = new CollectionViewSource { Source = User?.Orders }.View;
                    ItemsView.Packages.Filter = post => { if (SelectedValue2 == "All") { return ((Order)post).Status != ""; } else return SelectedValue2 == null || SelectedValue2 == ((Order)post).Status; };
                }
            });
        }

        public RelayCommand PrivateInfoCommand
        {
            get => new(() =>
            {

                _navigationService?.NavigateTo<PrivateInfoViewModel>(new ParameterMessage() { Message = User });
            });
        }
        public RelayCommand PlaceOrderCommand
        {
            get => new(() =>
            {

                _navigationService?.NavigateTo<PlaceOrderViewModel>(new ParameterMessage() { Message = User });
            });
        }
        public RelayCommand DeclareCommand
        {
            get => new(() =>
            {
                _navigationService?.NavigateTo<DeclareViewModel>();
            });
        }
        public RelayCommand IncreasingBalanceCommand
        {
            get => new(() =>
            {
                _navigationService?.NavigateTo<IncreasingBalanceViewModel>();
            });
        }

        public RelayCommand LogOutCommand
        {
            get => new(() =>
            {
                User = new();
                _navigationService?.NavigateTo<LoginViewModel>(new ParameterMessage() { Message = User });
            });
        }

    }
}
