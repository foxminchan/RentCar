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
using RentCar.Application.Vehicle.Queries.GetVehicleQuery;
using RentCar.Application.Vehicle.Queries.GetVehiclesQuery;
using RentCar.Core.Specifications;
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

    private static async Task<PagedResult<IEnumerable<VehicleDto>>> GetVehicles(
        [AsParameters] SpecificationBase spec,
        [FromServices] ISender sender)
        => await sender.Send(new GetVehiclesQuery(spec));

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
