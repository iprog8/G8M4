using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModels
{
    public class PageInfoViewModel
    {
        public int CurrentPage { get; set; } = 1;
        public double MaxPage { get; set; }
        public string ViewName { get; set; } = "Index";
    }
}