using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class PaginareViewModel
    {
        public int ItemsPerPage { get; set; } = 10;
        public int CurentPage { get; set; }
        public int MaxPage { get; set; }
        public void GetMaxPage(double totalItems)
        {
            MaxPage = (int)Math.Ceiling(totalItems / (double)ItemsPerPage);
        }
    }
}