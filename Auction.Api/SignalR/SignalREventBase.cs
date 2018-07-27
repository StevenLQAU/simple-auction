using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.SignalR
{
    public abstract class SignalREventBase
    {
        public static string GeneralEventName => "SignalRNotify";
    }
}
