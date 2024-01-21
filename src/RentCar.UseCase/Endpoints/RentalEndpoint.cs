﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Rental.Commands.CreateRentalCommand;
using RentCar.Application.Rental.Commands.DeleteRentalCommand;
using RentCar.Application.Rental.Commands.UpdateRentalCommand;
using RentCar.Application.Rental.Dto;
using RentCar.Application.Rental.Queries.GetRentalAmountQuery;
using RentCar.Application.Rental.Queries.GetRentalQuery;
using RentCar.Application.Rental.Queries.GetRentalsByUserQuery;
using RentCar.Application.Rental.Queries.GetRentalsQuery;
using RentCar.UseCase.Extensions;

namespace RentCar.UseCase.Endpoints;

public sealed class RentalEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app
            .MapGroup("/api/rental/")
            .WithTags("Rental");

        group.RequirePerUserRateLimit();
        group.MapGet("", GetRentals).WithName(nameof(GetRentals));
        group.MapGet("{id:guid}", GetRental).WithName(nameof(GetRental));
        group.MapGet("user", GetRentalsByUser).WithName(nameof(GetRentalsByUser));
        group.MapPost("", AddRental).WithName(nameof(AddRental));
        group.MapPut("", UpdateRental).WithName(nameof(UpdateRental));
        group.MapDelete("{id:guid}", DeleteRental).WithName(nameof(DeleteRental));
    }

    private static async Task<Result<(IEnumerable<RentalDto>, int)>> GetRentals(
        [AsParameters] GetRentalsQuery request,
        [FromServices] ISender sender)
    {
        var result = await sender.Send(request);
        var count = await sender.Send(new GetRentalAmountQuery());
        return Result.Success((result.Value, count.Value));
    }

    private static async Task<Result<RentalDto>> GetRental(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new GetRentalQuery(id));

    private static async Task<Result<(IEnumerable<RentalDto>, int)>> GetRentalsByUser(
        [AsParameters] GetRentalsByUserQuery request,
        [FromServices] ISender sender)
    {
        var result = await sender.Send(request);
        var count = await sender.Send(new GetRentalAmountQuery(request.UserId));
        return Result.Success((result.Value, count.Value));
    }

    private static async Task<Result<Guid>> AddRental(
        [FromBody] CreateRentalCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result<Unit>> UpdateRental(
        [FromBody] UpdateRentalCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result> DeleteRental(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new DeleteRentalCommand(id));
}