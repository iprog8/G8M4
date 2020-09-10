using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcApp.Models
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        public SelectList Suppliers { get; set; }
    }
}