// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using RentCar.Application.Abstraction.Commands.UpdateEntityCommand;

namespace RentCar.Application.Feedback.Commands.UpdateFeedbackCommand;

public sealed record UpdateFeedbackCommand(
    Guid Id,
    string? Message,
    byte? Rating,
    bool? IsApproved,
    Guid? RentalId) : UpdateEntityCommand;
