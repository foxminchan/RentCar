using Ardalis.Result;

using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Commands.DeleteVehicleCommand;

public record DeleteVehicleCommand(Ulid Id) : ICommand<Result>;
