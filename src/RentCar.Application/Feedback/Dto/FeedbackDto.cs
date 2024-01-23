// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

namespace RentCar.Application.Feedback.Dto;

public sealed record FeedbackDto
{
    public string? Message { get; set; }
    public byte? Rating { get; set; }
    public bool? IsApproved { get; set; }
    public Guid? RentalId { get; set; }
}
