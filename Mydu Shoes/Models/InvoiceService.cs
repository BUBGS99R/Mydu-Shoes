using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mydu_Shoes.Models
{
    public class InvoiceService
    {
        private readonly GiayContext _context;

        public InvoiceService(GiayContext context)
        {
            _context = context;
        }

        public async Task SaveInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Invoice>> GetInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(Guid id)
        {
            return await _context.Invoices.FindAsync(id);
        }
        

    }
}
