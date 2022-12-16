using CargoCompanyWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoCompanyWPF.Services.Classes
{
    public static class DeclarationService
    {
        public static void DeclareProcess(Order? Order)
        {
        Order!.Declared_on_website = true;
        Order.Status = "Declared";
        Order.OrderFin = Users.All_users[UserIndex.Index]!.FIN;
        Order.dateTime = DateTime.Now;
        Order.TotalPrice = (Convert.ToDouble(Order?.Amount)) * (Convert.ToDouble(Order?.Quantity));
        Users.All_users[UserIndex.Index]!.Orders!.Add(Order);
        }
 
    }
}
