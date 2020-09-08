using CrmManagerMvc.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Routing;

namespace CrmManagerMvc.ViewModels
{
    public class LanguageViewModel
    {
        private string Language { get; set; }
        private string Theme { get; set; }
        private string[] RouteParams { get; set; }
        public string GetUrlFor(RouteTypes routeType, string value)
        {
            if(RouteParams != null)
            {
                RouteParams[(int)routeType] = value;
                if (RouteParams.Length > 3)
                {
                    string NewUrl = string.Empty;
                    for(int i = 1; i < RouteParams.Length; i++)
                    {
                        NewUrl += $"/{RouteParams[i]}";
                    }
                    return NewUrl;
                }
            }
            switch (routeType)
            {
                case RouteTypes.Theme:
                    Theme = value;
                    break;
                case RouteTypes.Language:
                    Language = value;
                    break;
                default:
                    break;
            }
            return $"/{Theme}/{Language}";
        }
        public void GetValues(string fullUrl, RouteData routeData)
        {
            Theme = (string)routeData.Values["theme"];
            Language = (string)routeData.Values["language"];
            if (fullUrl == "/") return;
            RouteParams = fullUrl.Split('/');
        }
    }
}