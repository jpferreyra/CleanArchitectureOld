using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistance;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.Products.Queries.GetProductsList;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Products.Queries.GetProductByBarcode
{
    public class GetProductByBarcodeHandler : IRequestHandler<GetProductByBarcodeQuery, ProductViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductByBarcodeHandler> _logger;

        public GetProductByBarcodeHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetProductByBarcodeHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductViewModel> Handle(GetProductByBarcodeQuery request, CancellationToken cancellationToken)
        {

            var product = await _unitOfWork.ProductRepository.GetProductByBarcode(request.Barcode);

            if (product == null)
            {
                _logger.LogError($"No existe un Producto con barcode: {request.Barcode}");
                throw new NotFoundException(nameof(ProductViewModel), request.Barcode);
            }


            var entity = new ProductViewModel()
            {
                Barcode = product.Barcode,
                CategoryId = product.CategoryId,
                Name = product.Name
            };
            return _mapper.Map<ProductViewModel>(product);
        }
    }
}
