// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Ardalis.SharedKernel;

using RentCar.Core.Interfaces;

namespace RentCar.Application.Vehicle.Commands.DeleteVehicleCommand;

public sealed record DeleteVehicleCommand(Guid Id) : ICommand<Result>, ITransactionRequest;
