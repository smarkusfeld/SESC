
# syntax=docker/dockerfile:1

#image used to build application
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /src/
#copy all csproj files
COPY src/FinanceService.Api/*.csproj .
RUN dotnet restore 
#copy all sourcefiles into image
COPY src .
#build the project
WORKDIR "/src/FinanceService.Api"
RUN dotnet publish -c Release -o /publish

#image used to run application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "FinanceService.Api.dll"]




