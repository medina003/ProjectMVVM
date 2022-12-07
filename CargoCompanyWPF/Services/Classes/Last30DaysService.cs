using CargoCompanyWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            result += Convert.ToDouble(order.Amount);
                        }

                    }

                }
                return result;
            
        }
    }
}
