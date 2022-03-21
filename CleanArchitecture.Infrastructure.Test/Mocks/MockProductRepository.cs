using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Test.Mocks
{
    public static class MockProductRepository
    {
        public static void AddDataRepository(AppDbContext dbcontext)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior()); //para problemas de referencia circular

            var products = fixture.CreateMany<Product>().ToList();

            products.Add(fixture.Build<Product>()
                .With(p => p.Name, "CPU")
                .Create()
                );

            dbcontext.Products!.AddRange(products);
            dbcontext.SaveChanges();
        }
    }
}
