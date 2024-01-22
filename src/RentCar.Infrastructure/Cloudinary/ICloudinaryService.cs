// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using Microsoft.AspNetCore.Http;

namespace RentCar.Infrastructure.Cloudinary;

public interface ICloudinaryService
{
    Task<Result<CloudinaryResult>> AddPhotoAsync(IFormFile? file);
    Task<Result<string>> DeletePhotoAsync(string publicId);
}
