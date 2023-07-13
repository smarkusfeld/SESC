#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Student/src/StudentService.Api/StudentService.Api.csproj", "Services/Student/src/StudentService.Api/"]
COPY ["Services/Student/src/StudentService.Application/StudentService.Application.csproj", "Services/Student/src/StudentService.Application/"]
COPY ["Services/Student/src/StudentService.Domain/StudentService.Domain.csproj", "Services/Student/src/StudentService.Domain/"]
COPY ["Services/Student/src/StudentService.Infastructure/StudentService.Infastructure.csproj", "Services/Student/src/StudentService.Infastructure/"]
RUN dotnet restore "Services/Student/src/StudentService.Api/StudentService.Api.csproj"
COPY . .
WORKDIR "/src/Services/Student/src/StudentService.Api"
RUN dotnet build "StudentService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentService.Api.dll"]