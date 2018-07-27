docker run -d --name mongodb  -p 27027:27017 mongo:latest
docker run -d --name user_api --link mongodb:mongodb -e ASPNETCORE_ENVIRONMENT=Development stevenauctionuserapi:latest
docker run -d --name bid_api --link mongodb:mongodb -e ASPNETCORE_ENVIRONMENT=Development stevenauctionbidapi:latest
docker run -d --name product_api --link mongodb:mongodb -e ASPNETCORE_ENVIRONMENT=Development  stevenauctionproductapi:latest
docker run -d --name auction_api --link user_api:user_api --link bid_api:bid_api --link product_api:product_api -e ASPNETCORE_ENVIRONMENT=Development -p 10000:80  stevenauctionapi:latest
docker run -d --name auction_ux --link auction_api:auction_api -p 3000:80 stevenauction-ux:latest