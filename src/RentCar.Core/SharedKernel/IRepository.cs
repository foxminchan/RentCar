using Ardalis.Specification;
using RentCar.Core.Interfaces;

namespace RentCar.Core.SharedKernel;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
