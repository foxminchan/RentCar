using Ardalis.Specification;

using RentCar.Core.Interfaces;

namespace RentCar.Core.SharedKernel;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
