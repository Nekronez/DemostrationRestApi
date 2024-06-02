#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5900:5900

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/FondApi.Host/FondApi.Host.csproj", "FondApi.Host/FondApi.Host.csproj"]
COPY ["/FondApi.Business/FondApi.Business.csproj", "FondApi.Business/FondApi.Business.csproj"]
COPY ["/FondApi.Repository/FondApi.Repository.csproj", "FondApi.Repository/FondApi.Repository.csproj"]

RUN dotnet restore "FondApi.Host/FondApi.Host.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "FondApi.Business/FondApi.Business.csproj" -c Release -o /app/build
WORKDIR "/src"
RUN dotnet build "FondApi.Repository/FondApi.Repository.csproj" -c Release -o /app/build
WORKDIR "/src"
RUN dotnet build "FondApi.Host/FondApi.Host.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "FondApi.Host/FondApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FondApi.Host.dll"]
