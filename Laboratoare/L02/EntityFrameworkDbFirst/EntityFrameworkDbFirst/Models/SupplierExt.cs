using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDbFirst.Models
{
    public partial class Supplier
    {
        public string Address
        {
            get
            {
                return City + " " + Country;
            }
        }
    }
}
