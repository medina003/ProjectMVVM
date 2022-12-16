using CargoCompanyWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CargoCompanyWPF.Services.Classes
{
    public static class PaymentService
    {
        public static bool IsPayable(Order? Order, User? User)
        {
            if (Convert.ToDouble(Users.All_users[UserIndex.Index]!.Balance_on_acc!.Balance_for_purchase) < (Convert.ToDouble(Order?.Amount) * Convert.ToDouble(Order?.Quantity)))
            {
                MessageBox.Show("You don't have enough money on the balance");
                return false;
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to pay?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Order.TotalPrice = (Convert.ToDouble(Order?.Amount)) * (Convert.ToDouble(Order?.Quantity));
                    Users.All_users[UserIndex.Index]!.Balance_on_acc!.Balance_for_purchase -= Order?.TotalPrice;
                    Order.Ordered = true;
                    Order.Status = "Paid";
                    Order.OrderFin = Users.All_users[UserIndex.Index].FIN;
                    Users.All_users[UserIndex.Index]!.Orders!.Add(Order);
                    Order.dateTime = DateTime.Now;
                    return true;
                }
                return false;

            }
        }
    }
}

