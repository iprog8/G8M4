using CrmManagerMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace CrmManagerMvc.ViewModels
{
    public class TranslationViewModel
    {
        public TranslationViewModel()
        {
            Translations = new List<Translation>();
        }
        private string Code { get; set; }
        private string Language { get; set; }
        private ICollection<Translation> Translations { get; set; }
        public string GetTextFor(string text)
        {
            var translation = Translations.FirstOrDefault(t => t.Code == Code + text);
            if (translation is null)
                return "_untranslated";
            else
                return translation.Text;
        }
        public void GetTranslations(CRMEntities db, RouteData routeData)
        {
            Language = routeData.Values["language"].ToString() != "" ? routeData.Values["language"].ToString() : "en";
            Code = $"{routeData.Values["controller"]}_{routeData.Values["action"]}_";
            Translations = db.Translations.Where(t => t.Code.Contains(Code) && t.Lang == Language).ToList();
        }
    }
}