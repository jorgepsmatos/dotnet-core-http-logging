FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["dotnet-core-http-logging/dotnet-core-http-logging.csproj", "dotnet-core-http-logging/"]
RUN dotnet restore "dotnet-core-http-logging/dotnet-core-http-logging.csproj"
COPY . .
WORKDIR "/src/dotnet-core-http-logging"
RUN dotnet build "dotnet-core-http-logging.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnet-core-http-logging.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnet-core-http-logging.dll"]
