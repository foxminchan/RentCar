// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Payment.Dto;

namespace RentCar.Application.Payment.Queries.GetPaymentQuery;

public sealed record GetPaymentQuery(Guid Id) : GetEntityQuery<PaymentDto>(Id);
