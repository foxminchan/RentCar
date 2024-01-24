using System.Reflection;

namespace RentCar.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    public static readonly Assembly[] AppDomainAssembly = AppDomain.CurrentDomain.GetAssemblies();
}
