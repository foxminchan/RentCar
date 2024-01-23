// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Infrastructure.Abstraction.Commands.DeleteEntityCommand;

namespace RentCar.Application.Feedback.Commands.DeleteFeedbackCommand;

public sealed record DeleteFeedbackCommand(Guid Id) : DeleteEntityCommand(Id);
