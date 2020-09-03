using CrmManagerMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmManagerMvc.Models
{
    public class CustomersDetails
    {
        public int TotalCustomers { get; set; }
        public TranslationViewModel Translations { get; set; } = new TranslationViewModel();
    }
}