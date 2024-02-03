// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Bogus;
using RentCar.Core.Enums;

namespace RentCar.Unit.Test.Fakers;

public sealed class VehicleFaker : Faker<Core.Entities.Vehicle>
{
    public VehicleFaker()
    {
        RuleFor(x => x.Name, f => f.Vehicle.Model());
        RuleFor(x => x.Brand, f => f.Vehicle.Manufacturer());
        RuleFor(x => x.Color, f => f.Lorem.Word());
        RuleFor(x => x.Status, f => f.PickRandom<CarStatus>());
        RuleFor(x => x.Type, f => f.PickRandom<VehicleType>());
        RuleFor(x => x.Image, f => f.Image.PicsumUrl(700, 700));
        RuleFor(x => x.Plate, f => f.Random.Replace("##?-###.##"));
    }
}
