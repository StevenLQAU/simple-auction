# Introduction 
A simple auction solution for testing.
This solution is build be using SOA.
3 domain services: Auction.Bid.Api, Auction.Product.Api and Auction.User.Api
1 Shared kernal service (service bus): Auction.Api

The Auction.Api simplely communicate with the other 3 end points by using Http.

UX is implemented by using Angular, only contains the basic function: User login, Getting products and bids and do bid.

Authorization is implemented by Jwt.


# Getting Started
Pre-populate 3 users when start in development mode:
1. bloodborn:abcdef
2. monsterhunter:123456
3. zelda:111111

# Build and Test


# Contribute
