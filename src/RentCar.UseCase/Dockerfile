FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/RentCar.UseCase/RentCar.UseCase.csproj", "src/RentCar.UseCase/"]
COPY ["src/RentCar.Application/RentCar.Application.csproj", "src/RentCar.Application/"]
COPY ["src/RentCar.Infrastructure/RentCar.Infrastructure.csproj", "src/RentCar.Infrastructure/"]
COPY ["src/RentCar.Core/RentCar.Core.csproj", "src/RentCar.Core/"]
RUN dotnet restore "./src/RentCar.UseCase/./RentCar.UseCase.csproj"
COPY . .
WORKDIR "/src/src/RentCar.UseCase"
RUN dotnet build "./RentCar.UseCase.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RentCar.UseCase.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentCar.UseCase.dll"]