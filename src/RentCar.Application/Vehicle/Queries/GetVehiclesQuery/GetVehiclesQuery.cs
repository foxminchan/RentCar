using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Application.Vehicle.Dto;

namespace RentCar.Application.Vehicle.Queries.GetVehiclesQuery;

public record GetVehiclesQuery(int Skip, int Take) : IQuery<Result<IEnumerable<VehicleDto>>>;
