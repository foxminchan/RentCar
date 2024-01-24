// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.DeleteEntityCommand;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Feedback.Commands.DeleteFeedbackCommand;

public sealed class DeleteFeedbackCommandHandler(Repository<Core.Entities.Feedback> repository)
        : DeleteEntityCommandHandler<DeleteFeedbackCommand, Core.Entities.Feedback>(repository);
