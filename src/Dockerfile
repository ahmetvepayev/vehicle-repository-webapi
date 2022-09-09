FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.sln ./
COPY VehicleRepo.Api/*.csproj ./VehicleRepo.Api/
COPY VehicleRepo.Core/Domain/*.csproj ./VehicleRepo.Core/Domain/
COPY VehicleRepo.Core/Application/*.csproj ./VehicleRepo.Core/Application/
COPY VehicleRepo.Infrastructure/*.csproj ./VehicleRepo.Infrastructure/
COPY VehicleRepo.Utility/*.csproj ./VehicleRepo.Utility/

RUN dotnet restore

COPY VehicleRepo.Api/ ./VehicleRepo.Api/
COPY VehicleRepo.Core/Domain/ ./VehicleRepo.Core/Domain/
COPY VehicleRepo.Core/Application/ ./VehicleRepo.Core/Application/
COPY VehicleRepo.Infrastructure/ ./VehicleRepo.Infrastructure/
COPY VehicleRepo.Utility/ ./VehicleRepo.Utility/

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "VehicleRepo.Api.dll"]