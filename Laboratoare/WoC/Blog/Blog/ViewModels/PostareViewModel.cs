using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class PostareViewModel
    {
        public string Titlu { get; set; }
        public DateTime DataCrearii { get; set; }
        public DateTime? UltimulUpdate { get; set; }
        public string Autor { get; set; }
        public ICollection<Poza> Poze { get; set; }
        public string Text { get; set; }
        public int Id { get; set; }
        public bool Publicata { get; set; }
    }
}