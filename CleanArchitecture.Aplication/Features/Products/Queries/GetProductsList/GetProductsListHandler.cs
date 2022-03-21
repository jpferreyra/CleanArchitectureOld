using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistance;
using MediatR;

namespace CleanArchitecture.Application.Features.Products.Queries.GetProductsList
{
    public class GetProductsListHandler : IRequestHandler<GetProductsListQuery, List<ProductViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductViewModel>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var productlist = await _unitOfWork.ProductRepository.GetProductByName(request.ProductName);

            return _mapper.Map<List<ProductViewModel>>(productlist);
        }
    }
}
