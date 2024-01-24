// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using MediatR;
using Microsoft.EntityFrameworkCore;
using Quartz;
using RentCar.Application.Rental.Commands.UpdateRentalCommand;
using RentCar.Core.Enums;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Rental.Jobs;

[DisallowConcurrentExecution]
public sealed class RentalExpirationService(ISender sender, ApplicationDbContext db)
    : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var rentals = await db.Rentals.ToListAsync();

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
            ));
        }
    }
}
