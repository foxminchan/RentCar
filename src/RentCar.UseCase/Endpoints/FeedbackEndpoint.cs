// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Feedback.Commands.CreateFeedbackCommand;
using RentCar.Application.Feedback.Commands.DeleteFeedbackCommand;
using RentCar.Application.Feedback.Commands.UpdateFeedbackCommand;
using RentCar.Application.Feedback.Dto;
using RentCar.Application.Feedback.Queries.GetFeedbackByVehicleQuery;
using RentCar.Application.Feedback.Queries.GetFeedbackQuery;
using RentCar.Application.Feedback.Queries.GetFeedbacksQuery;
using RentCar.UseCase.Extensions;

namespace RentCar.UseCase.Endpoints;

public sealed class FeedbackEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app
            .MapGroup("/api/feedback/")
            .WithTags("Feedback");
        group.RequirePerUserRateLimit();
        group.MapGet("", GetFeedbacks).WithName(nameof(GetFeedbacks));
        group.MapGet("{id:guid}", GetFeedBack).WithName(nameof(GetFeedBack));
        group.MapGet("vehicle", GetFeedbacksByVehicle).WithName(nameof(GetFeedbacksByVehicle));
        group.MapPost("", AddFeedback).WithName(nameof(AddFeedback));
        group.MapPut("", UpdateFeedback).WithName(nameof(UpdateFeedback));
        group.MapDelete("{id:guid}", DeleteFeedback).WithName(nameof(DeleteFeedback));
    }

    private static async Task<Result<Guid>> AddFeedback(
        [FromBody] CreateFeedbackCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result<Unit>> UpdateFeedback(
        [FromBody] UpdateFeedbackCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result> DeleteFeedback(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new DeleteFeedbackCommand(id));

    private static async Task<Result<FeedbackDto>> GetFeedBack(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new GetFeedbackQuery(id));

    private static async Task<Result<PagedResult<IEnumerable<FeedbackDto>>>> GetFeedbacks(
        [AsParameters] GetFeedbacksQuery request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result<PagedResult<IEnumerable<FeedbackDto>>>> GetFeedbacksByVehicle(
        [AsParameters] GetFeedbackByVehicleQuery request,
        [FromServices] ISender sender)
        => await sender.Send(request);
}
