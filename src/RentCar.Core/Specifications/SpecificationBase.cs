namespace RentCar.Core.Specifications;

public record SpecificationBase
{
    public long PageNumber { get; init; } = 1;
    public long PageSize { get; init; } = 20;
    public string OrderBy { get; init; } = "Id";
    public bool IsAscending { get; init; } = true;
}
