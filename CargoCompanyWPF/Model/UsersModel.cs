using CargoCompanyWPF.Message;
using CargoCompanyWPF.Services.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CargoCompanyWPF.Model
{
    public static class Users
    {
        public static List<User?> All_users { get; set; } = new();
    }
    public class User : ISendable
    {
        public string? UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [JsonIgnore]
        public string? PasswordConfirmation { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Serial { get; set; }
        public string? FIN { get; set; }
        public BitmapImage? Img { get; set; }
        public ObservableCollection<Order?>? Orders { get; set; } = new();
        public Balance? Balance_on_acc { get; set; } = new();
        public List<Order_operation?>? Operation { get; set; }
        public Statuses? Statuses { get; set; } = new();
        public double? Last30Days
        {
            get
            {
                return Last30DaysService.CountBalance(this?.Orders!);
            }
        }



    }

    public class Order
    {
        //public override string ToString()
        // {
        //     return "Person: " + Link + " " + Amount;
        // }
        public string? OrderFin { get; set; }
        public string? Tracking_number { get; set; }
        public string? Amount { get; set; }
        public string? Link { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Quantity { get; set; }
        public string? Notes { get; set; }
        public string? Shop_delivery_price { get; set; }
        public BitmapImage? Invoice_image { get; set; }
        public bool Contains_liquid { get; set; }
        public string? Category { get; set; }
        public bool Declared_on_website { set; get; } = false;
        public bool Ordered { set; get; } = false;
        //public bool In_Foreign_Warehouse { get; set; } = false;
        //public bool On_the_way { get; set; } = false;
        //public bool Received { get; set; } = false;
        //public bool Handed_over { get; set; } = false;
        public bool Purchase_requests { get; set; } = false;
        public DateTime dateTime { get; set; } = new();
        public string? Status { get; set; } = "All";
        //public Balance? Balance_on_acc { get; set; }
        //public List<Order_operation?>? Operation { get; set; }

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
        public DateTime DateTime { get; set; } = new(); }

        //    public static void CountBalance()
        //    {
        //        foreach (Order order in Users.All_users[(int)Index].Orders)
        //        {
        //            if (order.Ordered)
        //            {
        //                if ((order.dateTime - DateTime.Now).TotalDays > 31)
        //                {

        //                }

        //            }

        //        }
        //    }
        //}

        public class Statuses
        {
            public ObservableCollection<string?>? OrderStatuses { get; set; } = new() { "All", "Paid", "Ordered" };
            public ObservableCollection<string?>? PackageStatuses { get; set; } = new() { "All", "Ordered", "In abroad warehouse", "Shipped", "In filial", "Handed over" };

        }
    
}
