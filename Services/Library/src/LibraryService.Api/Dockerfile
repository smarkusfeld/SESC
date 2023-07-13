#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Library/src/LibraryService.Api/LibraryService.Api.csproj", "Services/Library/src/LibraryService.Api/"]
COPY ["Services/Library/src/LibraryService.Application/LibraryService.Application.csproj", "Services/Library/src/LibraryService.Application/"]
COPY ["Services/Library/src/LibraryService.Domain/LibraryService.Domain.csproj", "Services/Library/src/LibraryService.Domain/"]
COPY ["Services/Library/src/LibraryService.Infastructure/LibraryService.Infastructure.csproj", "Services/Library/src/LibraryService.Infastructure/"]
RUN dotnet restore "Services/Library/src/LibraryService.Api/LibraryService.Api.csproj"
COPY . .
WORKDIR "/src/Services/Library/src/LibraryService.Api"
RUN dotnet build "LibraryService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryService.Api.dll"]