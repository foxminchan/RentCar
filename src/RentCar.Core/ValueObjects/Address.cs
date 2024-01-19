// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.EntityFrameworkCore;
using RentCar.Core.SharedKernel;

namespace RentCar.Core.ValueObjects;

[Owned]
public class Address : ValueObject
{
    public Address()
    {
    }

    public Address(
        string? street,
        string? ward,
        string? city,
        string? province)
    {
        Street = street;
        Ward = ward;
        City = city;
        Province = province;
    }

    public string? Street { get; set; }
    public string? Ward { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }

    public override string ToString()
    {
        var components = new List<string?>
        {
            Street,
            Ward,
            City,
            Province
        };

        var nonEmptyComponents = components
            .Where(c => !string.IsNullOrWhiteSpace(c))
            .ToList();

        return string.Join(", ", nonEmptyComponents);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return ToString();
    }
}
