FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 6220
EXPOSE 44383

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ../Auction.User.Api/Auction.User.Api.csproj ../Auction.User.Api/
RUN dotnet restore ../Auction.User.Api/Auction.User.Api.csproj
COPY . .
WORKDIR /src/../Auction.User.Api
RUN dotnet build Auction.User.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Auction.User.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Auction.User.Api.dll"]
