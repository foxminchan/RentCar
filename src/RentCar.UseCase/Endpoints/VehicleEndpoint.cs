// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Vehicle.Commands.CreateVehicleCommand;
using RentCar.Application.Vehicle.Commands.DeleteVehicleCommand;
using RentCar.Application.Vehicle.Commands.UpdateVehicleCommand;
using RentCar.Application.Vehicle.Dto;
using RentCar.Application.Vehicle.Queries.GetVehicleAmountQuery;
using RentCar.Application.Vehicle.Queries.GetVehicleQuery;
using RentCar.Application.Vehicle.Queries.GetVehiclesQuery;
using RentCar.UseCase.Extensions;

namespace RentCar.UseCase.Endpoints;

public sealed class VehicleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app
            .MapGroup("/api/vehicle/")
            .WithTags("Vehicle");
        group.RequirePerUserRateLimit();
        group.MapGet("", GetVehicles).WithName(nameof(GetVehicles));
        group.MapGet("{id:guid}", GetVehicle).WithName(nameof(GetVehicle));
        group.MapPost("", CreateVehicle).WithName(nameof(CreateVehicle));
        group.MapPut("", UpdateVehicle).WithName(nameof(UpdateVehicle));
        group.MapDelete("{id:guid}", DeleteVehicle).WithName(nameof(DeleteVehicle));
    }

    private static async Task<Result<(IEnumerable<VehicleDto>, int)>> GetVehicles(
        [AsParameters] GetVehiclesQuery request,
        [FromServices] ISender sender)
    {
        var result = await sender.Send(request);
        var count = await sender.Send(new GetVehicleAmountQuery());
        return Result.Success((result.Value, count.Value));
    }

    private static async Task<Result<VehicleDto>> GetVehicle(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new GetVehicleQuery(id));

    private static async Task<Result<Guid>> CreateVehicle(
        [FromBody] CreateVehicleCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result<Unit>> UpdateVehicle(
        [FromBody] UpdateVehicleCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result> DeleteVehicle(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new DeleteVehicleCommand(id));
}
