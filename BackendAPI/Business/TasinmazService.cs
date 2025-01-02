namespace BackendAPI.Business
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using DataAccess;
    using Entities;

    public class TasinmazService
    {
        private readonly AppDbContext _context;

        public TasinmazService(AppDbContext context)
        {
            _context = context;
        }

        // Tüm taşınmazları getir
        public List<Tasinmaz> GetAllTasinmaz()
        {
            return _context.Tasinmazlar.Include(t => t.Mahalle).ToList();
        }

        // Yeni taşınmaz ekle
        public void AddTasinmaz(Tasinmaz tasinmaz)
        {
            _context.Tasinmazlar.Add(tasinmaz);
            _context.SaveChanges();
        }
    }

}
