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
            List<Client> clienti = new List<Client>();
            List<Order> orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string firstQuery = "Select * from Customer";
                string secondQuery = "Select * from [Order] where TotalAmount > 1000";
                using (SqlCommand cmd = new SqlCommand(firstQuery, con))
                {
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            clienti.Add(new Client(dataReader.GetInt32(0),dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5)));
                        }
                    }
                }
                using (SqlCommand cmd2 = new SqlCommand(secondQuery,con))
                {
                    using (var dataReader = cmd2.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            orders.Add(new Order(dataReader.GetInt32(0),dataReader.GetDateTime(1),dataReader.GetString(2),dataReader.GetInt32(3),dataReader.GetDecimal(4)));
                        }
                    }
                }
                con.Close();
            }
            for(int i = 0; i < clienti.Count; i++)
            {
                Console.WriteLine($"{clienti[i].Id} - {clienti[i].FirstName} {clienti[i].LastName} - {clienti[i].Country}");
            }
            for(int j = 0; j < orders.Count; j++)
            {
                Console.WriteLine($"{orders[j].Id} - {orders[j].CustomerId} - {orders[j].TotalAmount}");
            }
            Console.ReadKey();
        }
    }
}
