using Ardalis.Result;
using RentCar.Application.Vehicle.Dto;
using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Queries.GetVehiclesQuery;

public record GetVehiclesQuery(int Skip, int Take) : IQuery<Result<IEnumerable<VehicleDto>>>;
