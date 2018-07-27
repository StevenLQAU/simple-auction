FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 6480
EXPOSE 44364

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Auction.Product.Api/Auction.Product.Api.csproj Auction.Product.Api/
RUN dotnet restore Auction.Product.Api/Auction.Product.Api.csproj
COPY . .
WORKDIR /src/Auction.Product.Api
RUN dotnet build Auction.Product.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Auction.Product.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Auction.Product.Api.dll"]
