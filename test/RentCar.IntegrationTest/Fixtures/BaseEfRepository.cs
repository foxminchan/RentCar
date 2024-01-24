// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using RentCar.Infrastructure.Data;
using RentCar.Infrastructure.Data.Interceptors;

namespace RentCar.Integration.Test.Fixtures;

public abstract class BaseEfRepository
{
    protected ApplicationDbContext _dbContext;

    protected BaseEfRepository()
    {
        var options = CreateNewContextOptions();
        _dbContext = new(options);
    }

    private static DbContextOptions<ApplicationDbContext> CreateNewContextOptions()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        builder.UseInMemoryDatabase("rent-car")
            .AddInterceptors(new TimingInterceptor())
            .AddInterceptors(new DispatchDomainEventsInterceptor(Substitute.For<IDomainEventDispatcher>()))
            .UseInternalServiceProvider(serviceProvider);

        return builder.Options;
    }

    protected Repository<Core.Entities.Vehicle> VehicleRepository() => new(_dbContext);
}
