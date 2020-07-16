using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBconn
{
    class Program
    {
        static string connectionString = @"Data Source=DESKTOP-KIHHS03\SQLEXPRESS;Initial Catalog=CRM;Persist Security Info=True;User ID=tardy;Password=tardypass";
        static void Main(string[] args)
        {
            List<Client> customers = new List<Client>();
            List<Order> orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string querry1 = "Select * from Customer";
                string querry2 = "Select * from [Order] where TotalAmount > 1000";
                using (SqlCommand cmd = new SqlCommand(querry1, con))
                {
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customers.Add(new Client
                            {
                                Id = dataReader.GetInt32(0),
                                FirstName = dataReader.GetString(1),
                                LastName = dataReader.GetString(2),
                            });
                        }
                        foreach (Client i in customers)
                        {
                            Console.WriteLine(i.Id + " - " + i.FirstName + " - " + i.LastName);
                        }
                    }
                }

                Console.WriteLine("**************************************************************");
                Console.WriteLine("**************************************************************");
                Console.WriteLine("**************************************************************");


                using (SqlCommand cmd2 = new SqlCommand(querry2, con))
                {
                    using (var dataReader = cmd2.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            orders.Add(new Order
                            {
                                Id = dataReader.GetInt32(0),
                                OrderNumber = dataReader.GetString(2),
                                CustomerId = dataReader.GetInt32(3),
                                TotalAmount = dataReader.GetDecimal(4),
                            });

                        }
                        foreach (Order i in orders)
                        {
                            Console.WriteLine(i.Id + " - " + i.OrderNumber + " - " + i.CustomerId + " - " + i.TotalAmount);
                        }
                    }
                }

                    Console.ReadKey();
            }


        }
        class Client
        {
            public int Id;
            public string FirstName;
            public string LastName;
        }
        class Order
        {
            public int Id;
            public string OrderNumber;
            public int CustomerId;
            public decimal TotalAmount;

        }
    }
}
