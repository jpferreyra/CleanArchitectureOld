using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistance;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);

            if (productToDelete == null)
            {
                _logger.LogError($"Producto no encontrado, id: {request.Id}");
                throw new NotFoundException(nameof(Product), request.Id);
            }

            _unitOfWork.ProductRepository.DeleteEntity(productToDelete);
            await _unitOfWork.Commit();

            _logger.LogError($"Product id {request.Id} eliminado");

            return Unit.Value;
        }
    }
}
