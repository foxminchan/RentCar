﻿using Ardalis.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.User.Commands.CreateUserCommand;
using RentCar.Application.User.Commands.DeleteUserCommand;
using RentCar.Application.User.Commands.UpdateUserCommand;
using RentCar.Application.User.Dto;
using RentCar.Application.User.Queries.GetUserQuery;
using RentCar.Application.User.Queries.GetUsersQuery;
using RentCar.UseCase.Extensions;

namespace RentCar.UseCase.Endpoints;

public sealed class UserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app
            .MapGroup("/api/user/")
            .WithTags("User");
        group.RequirePerUserRateLimit();
        group.MapGet("", GetUsers).WithName(nameof(GetUsers));
        group.MapGet("{id}", GetUser).WithName(nameof(GetUser));
        group.MapPost("", AddUser).WithName(nameof(AddUser));
        group.MapPut("", UpdateUser).WithName(nameof(UpdateUser));
        group.MapDelete("{id}", DeleteUser).WithName(nameof(DeleteUser));
    }

    private static async Task<Result<IEnumerable<UserDto>>> GetUsers(
        [AsParameters] GetUsersQuery request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result<UserDto>> GetUser(
        [FromRoute] string id,
        [FromServices] ISender sender)
        => await sender.Send(new GetUserQuery(id));

    private static async Task<Result<string>> AddUser(
        [FromBody] CreateUserCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result<Unit>> UpdateUser(
        [FromBody] UpdateUserCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result> DeleteUser(
        [FromRoute] string id,
        [FromServices] ISender sender)
        => await sender.Send(new DeleteUserCommand(id));
}