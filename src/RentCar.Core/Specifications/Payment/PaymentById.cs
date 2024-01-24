// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

namespace RentCar.Core.Specifications.Payment;

public sealed class PaymentById : Specification<Core.Entities.Payment>
{
    public PaymentById(Guid id)
    {
        Query.Where(x => x.Id == id);
    }
}
