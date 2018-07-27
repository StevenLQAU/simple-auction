using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Api.ExternalServices;
using Auction.Api.SignalR;
using Auction.Api.SignalR.Events;
using Auction.Common.Models.Bids;
using Auction.Common.Models.Products;

namespace Auction.Api.Services.Impl
{
    public class BidsService : IBidsService
    {
        private readonly IExternalService _externalService;
        private readonly ISignalRNotifier _signalRNotifier;

        public BidsService(IExternalService externalService, ISignalRNotifier signalRNotifier)
        {
            _externalService = externalService;
            _signalRNotifier = signalRNotifier;
        }

        public async Task<BidModel> CreateBid(BidModel bidModel)
        {
            bidModel.BidTime = DateTimeOffset.Now;
            
            var newBid =  await _externalService.CreateBid(bidModel);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Task.Run(() =>
            {
                try
                {
                    // Should check the bid close time before send.
                    _signalRNotifier.SendMessage(BidsCreatedEvent.EventName, new BidsCreatedEvent { BidModel = newBid });
                }
                catch
                {

                }
            });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            return newBid;
        }

        public async Task<IEnumerable<ProductBidModel>> GetProducts()
        {
            var allProducts = await _externalService.GetProducts((int)(ProductStatus.End | ProductStatus.InBid | ProductStatus.NotStart));
            var simpleProductsModel = allProducts.Select(x => new SimpleProductModel
            {
                CloseTime = x.CloseTime,
                StartTime = x.StartTime,
                Id = x.Id
            });

            var bids = await _externalService.GetHighestBids(simpleProductsModel);

            List<ProductBidModel> result = new List<ProductBidModel>();

            List<Task> tasks = new List<Task>();
            foreach (var product in allProducts)
            {
                var oldStatus = product.Status;

                if(product.StartTime <= DateTimeOffset.Now && product.Status != ProductStatus.InBid)
                {
                    product.Status = ProductStatus.InBid;
                }

                if (product.CloseTime <= DateTimeOffset.Now && product.Status != ProductStatus.End)
                {
                    product.Status = ProductStatus.End;
                }

                if (oldStatus != product.Status)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        _externalService.UpdateProduct(product);
                        //SignalR notice clients the new product;
                    }));
                }


                result.Add(new ProductBidModel
                {

                    HighestBid = bids.FirstOrDefault(b => b.ProductId == product.Id),
                    Product = product
                });


            }

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Task.Run(() =>
             {
                 try
                 {
                     Task.WaitAll(tasks.ToArray());
                 }
                 catch
                 {

                 }
             });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            return result;

        }
    }
}
