// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
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
        group.MapGet("{id:guid}", GetUser).WithName(nameof(GetUser));
        group.MapPost("", AddUser).WithName(nameof(AddUser));
        group.MapPut("", UpdateUser).WithName(nameof(UpdateUser));
        group.MapDelete("{id:guid}", DeleteUser).WithName(nameof(DeleteUser));
    }

    private static async Task<PagedResult<IEnumerable<UserDto>>> GetUsers(
        [AsParameters] GetUsersQuery request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result<UserDto>> GetUser(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new GetUserQuery(id));

    private static async Task<Result<Guid>> AddUser(
        [FromBody] CreateUserCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result<Unit>> UpdateUser(
        [FromBody] UpdateUserCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result> DeleteUser(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new DeleteUserCommand(id));
}
