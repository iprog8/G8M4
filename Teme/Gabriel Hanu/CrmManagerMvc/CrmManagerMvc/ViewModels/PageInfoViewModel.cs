using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmManagerMvc.ViewModels
{
    public class PageInfoViewModel
    {
        public int ItemsPerPage { get; set; } = 10;
        public int CurentPage { get; set; }
        public double MaxPage { get; set; }
        public string ViewName { get; set; } = "Index";
        public double GetMaxPage(int totalItems)
        {
            return Math.Ceiling(totalItems / (double)ItemsPerPage);
        }
    }
}