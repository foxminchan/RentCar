// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using MediatR;
using RentCar.Core.Interfaces;

namespace RentCar.Core.SharedKernel;

public interface ICommand<out TResponse> : IRequest<TResponse>, ITransactionRequest;
