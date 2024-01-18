// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

namespace RentCar.Infrastructure.HealthCheck;

public sealed class HealthService
{
    public bool IsHealthy { get; private set; } = true;
}
