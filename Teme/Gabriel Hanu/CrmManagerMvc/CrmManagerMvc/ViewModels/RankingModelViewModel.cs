using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmManagerMvc.ViewModels
{
    public class RankingModelViewModel
    {
        public ICollection<RankingViewModel> RankingViewModels { get; set; } = new List<RankingViewModel>();
        public TranslationViewModel Translations { get; set; } = new TranslationViewModel();
    }
}