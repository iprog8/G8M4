using CrmManagerMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmManagerMvc.ViewModels
{
    public class RankingViewModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int NumarAccesari { get; set; }
        public string ControllerName { get; set; }
        public string ViewName { get; set; } = "Details";
    }
}