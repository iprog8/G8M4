using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModels
{
    public class CustomerIndexViewModel: IndexViewModel
    {
        public ICollection<CustomerViewModel> CustomerList { get; set; }
    }
}