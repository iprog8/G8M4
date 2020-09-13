using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class ComentariuViewModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Titlu { get; set; }
        public string Text { get; set; }
        public DateTime DataCreare { get; set; }
        public bool Edited { get; set; }
        public bool Aprobat { get; set; }
    }
}