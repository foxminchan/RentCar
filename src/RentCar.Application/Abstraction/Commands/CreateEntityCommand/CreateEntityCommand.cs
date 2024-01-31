// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;
using RentCar.Core.Interfaces;

namespace RentCar.Application.Abstraction.Commands.CreateEntityCommand;

public record CreateEntityCommand : ICommand<Result<Guid>>,ITransactionRequest;
