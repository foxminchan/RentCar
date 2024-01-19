// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using MediatR;

namespace RentCar.Core.SharedKernel;

public interface IQuery<out TResponse> : IRequest<TResponse>;
