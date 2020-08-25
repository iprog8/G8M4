using L7CrmManager_MVC_.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L7CrmManager_MVC_.Controllers
{
    public class CustomerController : Controller
    {   
        
        // GET: Customer
        public ActionResult Index()
        {
            var language = this.RouteData.Values.FirstOrDefault(s => s.Key == "lang").Value.ToString();

            switch (language) 
            {
                case "ro":
                    ViewBag.Title = "Lista clienti";
                    ViewBag.FirstName = "Prenume";
                    ViewBag.LastName = "NumeFamilie";
                    ViewBag.Country = "Tara";
                    ViewBag.City = "Oras";
                    ViewBag.Phone = "NrTelefon";
                    break;
                case "en":
                    ViewBag.Title = "Client List";
                    ViewBag.FirstName = "FirstName";
                    ViewBag.LastName = "LastName";
                    ViewBag.Country = "Country";
                    ViewBag.City = "City";
                    ViewBag.Phone = "Phone";
                    break;
                case "fr":
                    ViewBag.Title = "Liste de Clients";
                    ViewBag.FirstName = "Prenom";
                    ViewBag.LastName = "Nom";
                    ViewBag.Country = "Pays";
                    ViewBag.City = "Ville";
                    ViewBag.Phone = "NumeroTelephone";
                    break;
                default:
                    break;
            }
            CRMEntities db = new CRMEntities();
            ICollection<Customer> customers = db.Customers.ToList();


            return View(customers);
        }

        public ActionResult Details(int id) 
        {
            CRMEntities db = new CRMEntities();
            Customer model = db.Customers.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);

        }

    }

}