
## Define base image for production
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

## Build and publish code into build context
# Define build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /app

# Copy files to build context
COPY ["src/FinanceService.Api/FinanceService.Api.csproj", "FinanceService.Api/"]
COPY ["src/FinanceService.Application/FinanceService.Application.csproj", "FinanceService.Application/"]
COPY ["src/FinanceService.Domain/FinanceService.Domain.csproj", "FinanceService.Domain/"]
COPY ["src/FinanceService.Infastructure/FinanceService.Infastructure.csproj", "FinanceService.Infastructure/"]
# Restore as distinct layers
RUN dotnet restore "src/FinanceService.Api/FinanceService.Api.csproj"
# Copy and compile app source
COPY . .
# Build Project Configuration 
WORKDIR "/src/FinanceService.Api"
RUN dotnet build -c Release -o /app

## Build and publish code into publish context 
# Copy output from build context without all build tools of sdk image
FROM base AS publish
RUN dotnet publish -c Release -o /publish

## Build and publish code into runtime context
FROM base AS runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "FinanceService.Api.dll"]




