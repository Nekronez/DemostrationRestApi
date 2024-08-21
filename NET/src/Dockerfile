FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5900:5900

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["FondApi.Host/FondApi.Host.csproj", "FondApi.Host/"]
COPY ["FondApi.Business/FondApi.Business.csproj", "FondApi.Business/"]
COPY ["FondApi.Repository/FondApi.Repository.csproj", "FondApi.Repository/"]
RUN dotnet restore "FondApi.Host/FondApi.Host.csproj"

COPY . .
RUN dotnet build "FondApi.Host/FondApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FondApi.Host/FondApi.Host.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FondApi.Host.dll"]