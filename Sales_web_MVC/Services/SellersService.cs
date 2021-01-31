using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sales_web_MVC.Data;
using Sales_web_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Sales_web_MVC.Services.Exceptions;

namespace Sales_web_MVC.Services
{
    public class SellersService
    {
        private readonly Sales_web_MVCContext _context;

        public SellersService(Sales_web_MVCContext context)
        {
            _context = context;
        }

        public async Task<List<Sellers>> FindAllAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task InsertAsync (Sellers obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Sellers> FindByIdAsync(int id)
        {
            return await _context.Sellers.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Sellers.FindAsync(id);
                _context.Sellers.Remove(obj);
                await _context.SaveChangesAsync();
            }

            catch(DbUpdateException e)
            {
                throw new IntegrityException("Can´t delete seller because he/she has sales! ");
            }
            }

        public async Task UpdateAsync(Sellers obj)
        {
            bool hasAny = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
           
        }
    }
}
