using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RentCar.Infrastructure.Data;

public interface IDatabaseFacade
{
    public DatabaseFacade Database { get; }
}
