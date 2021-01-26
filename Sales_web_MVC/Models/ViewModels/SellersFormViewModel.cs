using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_web_MVC.Models.ViewModels
{
    public class SellersFormViewModel
    {
        public Sellers Sellers { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
