//using CargoCompanyWPF.Model;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CargoCompanyWPF.Services.Classes
//{
//    public static class StatusSelectingService
//    {
//        public static ObservableCollection<Order?>? StatusSelect(RadioButtonStatuses RadioButtonStatuses, ObservableCollection<Order?>? OrdersList,int Index, Order? SelectedOrder, bool IsAllSelected)
//        {
//            int count = 0;
//            foreach (User user in Users.All_users)
//            {

//                count += user.Orders.Count;
//            }
//            if (IsAllSelected)
//            {
//                if (count == OrdersList.Count)
//                {
//                    foreach (User user in Users.All_users)
//                    {
//                        foreach (Order order in user.Orders)
//                        {
//                            if (RadioButtonStatuses!.InAbroad)
//                            {
//                                order.Status = "In abroad warehouse";
//                            }
//                            else if (RadioButtonStatuses!.InFillial)
//                            {
//                                order.Status = "In filial";
//                            }
//                            else if (RadioButtonStatuses!.Shipped)
//                            {
//                                order.Status = "Shipped";
//                            }
//                            else if (RadioButtonStatuses.HandedOver)
//                            {
//                                order.Status = "Handed over";
//                            }
//                            else if (RadioButtonStatuses!.Paid)
//                            {
//                                order.Status = "Paid";
//                            }
//                            else if (RadioButtonStatuses!.Ordered)
//                            {
//                                order.Status = "Ordered";
//                            }
//                        }

//                    }
//                    OrdersList = new();
//                    foreach (User user in Users.All_users)
//                    {
//                        foreach (Order order in user.Orders)
//                        {

//                            OrdersList.Add(order);
//                        }
//                    }
//                    SerializeService.Serialize("UsersInfo.json", Users.All_users!);
//                    return OrdersList;
//                }
//                else
//                {
//                    Index = Users.All_users.FindIndex((u => (u?.FIN)?.ToLower() == OrdersList[0]?.OrderFin?.ToLower()));
//                    foreach (Order order in Users.All_users[Index].Orders)
//                    {
//                        if (RadioButtonStatuses!.InAbroad)
//                        {
//                            order.Status = "In abroadwarehouse";
//                        }
//                        else if (RadioButtonStatuses!.InFillial)
//                        {
//                            order.Status = "In filial";
//                        }
//                        else if (RadioButtonStatuses!.Shipped)
//                        {
//                            order.Status = "Shipped";
//                        }
//                        else if (RadioButtonStatuses!.HandedOver)
//                        {
//                            order.Status = "Handed over";
//                        }
//                        else if (RadioButtonStatuses!.Paid)
//                        {
//                            order.Status = "Paid";
//                        }
//                        else if (RadioButtonStatuses!.Ordered)
//                        {
//                            order.Status = "Ordered";
//                        }
//                    }
//                    OrdersList = new(Users.All_users[Index].Orders);
//                    return OrdersList;
//                }


//            }
//            else
//            {

//                Index = Users.All_users.FindIndex((u => (u?.FIN)?.ToLower() == SelectedOrder?.OrderFin?.ToLower()));
//                int index1 = Users.All_users[Index].Orders.IndexOf(SelectedOrder);


//                if (RadioButtonStatuses!.InAbroad)
//                {
//                    Users.All_users[Index].Orders[index1].Status = "In abroad warehouse";
//                }
//                else if (RadioButtonStatuses!.InFillial)
//                {
//                    Users.All_users[Index].Orders[index1].Status = "In filial";
//                }
//                else if (RadioButtonStatuses!.Shipped)
//                {
//                    Users.All_users[Index].Orders[index1].Status = "Shipped";
//                }
//                else if (RadioButtonStatuses!.HandedOver)
//                {
//                    Users.All_users[Index].Orders[index1].Status = "Handed over";
//                }
//                else if (RadioButtonStatuses!.Paid)
//                {
//                    Users.All_users[Index].Orders[index1].Status = "Paid";
//                }
//                else if (RadioButtonStatuses!.Ordered)
//                {
//                    Users.All_users[Index].Orders[index1].Status = "Ordered";
//                }
//                if (count == OrdersList.Count)

//                {
//                    OrdersList = new();
//                    foreach (User user in Users.All_users)
//                    {
//                        foreach (Order order in user.Orders)
//                        {

//                            OrdersList.Add(order);
//                        }
//                    }
//                    SerializeService.Serialize("UsersInfo.json", Users.All_users!);
//                    return OrdersList;
//                }
//                else
//                {
//                    OrdersList = new(Users.All_users[Index].Orders);
//                    SerializeService.Serialize("UsersInfo.json", Users.All_users!);
//                    return OrdersList;
//                }

//            }



      
//        }
//    }
//}
