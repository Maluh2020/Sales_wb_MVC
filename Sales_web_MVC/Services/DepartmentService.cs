using Microsoft.EntityFrameworkCore;
using Sales_web_MVC.Data;
using Sales_web_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_web_MVC.Services
{
    public class DepartmentService
    {
        private readonly Sales_web_MVCContext _context;

        public DepartmentService(Sales_web_MVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

    }
}
