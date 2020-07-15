using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tema_Lab_1
{
    class Program
    {
        static string connectionSting = @"Data Source=DRACONES\SQLEXPRESS;Initial Catalog = CRM; Persist Security Info=True;User ID = crmuser; Password=crmpass";
        static void Main(string[] args)
        {
            List<Customers> customers = new List<Customers>();
            List<Order> orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(connectionSting))
            {   
                con.Open();
                string query1 = "Select * from Customer";
                string query2 = "select * from [Order] where TotalAmount > 1000";
                using (SqlCommand cmd = new SqlCommand(query1, con))            
                {
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customers.Add(new Customers
                            {
                                Id = dataReader.GetInt32(0),
                                FirstName = dataReader.GetString(1),
                                LastName = dataReader.GetString(2),
                                City = dataReader.GetString(3),
                                Country = dataReader.GetString(4),
                                Phone = dataReader.GetString(5),
                            }) ;
                           
                        }
                        for (int i = 0; i < customers.Count; i++)
                        {
                            Console.WriteLine(customers[i].Id + " - " + customers[i].FirstName + " - " + customers[i].LastName + " - " +
                                " - " + customers[i].City + " - " + customers[i].Country + " - " + customers[i].Phone);
                        }
                    }
                }
                Console.WriteLine();
                using (SqlCommand cmd2 = new SqlCommand(query2, con))
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
                        for (int i = 0; i < orders.Count; i++)
                        {
                            Console.WriteLine(orders[i].Id + " - " + orders[i].OrderNumber + " - " + orders[i].CustomerId + " - " + orders[i].TotalAmount);
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
    class Customers
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public string City;
        public string Country;
        public string Phone;

    }
    class Order
    {
        public int Id;
        public string OrderNumber;
        public int CustomerId;
        public decimal TotalAmount;

    }
}
