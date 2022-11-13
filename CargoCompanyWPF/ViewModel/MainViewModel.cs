using CargoCompanyWPF.Message;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoCompanyWPF.ViewModel
{
    public  class MainViewModel:ViewModelBase
    {
        public ViewModelBase? CurrentViewModel { get; set; }

        private readonly IMessenger _messenger;

        public MainViewModel(IMessenger messenger)
        {
            CurrentViewModel = App.Container?.GetInstance<LoginViewModel>();

            _messenger = messenger;

            _messenger.Register<NavigationMessage?>(this, message =>
            {
                var viewModel = App.Container?.GetInstance(message?.ViewModelType) as ViewModelBase;
                CurrentViewModel = viewModel;
            });
        }

    }
}
