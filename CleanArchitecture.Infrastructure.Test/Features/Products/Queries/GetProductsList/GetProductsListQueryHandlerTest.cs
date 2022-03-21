using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistance;
using CleanArchitecture.Application.Features.Products.Queries.GetProductsList;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Test.Mocks;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Infrastructure.Test.Features.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandlerTest
    {
        private readonly IMapper _mapper;

        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetProductsListQueryHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            MockProductRepository.AddDataRepository(_unitOfWork.Object.AppDbContext);    
        }

        [Fact]
        public async Task GetProductListTest()
        {
            var handler = new GetProductsListHandler(_unitOfWork.Object, _mapper);
            var request = new GetProductsListQuery("CPU");
            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<ProductViewModel>>();

            result.Count.ShouldBe(1);
        }
    }
}
