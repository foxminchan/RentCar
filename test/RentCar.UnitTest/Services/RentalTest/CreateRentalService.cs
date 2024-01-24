// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Infrastructure.Data;

namespace RentCar.Unit.Test.Services.RentalTest;

public sealed class CreateRentalService
{
    private readonly Repository<Rental> _repository = Substitute.For<Repository<Rental>>();

    [Fact]
    public async Task InvokesGetRentalsByUserAsync()
        => await _repository.Received().AddAsync(Arg.Any<Rental>());
}
