using FirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModels
{
    public class TranslationInfo
    {
        public TranslationInfo()
        {
            Translations = new List<Translation>();
        }
        public ICollection<Translation> Translations { get; internal set; }
        public string GetTranslation(string code)
        {
            var translation = Translations.FirstOrDefault(t => t.Code == code);
            if(translation == null)
            {
                return code + "_untranslated";
            }
            return translation.Text;
        }
    }
}