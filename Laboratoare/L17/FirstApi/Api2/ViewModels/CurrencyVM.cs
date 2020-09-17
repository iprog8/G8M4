using Api2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api2.ViewModels
{
    public class CurrencyVM
    {
        public CurrencyVM()
        {

        }

        public CurrencyVM(Currency currency)
        {
            Id = currency.Id;
            Valuta = currency.Valuta;
            Paritate = currency.Paritate;
        }

        public int Id { get; set; }
        public string Valuta { get; set; }
        public decimal Paritate { get; set; }
    }
}