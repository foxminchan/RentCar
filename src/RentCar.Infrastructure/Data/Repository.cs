// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification.EntityFrameworkCore;

namespace RentCar.Infrastructure.Data;

public sealed class Repository<T>(ApplicationDbContext dbContext) : RepositoryBase<T>(dbContext)
    where T : class;
