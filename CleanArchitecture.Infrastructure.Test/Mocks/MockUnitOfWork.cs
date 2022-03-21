using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace CleanArchitecture.XUnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: $"AppDbContext-{Guid.NewGuid()}")
                    .Options;

            var dbContextFake = new AppDbContext(options);

            dbContextFake.Database.EnsureDeleted();

            var mockUnitOfWork = new Mock<UnitOfWork>(dbContextFake);
            return mockUnitOfWork;
        }
    }
}