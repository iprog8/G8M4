using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModels
{
    public class SupplierIndexViewModel: IndexViewModel
    {
        public ICollection<SupplierViewModel> SupplierList { get; set; }
    }
}