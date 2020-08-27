using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModels
{
    public class CustomerIndexViewModel
    {
        public CustomerIndexViewModel()
        {
            CustomerList = new List<CustomerViewModel>();
            PageInfo = new PageInfoViewModel();
        }
        public ICollection<CustomerViewModel> CustomerList { get; set; }
        public PageInfoViewModel PageInfo { get; set; }

    }
}