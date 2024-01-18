using System.Text.Json.Serialization;

using RentCar.Core.Identity;
using RentCar.Core.SharedKernel;

namespace RentCar.Core.Entities;

public sealed class Rental : BaseEntity
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? TotalPrice { get; set; }
    public Ulid? VehicleId { get; set; }
    [JsonIgnore] public Vehicle? Vehicle { get; set; }
    public string? UserId { get; set; }
    [JsonIgnore] public ApplicationUser? User { get; set; }
}
