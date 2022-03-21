using MediatR;

namespace CleanArchitecture.Application.Features.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<List<ProductViewModel>>
    {
        public string ProductName { get; set; } = String.Empty;

        public GetProductsListQuery(string? productName)
        {
            this.ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
        }
    }
}
