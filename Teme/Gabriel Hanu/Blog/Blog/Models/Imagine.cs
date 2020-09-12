using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Imagine
    {
        public const string CaleImagini = "/ImaginiArticol";
        public string Cale { get; set; }
        public byte[] Poza { get; set; }
    }
}