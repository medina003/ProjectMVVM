using CargoCompanyWPF.Message;
using CargoCompanyWPF.Model;
using CargoCompanyWPF.Services.Classes;
using CargoCompanyWPF.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.IO;
using System.Text.Json;

namespace CargoCompanyWPF.ViewModel
{
    public class PrivateInfoViewModel : ViewModelBase
    {

        public User? User { get; set; } = new();
        public Error Error { get; set; } = new();
        private INavigationService? _navigationService;
        private readonly IMessenger _messenger;
        public PrivateInfoViewModel(INavigationService? navigationService, IMessenger messenger = null)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {

                User = param?.Message as User;
                User = User?.Copy();

            });
        }

        public RelayCommand SaveCommand
        {
            get => new(() =>
            {
                var errors = IsValid_check.IsValidForChangesVM(User);
                Error = errors.Item1;
                if (errors.Item2)
                {
                    Users.All_users[UserIndex.Index] = User;
                    SerializeService.Serialize("UsersInfo.json", Users.All_users!);
                    _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = User });
                }

            });
        }
        public RelayCommand BackCommand
        {
            get => new(() =>
            {

                _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = User });

            });
        }
    }
}
