using EFandLambdaExpressions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFandLambdaExpressions
{
    public class Client
    {
        public void Insert(string oras, string tara, string nume, string prenume, string telefon)
        {
            CRMEntities db = new CRMEntities();
            Customer client = new Customer();
            client.City = oras;
            client.Country = tara;
            client.FirstName = nume;
            client.LastName = prenume;
            client.Phone = telefon;
            db.Customer.Add(client);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            CRMEntities db = new CRMEntities();
            Customer toBeDeleted = db.Customer.FirstOrDefault(s => s.Id == id);
            if(toBeDeleted != null)
            {
                db.Customer.Remove(toBeDeleted);
                db.SaveChanges();
            }
        }

        public void Update(int id, string nume, string prenume)
        {
            CRMEntities db = new CRMEntities();
            Customer toBeUpdated = db.Customer.Find(id);
            if(toBeUpdated != null)
            {
                toBeUpdated.FirstName = nume;
                toBeUpdated.LastName = prenume;
                db.SaveChanges();
            }
        }

        public ICollection<Customer> SelectByCity(string oras)
        {
            CRMEntities db = new CRMEntities();
            ICollection<Customer> cautaClientDupaOras = db.Customer.Where(c => c.City == oras).ToList();
            Console.WriteLine($"Numarul de clienti care locuiesc in orasul {oras} sunt : {cautaClientDupaOras.Count}");
            return cautaClientDupaOras;
        }
    }
}
