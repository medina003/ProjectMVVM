using CargoCompanyWPF.Model;
using System;
using System.Collections.ObjectModel;

namespace CargoCompanyWPF.Services.Classes
{
    public static class Last30DaysService
    {
        public static double? CountBalance(ObservableCollection<Order> orders)
        {

            double? result = 0;
            foreach (Order order in orders)
            {
                if (order.Ordered)
                {
                    if ((order.dateTime - DateTime.Now).TotalDays < 31)
                    {
                        result += Convert.ToDouble(order.Amount) * Convert.ToDouble(order.Quantity);
                    }

                }

            }
            return result;

        }
    }
}
