// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.Payment.Dto;
using RentCar.Core.Specifications;

namespace RentCar.Application.Payment.Queries.GetPaymentsQuery;

public sealed record GetPaymentsQuery(SpecificationBase Spec) : GetEntitiesQuery<PaymentDto>(Spec);
