using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmManagerMvc.ViewModels
{
    public class NavbarItemViewModel
    {
        public NavbarItemViewModel(string abbreviation, string text)
        {
            Abbreviation = abbreviation;
            TextToDisplay = text;
        }
        public string Abbreviation { get; set; }
        public string TextToDisplay { get; set; }
    }
}