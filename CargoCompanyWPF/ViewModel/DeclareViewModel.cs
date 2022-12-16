using CargoCompanyWPF.Message;
using CargoCompanyWPF.Model;
using CargoCompanyWPF.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using CargoCompanyWPF.Services.Classes;

namespace CargoCompanyWPF.ViewModel
{
    public class DeclareViewModel:ViewModelBase
    {
        public BitmapImage? bitmapImage { get; set; } = new();
        public User? User { get; set; } = new();
        public Order? Order { get; set; } = new();
        public Error? Error { get; set; } = new();
        private INavigationService? _navigationService;
        public DeclareViewModel(INavigationService? navigationService)
        {
            _navigationService = navigationService;
            
        }

        public RelayCommand LoadImageCommand
        {
            get => new(() =>
            {
                OpenFileDialog openImage = new();
                openImage.Filter = "Image files(*.PNG, *.JPG, *.BMP)|*.png;*.jpg;*.bmp";
                if (openImage.ShowDialog() == true)
                {
                   
                    Order!.Uri = new Uri(openImage.FileName);
                    bitmapImage = new(Order.Uri);

                }
            });
        }
        public RelayCommand SaveCommand
        {
            get => new(() =>
            {
                
                    var errors = IsValid_check.IsValidForDeclareVM(Order);

                    Error = errors!.Item1!;

                    if (errors.Item2)
                    {
                    DeclarationService.DeclareProcess(Order);
                    SerializeService.Serialize("UsersInfo.json", Users.All_users!);
                    Order = new();
                    Error = new();
                    bitmapImage = new();
                    _navigationService?.NavigateTo<UserdashboardViewModel>(new ParameterMessage() { Message = User });
                    }
                
            });
        }
        public RelayCommand BackCommand
        {
            get => new(() =>
            {
                Order = new();
                Error = new();
                bitmapImage = new();
                _navigationService?.NavigateTo<UserdashboardViewModel>();

            });
        }

    }

}
