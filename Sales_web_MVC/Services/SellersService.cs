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

        public List<Sellers> FindAll()
        {
            return _context.Sellers.ToList();
        }

        public void Insert (Sellers obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Sellers FindById(int id)
        {
            return _context.Sellers.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Sellers obj)
        {
            if(!_context.Sellers.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
           
        }
    }
}
