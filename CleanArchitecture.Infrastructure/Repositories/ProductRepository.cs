using CleanArchitecture.Application.Contracts.Persistance;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        //private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            //_context = context;
        }

        public async Task<Product> GetProductByBarcode(string barcode)
        {
            return await _context.Products!.Where(y => y.Barcode == barcode).FirstOrDefaultAsync();                        
        }

        public async Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            return await _context.Products!.Where(y => y.Name == productName).ToListAsync();
        }
    }
}
