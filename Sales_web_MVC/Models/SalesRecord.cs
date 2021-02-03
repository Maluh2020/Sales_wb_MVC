using Sales_web_MVC.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sales_web_MVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MissingMemberException/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0: F2}")]

        public double Amount { get; set; }
        public SalesStatus Status { get; set; }
        public Sellers Sellers { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SalesStatus status, Sellers sellers)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Sellers = sellers;
        }
    }
}
