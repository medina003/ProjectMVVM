using CargoCompanyWPF.Services.Interfaces;
using CargoCompanyWPF.View;
using CargoCompanyWPF.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CargoCompanyWPF.Services.Classes;
using CargoCompanyWPF.Message;

namespace CargoCompanyWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container? Container { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            MainStartup();

            base.OnStartup(e);
        }
        private void Register()
        {
            Container = new();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<RegistrationViewModel>();

            Container.Verify();
        }
        private void MainStartup()
        {
            Window mainView = new MainView();

            mainView.DataContext = Container?.GetInstance<MainViewModel>();

            mainView.ShowDialog();
        }

    }
}
