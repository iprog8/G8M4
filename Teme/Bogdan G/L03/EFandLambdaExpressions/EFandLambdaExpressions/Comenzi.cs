using EFandLambdaExpressions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFandLambdaExpressions
{
    public class Comenzi
    {
        public ICollection<Order> GetAll()
        {
            CRMEntities db = new CRMEntities();
            ICollection<Order> comenzi = db.Order.ToList();
            Console.WriteLine("Comenzile mai mari de 5000 au ClientID si suma:");
            foreach ( var comanda in comenzi.Where(o => o.TotalAmount >= 5000))
            {
                if (comanda != null)
                {
                    Console.WriteLine($" {comanda.CustomerId} - {comanda.TotalAmount}");
                }
            }
            return comenzi;
        }

        public ICollection<Order> GetById(int customerId)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Order> comenziClient = db.Order.Where(o => o.CustomerId == customerId).ToList();
            Console.WriteLine($"Numarul de comenzi ale clientului cu id {customerId} este : {comenziClient.Count}");
            return comenziClient;
        }
    }
}
