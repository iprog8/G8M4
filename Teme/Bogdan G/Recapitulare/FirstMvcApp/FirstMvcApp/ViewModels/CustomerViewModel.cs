using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Country { get; set; }
        public string Phone { get; set; }

    }
}