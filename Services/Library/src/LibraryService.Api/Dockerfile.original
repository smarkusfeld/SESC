#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/LibraryService.Api/LibraryService.Api.csproj", "src/LibraryService.Api/"]
COPY ["src/LibraryService.Application/LibraryService.Application.csproj", "src/LibraryService.Application/"]
COPY ["src/LibraryService.Domain/LibraryService.Domain.csproj", "src/LibraryService.Domain/"]
COPY ["src/LibraryService.Infastructure/LibraryService.Infastructure.csproj", "src/LibraryService.Infastructure/"]
RUN dotnet restore "src/LibraryService.Api/LibraryService.Api.csproj"
COPY . .
WORKDIR "/src/src/LibraryService.Api"
RUN dotnet build "LibraryService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryService.Api.dll"]