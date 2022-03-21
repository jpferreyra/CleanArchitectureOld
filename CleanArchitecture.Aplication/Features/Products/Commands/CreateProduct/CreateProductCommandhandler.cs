using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistance;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandhandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandhandler> _logger;

        public CreateProductCommandhandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateProductCommandhandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(request);

            _unitOfWork.ProductRepository.AddEntity(entity);
            //_unitOfWork.Repository<Product>().AddEntity(entity); usando el Repository Generic

            var result = await _unitOfWork.Commit();

            if (result <= 0)
                throw new Exception("No se pudo insertar");

            _logger.LogInformation($"Streamer {entity.Id} fue creado exitosamente");

            return entity.Id;
        }
    }
}
