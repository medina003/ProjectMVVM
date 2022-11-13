using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CargoCompanyWPF.Model
{
    public class User_info
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }    
        public string? Adress { get; set; }
        public string? Phone { get; set; }  
        public string? Serial { get; set; }  
        public string? FIN { get; set; }
        public BitmapImage? Img { get; set; }   
        public Order[]? Orders { get; set; }
    }

    public class Order
    {
        public string? Tracking_number {get;set;}
        public string? Amount { get;set;}
        public string? Link { get;set;}
        public string? Size { get;set;} 
        public string? Color { get;set;}
        public string? Quantity { get; set; }
        public string? Notes { get; set; }
        public string? Shop_delivery_price { get; set; }
        public BitmapImage? Invoice_image { get; set; }
        public bool Contains_liquid { get; set; }
        public string? Category { get; set; }
        public bool In_Foreign_Warehouse { get; set; }
        public bool On_the_way { get; set; }
        public bool Received { get; set; }
        public bool Handed_over { get; set; }
        public bool  Preliminary_declaration { get; set; }
        public bool Purchase_requests { get; set; }
        public Balance? Balance_on_acc { get; set; }
        public Order_operation? Operation { get; set; }
    }

    public class Balance
    {

        public double? Balance_for_delivery { get; set; }
        public double? Balance_for_purchase { get; set; }
        public double? Cashback { get; set; }
        public double? Discount { get; set; }
    }

    public class Order_operation
    {
        public DateTime? dateTime { get; set; }
        public double? price { get; set; }
    }
}
