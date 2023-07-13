#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Finance/src/FinanceService.Api/FinanceService.Api.csproj", "Services/Finance/src/FinanceService.Api/"]
COPY ["Services/Finance/src/FinanceService.Application/FinanceService.Application.csproj", "Services/Finance/src/FinanceService.Application/"]
COPY ["Services/Finance/src/FinanceService.Domain/FinanceService.Domain.csproj", "Services/Finance/src/FinanceService.Domain/"]
COPY ["Services/Finance/src/FinanceService.Infastructure/FinanceService.Infastructure.csproj", "Services/Finance/src/FinanceService.Infastructure/"]
RUN dotnet restore "Services/Finance/src/FinanceService.Api/FinanceService.Api.csproj"
COPY . .
WORKDIR "/src/Services/Finance/src/FinanceService.Api"
RUN dotnet build "FinanceService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinanceService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinanceService.Api.dll"]