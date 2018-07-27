using Auction.Common.Models.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.SignalR.Events
{
    public class BidsCreatedEvent: SignalREventBase
    {
        public static string EventName = "NewBidCreated";
        public BidModel BidModel { get; set; }
    }
}
