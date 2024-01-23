﻿// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using MediatR;
using RentCar.Core.Interfaces;

namespace RentCar.Infrastructure.Abstraction.Commands.UpdateEntityCommand;

public record UpdateEntityCommand : ICommand<Result<Unit>>, ITransactionRequest;
