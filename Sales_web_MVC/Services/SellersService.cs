using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sales_web_MVC.Data;
using Sales_web_MVC.Models;

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
            return _context.Sellers.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }
    }
}
