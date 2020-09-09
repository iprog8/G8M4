using CrmManagerMvc.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using System.Reflection.Emit;
using System.ComponentModel;

namespace CrmManagerMvc.ViewModels
{
    public class LanguageViewModel
    {
        public LanguageViewModel()
        {
            RouteValues = new List<string>();
            SupportedLanguages = new List<NavbarItemViewModel>()
            {
                new NavbarItemViewModel("en","English"),
                new NavbarItemViewModel("ro","Romana"),
                new NavbarItemViewModel("fr","Francaise")
            }; 
            SupportedThemes = new List<NavbarItemViewModel>() 
            {
                new NavbarItemViewModel("theme-white","White"),
                new NavbarItemViewModel("theme-dark","Dark")
            };
        }
        public ICollection<NavbarItemViewModel> SupportedLanguages { get; set; }
        public ICollection<NavbarItemViewModel> SupportedThemes { get; set; }
        public string CurrentLanguage { get; set; }
        public string CurrentTheme { get; set; }
        private string[] RouteTemplate { get; set; }
        private ICollection<string> RouteValues { get; set; }
        public string GetUrlFor(RouteTypes routeType, string value)
        {
            List<string> CopiedRouteValues = new List<string>(RouteValues);//copy the default route parameters to make sure that those don't change
            string UrlToReturn = string.Empty;//empty the url to make sure those don't stack
            int index = GetIndexOf(routeType);//get the index of the route type
            if(index != -1) CopiedRouteValues[index] = value;//make sure it's a valid number
            foreach (var routeValue in CopiedRouteValues)//loop thru the copied route
            {
                UrlToReturn += $"/{routeValue}";//add every value to the route
            }
            return UrlToReturn;//and then return it
        }
        public void GetValues(string fullUrl)
        {
            var Template = ((Route)HttpContext.Current.Request.RequestContext.RouteData.Route).Url;//get the template for route
            RouteTemplate = Template.Split(new string[] { "{", "/", "}" }, StringSplitOptions.RemoveEmptyEntries);//clean it up(without "special charaters")
            if (fullUrl == "/") //if the user is on home
            {
                var DefaultValues = ((Route)HttpContext.Current.Request.RequestContext.RouteData.Route).Defaults.Values.ToList();//get the default values for the route
                foreach (var defaultValue in DefaultValues)//loop thru them
                {
                    if (defaultValue.ToString() != "") RouteValues.Add(defaultValue.ToString());//verify if the item isn't empty(id, i'm looking to you) and then add to list
                }
                return;//return the function to stop setting the route parameters
            }
            RouteValues = fullUrl.Split(new[] { '/', ' ' }, StringSplitOptions.RemoveEmptyEntries);//clean the full url to match with the template
        }
        private int GetIndexOf(RouteTypes routeType)
        {
            string Route = routeType.ToString().ToLower();//convert the enum type to string and go with lower case to match with the entries
            for (int i = 0; i < RouteTemplate.Length; i++)//loop thru the list
            {
                if (RouteTemplate[i] == Route) return i; // if the enum matches with the route url return the position of it
            }
            return -1;//otherwise return -1
        }
    }
}