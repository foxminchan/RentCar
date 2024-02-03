// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using FluentAssertions;
using NetArchTest.Rules;

namespace RentCar.Integration.Test.Arch;

public sealed class Architecture
{
    private const string CoreNamespace = "Core";
    private const string InfrastructureNamespace = "Infrastructure";
    private const string ApplicationNamespace = "Application";
    private const string UseCaseNamespace = "UseCase";

    [Fact]
    public void InvokesCoreLayerDependencies()
    {
        var assembly = typeof(Core.AssemblyReference).Assembly;

        string[] layers = [
            CoreNamespace,
            InfrastructureNamespace,
            ApplicationNamespace,
            UseCaseNamespace
        ];

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(layers)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(result.ToString());
    }

    [Fact]
    public void InvokesApplicationLayerDependencies()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        string[] layers = [
            CoreNamespace,
            ApplicationNamespace,
            UseCaseNamespace
        ];

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(layers)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(result.ToString());
    }

    [Fact]
    public void InvokesInfrastructureLayerDependencies()
    {
        var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

        string[] layers = [
            CoreNamespace,
            ApplicationNamespace,
            UseCaseNamespace
        ];

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(layers)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(result.ToString());
    }

    [Fact]
    public void InvokesUseCaseLayerDependencies()
    {
        var assembly = typeof(UseCase.AssemblyReference).Assembly;

        string[] layers = [
            CoreNamespace,
            ApplicationNamespace,
            UseCaseNamespace
        ];

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(layers)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(result.ToString());
    }

    [Fact]
    public void InvokesCoreLayerOnlyDependsOnItself()
    {
        var assembly = typeof(Core.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .Should()
            .OnlyHaveDependenciesOn(CoreNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(result.ToString());
    }

    [Fact]
    public void InvokesInfrastructureLayerOnlyDependsOnCoreLayer()
    {
        var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .Should()
            .OnlyHaveDependenciesOn(CoreNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(result.ToString());
    }

    [Fact]
    public void InvokesApplicationLayerOnlyDependsOnInfrastructureLayer()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .Should()
            .OnlyHaveDependenciesOn(InfrastructureNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(result.ToString());
    }

    [Fact]
    public void InvokesUseCaseLayerOnlyDependsOnApplicationLayer()
    {
        var assembly = typeof(UseCase.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .Should()
            .OnlyHaveDependenciesOn(ApplicationNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue(result.ToString());
    }

    [Fact]
    public void InvokesEndpointHaveDependencyOnMediaR()
    {
        var assembly = typeof(UseCase.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Endpoint")
            .Should()
            .HaveDependencyOn("MediatR")
            .GetResult();

        result.IsSuccessful.Should().BeTrue(result.ToString());
    }
}
