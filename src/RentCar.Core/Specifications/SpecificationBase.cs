using Microsoft.AspNetCore.Http;

namespace RentCar.Core.Specifications;

public record SpecificationBase(
    long PageNumber = 1,
    long PageSize = 20,
    string? OrderBy = "Id",
    bool IsAscending = true)
{
    public static ValueTask<SpecificationBase?> BindAsync(HttpContext context)
        => ValueTask.FromResult<SpecificationBase?>(new(
            PageNumber: long.TryParse(context.Request.Query["PageNumber"], out var pageNumber) ? pageNumber : 1,
            PageSize: long.TryParse(context.Request.Query["PageSize"], out var pageSize) ? pageSize : 20,
            OrderBy: string.IsNullOrWhiteSpace(context.Request.Query["OrderBy"])
                ? "Id"
                : context.Request.Query["OrderBy"],
            IsAscending: !bool.TryParse(context.Request.Query["IsAscending"], out var isAscending) || isAscending
        ));
}
