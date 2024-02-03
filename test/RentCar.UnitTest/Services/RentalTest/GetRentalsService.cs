// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Core.Specifications.Rental;
using RentCar.Infrastructure.Data;
using RentCar.Unit.Test.Fakers;

namespace RentCar.Unit.Test.Services.RentalTest;

public sealed class GetRentalsService
{
    private readonly Repository<Rental> _repository = Substitute.For<Repository<Rental>>();
    private readonly RentalFaker _faker = new();

    [Fact]
    public async Task InvokesGetRentalsAsync()
    {
        var rental = _faker.Generate(20);
        await _repository.AddRangeAsync(rental);
        await _repository.Received().ListAsync(Arg.Any<RentalFilterPaginated>(),Arg.Any<CancellationToken>());
    }
}
