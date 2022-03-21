using CleanArchitecture.Application.Features.Products.Queries.GetProductsList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Products.Queries.GetProductByBarcode
{
    public class GetProductByBarcodeQuery : IRequest<ProductViewModel>
    {
        public string Barcode { get; set; } = String.Empty;

    public GetProductByBarcodeQuery(string? barcode)
    {
        this.Barcode = barcode ?? throw new ArgumentNullException(nameof(barcode));
    }
}
}
