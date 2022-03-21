using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistance
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<Product> GetProductByBarcode(string barcode);
        Task<IEnumerable<Product>> GetProductByName(string productName);
    }
}
