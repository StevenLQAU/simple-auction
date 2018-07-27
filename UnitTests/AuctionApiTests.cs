using Auction.Api.ExternalServices;
using Auction.Api.Services.Impl;
using Auction.Api.SignalR;
using Auction.Common.Models.Bids;
using Auction.Common.Models.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class AuctionApiTests
    {
        Mock<IExternalService> _externalServiceMock = new Mock<IExternalService>();

        Mock<ISignalRNotifier> _signalRNotifier = new Mock<ISignalRNotifier>();
        BidsService _bidsService;

        List<ProductModel> _fakeProducts = new List<ProductModel>();
        List<BidModel> _fakeBids = new List<BidModel>();

        [TestInitialize]
        public void Init()
        {
            _fakeProducts.Add(new ProductModel
            {
                CloseTime = DateTimeOffset.Now.AddMinutes(30),
                Id = "1",
                Name = "p1",
                StartTime = DateTimeOffset.Now,
                Status = ProductStatus.InBid
            });

            _fakeProducts.Add(new ProductModel
            {
                CloseTime = DateTimeOffset.Now.AddMinutes(30),
                Id = "2",
                Name = "p2",
                StartTime = DateTimeOffset.Now,
                Status = ProductStatus.InBid
            });

            _fakeProducts.Add(new ProductModel
            {
                CloseTime = DateTimeOffset.Now.AddMinutes(30),
                Id = "3",
                Name = "p3",
                StartTime = DateTimeOffset.Now,
                Status = ProductStatus.InBid
            });


            // fake bids
            _fakeBids.Add(new BidModel
            {
                Amount = 1,
                BidTime = DateTimeOffset.Now.AddMinutes(1),
                UserId = "1",
                ProductId = "1"
            });

            _fakeBids.Add(new BidModel
            {
                Amount = 2,
                BidTime = DateTimeOffset.Now.AddMinutes(2),
                UserId = "1",
                ProductId = "2"
            });

            _fakeBids.Add(new BidModel
            {
                Amount = 3,
                BidTime = DateTimeOffset.Now.AddMinutes(3),
                UserId = "1",
                ProductId = "3"
            });

            _externalServiceMock.Setup(x => x.GetProducts(It.IsAny<int>()))
                .ReturnsAsync(_fakeProducts);

            _externalServiceMock.Setup(x => x.GetHighestBids(It.IsAny<IEnumerable<SimpleProductModel>>()))
                .ReturnsAsync(_fakeBids);

            _bidsService = new BidsService(_externalServiceMock.Object, _signalRNotifier.Object);
        }


        [TestMethod]
        public void CanGetProductsWithBidsAsync()
        {
            var result = _bidsService.GetProducts().Result;
            Assert.AreEqual(3, result.Count());
            //Also check bid and prodcut here. No time to do more testing.
        }
    }
}
