// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Queries.GetEntitiesQuery;
using RentCar.Application.Abstraction.Validators;
using RentCar.Application.Payment.Dto;
using RentCar.Core.Specifications.Payment;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Payment.Queries.GetPaymentsQuery;

public sealed class GetPaymentsQueryHandler(Repository<Core.Entities.Payment> repository) 
    : GetEntitiesQueryHandler<GetPaymentsQuery, Core.Entities.Payment, PaymentDto, PaymentFilterPaginated>(repository);

public sealed class GetPaymentsQueryValidator : PagedValidator<GetPaymentsQuery>;
