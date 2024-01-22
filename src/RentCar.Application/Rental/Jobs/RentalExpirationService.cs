// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using MediatR;
using Microsoft.Extensions.Hosting;
using RentCar.Application.Rental.Commands.UpdateRentalCommand;
using RentCar.Application.Rental.Queries.GetRentalsQuery;
using RentCar.Core.Enums;

namespace RentCar.Application.Rental.Jobs;

public sealed class RentalExpirationService(ISender sender) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await UpdateRentalStatusAsync(stoppingToken);
            await Task.Delay(TimeSpan.FromHours(12), stoppingToken);
        }
    }

    private async Task UpdateRentalStatusAsync(CancellationToken stoppingToken)
    {
        var rentals = await sender.Send(new GetRentalsQuery(), stoppingToken);

        if (!rentals.Value.Any())
            return;

        foreach (var rental in rentals.Value)
        {
            if (rental.EndDate <= DateTime.UtcNow && rental.Status == RentStatus.Renting)
            {
                await sender.Send(new UpdateRentalCommand(
                    rental.Id,
                    rental.StartDate,
                    rental.EndDate,
                    rental.TotalPrice,
                    RentStatus.Cancelled,
                    rental.VehicleId,
                    rental.UserId,
                    rental.PaymentId
                ), stoppingToken);
            }
        }
    }
}
