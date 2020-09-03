using CrmManagerMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmManagerMvc.ViewModels
{
    public class SupplierIndexViewModel
    {
        public ICollection<SupplierViewModel> SupplierList { get; set; }
        public PageInfoViewModel PageInfo { get; set; } = new PageInfoViewModel();
        public TranslationViewModel Translations { get; set; } = new TranslationViewModel();
    }
}