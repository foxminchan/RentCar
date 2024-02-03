// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Core.Enums;
using RentCar.Infrastructure.Data;
using RentCar.Unit.Test.Fakers;

namespace RentCar.Unit.Test.Services.RentalTest;

public sealed class UpdateRentalService
{
    private readonly Repository<Rental> _repository = Substitute.For<Repository<Rental>>();
    private readonly RentalFaker _faker = new();

    [Fact]
    public async Task InvokesUpdateRentalAsync()
    {
        var rental = _faker.Generate();
        await _repository.AddAsync(rental);
        var existRental = (await _repository.ListAsync()).FirstOrDefault();
        Assert.NotNull(existRental);
        existRental.Status = RentStatus.Returned;
        await _repository.Received().UpdateAsync(existRental, Arg.Any<CancellationToken>());
    }
}
