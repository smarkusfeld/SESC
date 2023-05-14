# syntax=docker/dockerfile:1
# Define base image for production
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build and publish code into build context
# Define build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env


# Copy all csproj files and restore as distinct layers
WORKDIR /src
COPY ["src/FinanceService.Api/FinanceService.Api.csproj", "FinanceService.Api/"]
COPY ["src/FinanceService.Application/FinanceService.Application.csproj", "FinanceService.Application/"]
COPY ["src/FinanceService.Domain/FinanceService.Domain.csproj", "FinanceService.Domain/"]
COPY ["src/FinanceService.Infastructure/FinanceService.Infastructure.csproj", "FinanceService.Infastructure/"]
RUN dotnet restore "FinanceService.Api/FinanceService.Api.csproj"
COPY . .
WORKDIR "/src/src/FinanceService.Api"
RUN dotnet build FinanceService.Api.csproj -c Release -o /app

# Build and publish code into publish context 
# Copy output from build context without all build tools of sdk image
FROM build-env AS publish
RUN dotnet publish "FinanceService.Api.csproj" -c Release -o /app

# Build and publish code into runtime context
FROM base AS runtime
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FinanceService.Api.dll"]
