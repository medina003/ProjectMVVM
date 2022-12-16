using CargoCompanyWPF.Message;
using CargoCompanyWPF.Services.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CargoCompanyWPF.Model
{
    public static class Users
    {
        public static List<User?> All_users { get; set; } = new();
    }
    public class User : ISendable
    {
        public string? UserID { get; set; } = String.Empty;
        public string? FirstName { get; set; } = String.Empty;
        public string? LastName { get; set; } = String.Empty;
        public string? Email { get; set; } = String.Empty;
        public string? Password { get; set; } = String.Empty;
        public string? PasswordConfirmation { get; set; } = String.Empty;
        public string? Address { get; set; } = String.Empty;
        public string? Phone { get; set; } = String.Empty;
        public string? Serial { get; set; } = String.Empty;
        public string? FIN { get; set; } = String.Empty;
        public ObservableCollection<Order?>? Orders { get; set; } = new();
        public Balance? Balance_on_acc { get; set; } = new();
        public List<Order_operation?>? Operation { get; set; }
        public double? Last30Days
        {
            get
            {
                return Last30DaysService.CountBalance(this?.Orders!);
            }
            set
            {
            }
        }
        public User Copy()
        {
            User temp = new();
            temp.FirstName = this.FirstName;
            temp.LastName = this.LastName;
            temp.Email = this.Email;
            temp.Password = this.Password;
            temp.PasswordConfirmation = this.PasswordConfirmation;
            temp.Address = this.Address;
            temp.Phone = this.Phone;
            temp.Serial = this.Serial;
            temp.FIN = this.FIN;
            temp.Orders = new(this?.Orders!);
            temp.Balance_on_acc = this?.Balance_on_acc!;
            temp.Operation = this?.Operation;
            temp.Last30Days = this.Last30Days;
            return temp;
        }


    }

    public class Order
    {
        public string? OrderFin { get; set; }
        public string? Tracking_number { get; set; }
        public string? Amount { get; set; } = String.Empty;
        public string? Link { get; set; } = String.Empty;
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Quantity { get; set; } = String.Empty;
        public string? Notes { get; set; }
        public double TotalPrice { get; set; } = 0;
        public Uri? Uri { get; set; }
        public string? Category { get; set; }
        public bool Declared_on_website { set; get; } = false;
        public bool Ordered { set; get; } = false;
        public DateTime dateTime { get; set; } = new();
        public string? Status { get; set; } = "All";

    }

    public class Balance
    {

        public double? Balance_for_delivery { get; set; } = 0;
        public double? Balance_for_purchase { get; set; } = 0;
        public double? Cashback { get; set; }
        public double? Discount { get; set; }
    }

    public class Order_operation
    {

        public double? Price { get; set; }
        public DateTime DateTime { get; set; } = new();
    }

}
