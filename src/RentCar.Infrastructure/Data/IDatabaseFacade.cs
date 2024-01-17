// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RentCar.Infrastructure.Data;

public interface IDatabaseFacade
{
    public DatabaseFacade Database { get; }
}
