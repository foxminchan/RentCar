// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

namespace RentCar.Application.Payment.Dto;

public sealed record PaymentDto
{
    public Guid Id { get; set; }
    public string? CardNumber { get; set; }
    public string? CardHolderName { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string? SecurityCode { get; set; }
}
