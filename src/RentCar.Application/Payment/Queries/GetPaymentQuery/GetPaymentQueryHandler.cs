// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntityQuery;
using RentCar.Application.Payment.Dto;
using RentCar.Core.Specifications.Payment;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Payment.Queries.GetPaymentQuery;

public sealed class GetPaymentQueryHandler(Repository<Core.Entities.Payment> repository) 
    : GetEntityQueryHandler<GetPaymentQuery, Core.Entities.Payment, PaymentDto, PaymentById>(repository);
