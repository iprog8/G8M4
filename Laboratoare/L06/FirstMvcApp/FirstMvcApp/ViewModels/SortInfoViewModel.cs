using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FirstMvcApp.ViewModels
{
    public class SortInfoViewModel
    {
        public string ColumnName { get; set; }
        public SortOrder SortOrder { get; set; }
    }
}