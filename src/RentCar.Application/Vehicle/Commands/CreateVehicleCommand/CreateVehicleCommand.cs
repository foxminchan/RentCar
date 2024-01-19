using Ardalis.Result;
using RentCar.Application.Vehicle.Dto;
using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Commands.CreateVehicleCommand;

public record CreateVehicleCommand(VehicleDto Vehicle) : ICommand<Result<Core.Entities.Vehicle>>;
