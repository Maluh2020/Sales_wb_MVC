using Microsoft.EntityFrameworkCore;
using Sales_web_MVC.Data;
using Sales_web_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_web_MVC.Services
{
    public class SalesRecordService
    {
        private readonly Sales_web_MVCContext _context;

        public SalesRecordService(Sales_web_MVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date >= maxDate.Value);
            }

            return await result
                .Include(x => x.Sellers)
                .Include(x => x.Sellers.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

    }
}
