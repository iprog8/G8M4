﻿using FirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModels
{
    public class CustomerIndexViewModel : IndexViewModel
    {
        public CustomerIndexViewModel()
        {
            PageInfo = new PageInfoViewModel();
            SortInfo = new SortInfoViewModel();
            FilterInfo = new FilterInfoViewModel();
            Translations = new TranslationInfo();
        }
        public ICollection<CustomerViewModel> CustomerList { get; set; }
        public PageInfoViewModel PageInfo { get; set; } = new PageInfoViewModel();
        public SortInfoViewModel SortInfo { get; set; } = new SortInfoViewModel();
        public FilterInfoViewModel FilterInfo { get; set; }
        public TranslationInfo Translations { get; set; }
    }
}