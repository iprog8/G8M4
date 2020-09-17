using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Api2.Models;
using Api2.ViewModels;

namespace Api2.Controllers
{
    public class CurrencyController : ApiController
    {
        private CRMEntities db = new CRMEntities();

        // GET: api/Currencie
        public ICollection<CurrencyVM> GetCurrencies()
        {
            return db.Currencies.Select(c => new CurrencyVM { 
                Id = c.Id,
                Valuta = c.Valuta,
                Paritate = c.Paritate
            }).ToList();
        }

        // GET: api/Currencie/5
        [ResponseType(typeof(CurrencyVM))]
        public IHttpActionResult GetCurrency(string codValuta)
        {
            Currency currency = db.Currencies.FirstOrDefault(c => c.Valuta == codValuta);
            if (currency == null)
            {
                return NotFound();
            }

            return Ok(new CurrencyVM(currency));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurrencyExists(int id)
        {
            return db.Currencies.Count(e => e.Id == id) > 0;
        }
    }
}