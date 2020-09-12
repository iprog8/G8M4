using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class ArticolIndexViewModel
    {
        public ICollection<ArticolViewModel> ListaArticole { get; set; } = new List<ArticolViewModel>();
        public PaginareViewModel Paginare { get; set; } = new PaginareViewModel();
    }
}