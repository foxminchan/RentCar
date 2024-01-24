// Copyright (c) 2024-present Nguyen Xuan Nhan. All rights reserved
// Licensed under the MIT License

using Ardalis.Result;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Polly;
using Polly.Retry;

namespace RentCar.Infrastructure.Cloudinary;

public sealed class CloudinaryService(ICloudinaryUploadApi cloudinary) : ICloudinaryService
{
    private readonly AsyncRetryPolicy _retryPolicy = Policy.Handle<Exception>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

    public async Task<Result<CloudinaryResult>> AddPhotoAsync(IFormFile? file)
    {
        if (file is not { Length: > 0 })
            return Result<CloudinaryResult>.Error("File is empty");

        await using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams
        {
            File = new(file.FileName, stream),
            Transformation = new Transformation().Height(700).Width(700).Crop("fill").Gravity("face")
        };

        var uploadResult = await _retryPolicy.ExecuteAsync(async () => await cloudinary.UploadAsync(uploadParams));

        return uploadResult.Error is { }
            ? Result<CloudinaryResult>.Invalid(new ValidationError(uploadResult.Error.Message))
            : Result<CloudinaryResult>.Success(new(uploadResult.PublicId, uploadResult.SecureUrl.AbsoluteUri));
    }

    public async Task<Result<string>> DeletePhotoAsync(string publicId)
    {
        var result = await _retryPolicy.ExecuteAsync(async () => await cloudinary.DestroyAsync(new(publicId)));
        return result.Error is { }
            ? Result<string>.Error(result.Error.Message)
            : Result<string>.Success(result.Result);
    }
}
