using Ardalis.Result;
using Ardalis.Specification;
using Mapster;
using RentCar.Core.Events.Vehicle;
using RentCar.Core.SharedKernel;

namespace RentCar.Application.Vehicle.Commands.CreateVehicleCommand;

public sealed class CreateVehicleCommandHandler(IRepositoryBase<Core.Entities.Vehicle> repository)
    : ICommandHandler<CreateVehicleCommand, Result<Core.Entities.Vehicle>>
{
    public async Task<Result<Core.Entities.Vehicle>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Core.Entities.Vehicle>();
        entity.AddDomainEvent(new VehicleCreatedEvent(entity));
        return await repository.AddAsync(entity, cancellationToken);
    }
}
