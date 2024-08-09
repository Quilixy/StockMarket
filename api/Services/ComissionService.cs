using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class CommissionService : ICommissionService
    {
        private readonly ApplicationDBContext _context;

        public CommissionService(ApplicationDBContext context)
        {
            _context = context;
        }

        public decimal GetCommissionRate()
        {
            // Veritabanından komisyon oranını al
            var commissionRate = _context.CommissionRates.OrderByDescending(c => c.Id).FirstOrDefault();
            return commissionRate?.Rate ?? 0.05m; // Veritabanında kayıt yoksa varsayılan %5 oranı döndür
        }

        public void UpdateCommissionRate(decimal newRate)
        {
            if (newRate >= 0 && newRate <= 1)
            {
                // Veritabanına yeni komisyon oranını ekle
                var commissionRate = new CommissionRate { Rate = newRate };
                _context.CommissionRates.Add(commissionRate);
                _context.SaveChanges();
            }
        }
    }
}