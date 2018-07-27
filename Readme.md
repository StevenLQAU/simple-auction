# Introduction 
A simple auction solution for tech assessment.  
This solution is built by following SOA.  
  

3 domain services:  
- **Auction.Bid.Api**  
- **Auction.Product.Api**  
- **Auction.User.Api**  
  
1 Shared kernal service (service bus):   
- **Auction.Api**

The **Auction.Api** is able to simplely communicate with the other 3 end points by using Http.

UX is implemented by using Angular, only contains the basic function: User login, Getting products and bids and do bid.

Authorization is implemented by Jwt.

To make it simple, the UX is pre-built. And the files is in dist folder. Docker file will just copy the files to images.

# Getting Started
Pre-populate 3 users when start in development mode:
1. bloodborn:abcdef
2. monsterhunter:123456
3. zelda:111111

# Build and run
- Windows:    `.\build.ps1 | .\run.ps1`
- Linux: `.\build.sh | .\run.sh`
- browse <http://localhost:3000>



