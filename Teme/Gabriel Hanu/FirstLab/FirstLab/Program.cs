using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab
{
    class Program
    {
        static string connectionString = @"Data Source=DESKTOP-HCGU07N\SQLEXPRESS;Initial Catalog=CRM;Persist Security Info=True;User ID=crmuser;Password=crmusr";
        static void Main(string[] args)
        {
            List<Client> clienti = GetCustomers();
            for(int i = 0; i < clienti.Count; i++)
            {
                Console.WriteLine($"{clienti[i].Id} - {clienti[i].FirstName} {clienti[i].LastName} - {clienti[i].Country}");
            }
            List<Order> orders = GetOrdersAbove(5000);
            for (int j = 0; j < orders.Count; j++)
            {
                Console.WriteLine($"{orders[j].Id} - {orders[j].CustomerId} - {orders[j].TotalAmount}");
            }
            Console.ReadKey();
        }
        private static List<Client> GetCustomers()
        {
            List<Client> clienti = new List<Client>();
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
                            clienti.Add(new Client(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5)));
                        }
                    }
                }
            }
            return clienti;
        }
        private static List<Order> GetOrdersAbove(int price)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = $"Select * from [Order] where TotalAmount > {price}";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            orders.Add(new Order(dataReader.GetInt32(0), dataReader.GetDateTime(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetDecimal(4)));
                        }
                    }
                }
            }
            return orders;
        }
    }
}
