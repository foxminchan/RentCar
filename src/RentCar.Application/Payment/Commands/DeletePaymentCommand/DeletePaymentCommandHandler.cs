// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.DeleteEntityCommand;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Payment.Commands.DeletePaymentCommand;

public sealed class DeletePaymentCommandHandler(Repository<Core.Entities.Payment> repository)
    : DeleteEntityCommandHandler<DeletePaymentCommand, Core.Entities.Payment>(repository);
