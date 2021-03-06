﻿using CrmManagerMvc.Models;
using CrmManagerMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrmManagerMvc.Controllers
{
    public class RankingController : Controller
    {
        // GET: Ranking
        public ActionResult _RankingPartial(string controllerName)
        {
            RankingModelViewModel model = new RankingModelViewModel();
            if(Enum.TryParse(controllerName, out RankingPages ranking))
            {
                CRMEntities db = new CRMEntities();
                model.Translations.GetTranslations(db, this.RouteData);
                var pages = db.Pages.Where(p => p.NumePagina.Contains(controllerName + "Details")).ToList();
                foreach (var page in pages)
                {
                    RankingViewModel rankingViewModel = new RankingViewModel();
                    rankingViewModel.Id = int.Parse(new String(page.NumePagina.Where(char.IsDigit).ToArray()));
                    rankingViewModel.Nume = GetName(db, ranking, rankingViewModel.Id);
                    rankingViewModel.NumarAccesari = page.NumarAccesari;
                    rankingViewModel.ControllerName = controllerName;
                    model.RankingViewModels.Add(rankingViewModel);
                }
                model.RankingViewModels = model.RankingViewModels.OrderByDescending(r => r.NumarAccesari).ToList();
            }
            return PartialView(model);
        }
        private static string GetName(CRMEntities db, RankingPages rankingPages, int id)
        {
            switch (rankingPages)
            {
                case RankingPages.Customer:
                    return db.Customers.Find(id).FirstName;
                case RankingPages.Supplier:
                    return db.Suppliers.Find(id).CompanyName;
                default:
                    break;
            }
            return string.Empty;
        }
    }
}