// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentCar.Core.Interfaces;

namespace RentCar.Infrastructure.Data;

public class Repository<T>(DbContext dbContext) : RepositoryBase<T>(dbContext)
    where T : class, IAggregateRoot;
