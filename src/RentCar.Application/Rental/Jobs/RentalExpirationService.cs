// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;
using MediatR;
using Microsoft.Extensions.Hosting;
using RentCar.Application.Rental.Commands.UpdateRentalCommand;
using RentCar.Core.Enums;

namespace RentCar.Application.Rental.Jobs;

public sealed class RentalExpirationService(ISender sender, IReadRepositoryBase<Core.Entities.Rental> repository)
    : BackgroundService
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
        var rentals = await repository.ListAsync(stoppingToken);

        if (rentals.Count == 0)
            return;

        foreach (var rental in rentals.Where(rental =>
                     rental.EndDate <= DateTime.UtcNow && rental.Status.Equals(RentStatus.Renting)))
        {
            await sender.Send(new UpdateRentalCommand(
                rental.Id,
                rental.StartDate,
                rental.EndDate,
                rental.TotalPrice,
                RentStatus.Overdue,
                rental.VehicleId,
                rental.UserId,
                rental.PaymentId
            ), stoppingToken);
        }
    }
}
