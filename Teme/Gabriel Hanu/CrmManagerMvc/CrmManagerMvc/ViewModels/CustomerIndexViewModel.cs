using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmManagerMvc.ViewModels
{
    public class CustomerIndexViewModel
    {
        public ICollection<CustomerViewModel> CustomerList { get; set; }
        public PageInfoViewModel PageInfo { get; set; } = new PageInfoViewModel();
    }
}