// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RentCar.Infrastructure.HealthCheck;

public sealed class HealthCheck(HealthService healthService) : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
        => healthService.IsHealthy
            ? Task.FromResult(HealthCheckResult.Healthy("System is in a healthy state."))
            : Task.FromResult(HealthCheckResult.Unhealthy("System is in an unhealthy state."));
}
