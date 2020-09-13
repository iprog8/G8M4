using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class UploadImagineViewModel
    {
        public Imagine Imagine { get; set; } = new Imagine();
        public string Message { get; set; }
        public Poza Poza { get; set; } = new Poza();
    }
}