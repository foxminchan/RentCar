// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Infrastructure.Data;
using RentCar.Unit.Test.Fakers;

namespace RentCar.Unit.Test.Services.RentalTest;

public sealed class DeleteRentalService
{
    private readonly Repository<Rental> _repository = Substitute.For<Repository<Rental>>();
    private readonly RentalFaker _faker = new();

    [Fact]
    public async Task InvokesDeleteRentalAsync()
    {
        var rental = _faker.Generate();
        await _repository.AddAsync(rental);
        await _repository.Received().DeleteAsync(rental, Arg.Any<CancellationToken>());
    }
}
