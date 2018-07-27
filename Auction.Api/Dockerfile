FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 10768
EXPOSE 44391

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Auction.Api/Auction.Api.csproj Auction.Api/
RUN dotnet restore Auction.Api/Auction.Api.csproj
COPY . .
WORKDIR /src/Auction.Api
RUN dotnet build Auction.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Auction.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Auction.Api.dll"]
