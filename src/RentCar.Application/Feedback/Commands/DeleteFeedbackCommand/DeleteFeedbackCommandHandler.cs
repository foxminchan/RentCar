// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification;

using RentCar.Application.Abstraction.Commands.DeleteEntityCommand;

namespace RentCar.Application.Feedback.Commands.DeleteFeedbackCommand;

public sealed class DeleteFeedbackCommandHandler(IRepositoryBase<Core.Entities.Feedback> repository)
        : DeleteEntityCommandHandler<DeleteFeedbackCommand, Core.Entities.Feedback>(repository);
