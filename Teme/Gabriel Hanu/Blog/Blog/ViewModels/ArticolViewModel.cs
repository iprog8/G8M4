using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class ArticolViewModel
    {
        public ArticolViewModel()
        {
            ListaComentarii = new List<Comentariu>();
            ListaPoze = new List<Poza>();
        }
        public int Id { get; set; }
        public string Titlu { get; set; }
        public DateTime DataCreare { get; set; }
        public string Text { get; set; }
        public ICollection<Comentariu> ListaComentarii { get; set; }
        public ICollection<Poza> ListaPoze { get; set; }

    }
}