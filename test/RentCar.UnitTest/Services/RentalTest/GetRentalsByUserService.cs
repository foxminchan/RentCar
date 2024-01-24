// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using NSubstitute;
using RentCar.Core.Entities;
using RentCar.Core.Specifications.Rental;
using RentCar.Infrastructure.Data;

namespace RentCar.Unit.Test.Services.RentalTest;

public sealed class GetRentalsByUserService
{
    private readonly Repository<Rental> _repository = Substitute.For<Repository<Rental>>();

    [Fact]
    public async Task InvokesCreateRentalAsync()
    {
        var spec = new RentalByUserId(Arg.Any<Guid>(), new());
        await _repository.Received().ListAsync(spec, Arg.Any<CancellationToken>());
    }
}
