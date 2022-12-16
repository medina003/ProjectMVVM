using CargoCompanyWPF.Message;
using CargoCompanyWPF.Model;
using CargoCompanyWPF.Services.Classes;
using CargoCompanyWPF.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace CargoCompanyWPF.ViewModel
{
    public class RegistrationViewModel : ViewModelBase
    {
        public User? User { get; set; } = new();

        public Error? Error { get; set; } = new();

        private readonly INavigationService? _navigationService;


        public RegistrationViewModel(INavigationService? navigationService)
        {
            _navigationService = navigationService;

        }
        public RelayCommand<object> Register
        {

            get => new(param =>
            {
                var errors = IsValid_check.IsValidForRegistrationVM(User);

                Error = errors.Item1;

                if (errors.Item2)
                {
                    UserIndex.Index = WriteToFileService.WriteUserInfo(User);

                    _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = User });
                }

            });
        }
        public RelayCommand BackCommand
        {
            get => new(() =>
            {
                User = new();
                Error = new();
                _navigationService?.NavigateTo<LoginViewModel>();

            });
        }

    }
}
