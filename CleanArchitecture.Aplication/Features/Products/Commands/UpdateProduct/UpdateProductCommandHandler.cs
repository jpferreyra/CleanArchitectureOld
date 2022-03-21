using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistance;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);

            if (entityToUpdate == null)
            {
                _logger.LogError($"No se encontro {nameof(Product)} Id {request.Id}");
                throw new NotFoundException(nameof(Product), request.Id);
            }

            //request --> entityToUpdate
            _mapper.Map(request, entityToUpdate, typeof(UpdateProductCommand), typeof(Product));

            _unitOfWork.ProductRepository.UpdateEntity(entityToUpdate);
            await _unitOfWork.Commit();

            _logger.LogError($"Product Id {request.Id} actualizado");

            return Unit.Value;
        }
    }
}
