using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FirstDbConnection
{
    class Program
    {
        static string connectionString = @"Data Source=BIBANU-PC\SQLEXPRESS;Initial Catalog=CRM;Persist Security Info=True;User ID=crmuser;Password=crmusr";
        static void Main(string[] args)
        {
            List<Customer> customers = GetCustomers();
            List<Orders> orders = GetOrders(1000);
            Console.ReadKey();
        }

        private static List<Orders> GetOrders(int price)
        {
            List<Orders> orders = new List<Orders>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Order";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            orders.Add(new Orders
                            {
                                Id = dataReader.GetInt32(0),
                                TotalAmount = dataReader.GetDouble(4)
                            });
                            Console.WriteLine(dataReader.GetValue(0) + " " + dataReader.GetValue(4));
                        }
                    }
                }
            }
            return orders;
        }

        private static List<Client> GetCustomers()
        {
            List<Client> customers = new List<Client>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Customer";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customers.Add(new Client
                            {
                                Id = dataReader.GetInt32(0),
                                Name = dataReader.GetString(1)
                            });
                            Console.WriteLine(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " " + dataReader.GetValue(2));
                        }
                    }
                }
            }
            return customers;
        }
    }
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Orders
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
    }
}
