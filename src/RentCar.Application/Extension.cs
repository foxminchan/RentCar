using System.Reflection.Metadata;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Infrastructure.CQRS;

namespace RentCar.Application;

public static class Extension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediator(s =>
            s.AddMediatR(options =>
                options.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly)
            ));
    }
}
