FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 6496
EXPOSE 44341

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Auction.Bid.Api/Auction.Bid.Api.csproj Auction.Bid.Api/
RUN dotnet restore Auction.Bid.Api/Auction.Bid.Api.csproj
COPY . .
WORKDIR /src/Auction.Bid.Api
RUN dotnet build Auction.Bid.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Auction.Bid.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Auction.Bid.Api.dll"]
