// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

namespace RentCar.Core.SharedKernel;

public abstract class ValueObject
{
    protected static bool EqualOperator(ValueObject? left, ValueObject? right)
        => !(left is null ^ right is null) && left?.Equals(right!) != false;

    protected static bool NotEqualOperator(ValueObject? left, ValueObject? right)
        => !EqualOperator(left, right);

    protected abstract IEnumerable<object?> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
        => GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
}
