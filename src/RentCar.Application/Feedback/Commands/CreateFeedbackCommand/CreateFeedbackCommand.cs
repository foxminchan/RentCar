// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.CreateEntityCommand;

namespace RentCar.Application.Feedback.Commands.CreateFeedbackCommand;

public sealed record CreateFeedbackCommand(
    string? Message,
    byte? Rating,
    bool? IsApproved,
    Guid? RentalId) : CreateEntityCommand;
