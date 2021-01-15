using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales_web_MVC.Models;

namespace Sales_web_MVC.Data
{
    public class Sales_web_MVCContext : DbContext
    {
        public Sales_web_MVCContext (DbContextOptions<Sales_web_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Sales_web_MVC.Models.Department> Department { get; set; }
        public DbSet<Sellers> Sellers { get; set; }
        public DbSet<SalesRecord>  SalesRecord{ get; set; }
    }
}
