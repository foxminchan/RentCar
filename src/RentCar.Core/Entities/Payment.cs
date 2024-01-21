// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.SharedKernel;

namespace RentCar.Core.Entities;

public sealed class Payment : EntityBase<Guid>
{
    private string? _cardHolderName;
    public string? CardNumber { get; set; }

    public string? CardHolderName
    {
        get => _cardHolderName;
        set => _cardHolderName = value?.ToUpper();
    }

    public DateTime? ExpirationDate { get; set; }
    public string? SecurityCode { get; set; }
    public ICollection<Rental>? Rentals { get; set; } = new List<Rental>();
}
