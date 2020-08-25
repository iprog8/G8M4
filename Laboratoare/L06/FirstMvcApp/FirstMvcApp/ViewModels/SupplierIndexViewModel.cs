using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModels
{
    public class SupplierIndexViewModel
    {

        public SupplierIndexViewModel()
        {
            PageInfo = new PageInfoViewModel();
            SortInfo = new SortInfoViewModel();
            FilterInfo = new FilterInfoViewModel();
        }
        public ICollection<SupplierViewModel> SupplierList { get; set; }
        public PageInfoViewModel PageInfo { get; set; } = new PageInfoViewModel();
        public SortInfoViewModel SortInfo { get; set; } = new SortInfoViewModel();
        public FilterInfoViewModel FilterInfo { get; set; }
    }
}