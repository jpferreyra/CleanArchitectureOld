namespace CleanArchitecture.Application.Features.Products.Queries.GetProductsList
{
    public class ProductViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
