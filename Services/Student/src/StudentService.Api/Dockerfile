#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/StudentService.Api/StudentService.Api.csproj", "src/StudentService.Api/"]
COPY ["src/StudentService.Application/StudentService.Application.csproj", "src/StudentService.Application/"]
COPY ["src/StudentService.Domain/StudentService.Domain.csproj", "src/StudentService.Domain/"]
COPY ["src/StudentService.Infastructure/StudentService.Infastructure.csproj", "src/StudentService.Infastructure/"]
RUN dotnet restore "src/StudentService.Api/StudentService.Api.csproj"
COPY . .
WORKDIR "/src/src/StudentService.Api"
RUN dotnet build "StudentService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentService.Api.dll"]