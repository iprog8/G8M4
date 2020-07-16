using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDbConnection
{
    class Program
    {
        static string connectionString = @"Data Source=IPRO\SQLEXPRESS;Initial Catalog=CRM;Persist Security Info=True;User ID=crmuser;Password=crmusr";
        static void Main(string[] args)
        {
            List<Supplier2> suppliers = new List<Supplier2>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Supplier";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            suppliers.Add(new Supplier2 { 
                                Ids = dataReader.GetInt32(0),
                                CompanyName = dataReader.GetString(1)
                            });
                            Console.WriteLine(dataReader.GetValue(0) + " - " + dataReader.GetValue(1));
                        }
                    }
                }
            }
            
            //suppliers = db.Supliers.All();
            
            Console.ReadKey();
        }
    }
    class Supplier2
    {
        public int Ids { get; set; }
        public string CompanyName { get; set; }
    }
}
