using Ardalis.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Maintenance.Commands.CreateMaintenanceCommand;
using RentCar.Application.Maintenance.Commands.DeleteMaintenanceCommand;
using RentCar.Application.Maintenance.Commands.UpdateMaintenanceCommand;
using RentCar.Application.Maintenance.Dto;
using RentCar.Application.Maintenance.Queries.GetMaintenanceByVehicleQuery;
using RentCar.Application.Maintenance.Queries.GetMaintenanceQuery;
using RentCar.Application.Maintenance.Queries.GetMaintenancesQuery;
using RentCar.Core.Specifications;
using RentCar.UseCase.Extensions;

namespace RentCar.UseCase.Endpoints;

public sealed class MaintenanceEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app
            .MapGroup("/api/maintenance/")
            .WithTags("Maintenance");
        group.RequirePerUserRateLimit();
        group.MapGet("", GetMaintenances).WithName(nameof(GetMaintenances));
        group.MapGet("{id:guid}", GetMaintenance).WithName(nameof(GetMaintenance));
        group.MapGet("vehicle/{id:guid}", GetMaintenancesByVehicle).WithName(nameof(GetMaintenancesByVehicle));
        group.MapPost("", AddMaintenance).WithName(nameof(AddMaintenance));
        group.MapPut("", UpdateMaintenance).WithName(nameof(UpdateMaintenance));
        group.MapDelete("{id:guid}", DeleteMaintenance).WithName(nameof(DeleteMaintenance));
    }

    private static async Task<Result<PagedResult<IEnumerable<MaintenanceDto>>>> GetMaintenances(
        [AsParameters] SpecificationBase spec,
        [FromServices] ISender sender)
        => await sender.Send(new GetMaintenancesQuery(spec));

    private static async Task<Result<MaintenanceDto>> GetMaintenance(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new GetMaintenanceQuery(id));

    private static async Task<Result<PagedResult<IEnumerable<MaintenanceDto>>>> GetMaintenancesByVehicle(
        [FromRoute] Guid id,
        [AsParameters] SpecificationBase spec,
        [FromServices] ISender sender)
        => await sender.Send(new GetMaintenanceByVehicleQuery(id, spec));

    private static async Task<Result<Guid>> AddMaintenance(
        [FromBody] CreateMaintenanceCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result> UpdateMaintenance(
        [FromBody] UpdateMaintenanceCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result> DeleteMaintenance(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new DeleteMaintenanceCommand(id));
}
