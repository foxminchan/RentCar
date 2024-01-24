// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Payment.Commands.CreatePaymentCommand;
using RentCar.Application.Payment.Commands.DeletePaymentCommand;
using RentCar.Application.Payment.Commands.UpdatePaymentCommand;
using RentCar.Application.Payment.Dto;
using RentCar.Application.Payment.Queries.GetPaymentQuery;
using RentCar.Application.Payment.Queries.GetPaymentsQuery;
using RentCar.Core.Constants;
using RentCar.Core.Specifications;
using RentCar.UseCase.Extensions;

namespace RentCar.UseCase.Endpoints;

public class PaymentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app
            .MapGroup("/api/payment/")
            .WithTags("Payment");
        group.RequirePerUserRateLimit();
        group.MapGet("", GetPayments).WithName(nameof(GetPayments)).RequireAuthorization(Policies.Admin);
        group.MapGet("{id:guid}", GetPayment).WithName(nameof(GetPayment)).RequireAuthorization(Policies.Customer);
        group.MapPost("", AddPayment).WithName(nameof(AddPayment));
        group.MapPut("", UpdatePayment).WithName(nameof(UpdatePayment));
        group.MapDelete("{id:guid}", DeletePayment).WithName(nameof(DeletePayment));
    }

    private static async Task<Result<PaymentDto>> GetPayment(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new GetPaymentQuery(id));

    private static async Task<Result<PagedResult<IEnumerable<PaymentDto>>>> GetPayments(
        [AsParameters] SpecificationBase spec,
        [FromServices] ISender sender)
        => await sender.Send(new GetPaymentsQuery(spec));

    private static async Task<Result<Guid>> AddPayment(
        [FromBody] CreatePaymentCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result> UpdatePayment(
        [FromBody] UpdatePaymentCommand request,
        [FromServices] ISender sender)
        => await sender.Send(request);

    private static async Task<Result> DeletePayment(
        [FromRoute] Guid id,
        [FromServices] ISender sender)
        => await sender.Send(new DeletePaymentCommand(id));
}
