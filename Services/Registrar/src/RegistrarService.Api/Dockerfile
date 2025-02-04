#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Registrar/src/RegistrarService.Api/RegistrarService.Api.csproj", "Services/Registrar/src/RegistrarService.Api/"]
COPY ["Services/Registrar/src/RegistrarService.Application/RegistrarService.Application.csproj", "Services/Registrar/src/RegistrarService.Application/"]
COPY ["Services/Registrar/src/RegistrarService.Domain/RegistrarService.Domain.csproj", "Services/Registrar/src/RegistrarService.Domain/"]
COPY ["Services/Registrar/src/RegistrarService.Infastructure/RegistrarService.Infastructure.csproj", "Services/Registrar/src/RegistrarService.Infastructure/"]
RUN dotnet restore "Services/Registrar/src/RegistrarService.Api/RegistrarService.Api.csproj"
COPY . .
WORKDIR "/src/Services/Registrar/src/RegistrarService.Api"
RUN dotnet build "RegistrarService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RegistrarService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RegistrarService.Api.dll"]