FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5001


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Apis/TradeHub.Api/TradeHub.Api.csproj", "src/Apis/TradeHub.Api/"]
RUN dotnet restore "./src/Apis/TradeHub.Api/TradeHub.Api.csproj"
COPY . .
WORKDIR "/src/src/Apis/TradeHub.Api"
RUN dotnet build "./TradeHub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TradeHub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TradeHub.Api.dll"]