using Auction.Common.Models.Bids;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.SignalR
{
    public class SignalRNotifier: Hub, ISignalRNotifier
    {
        protected IHubContext<SignalRNotifier> _context;

        public SignalRNotifier(IHubContext<SignalRNotifier> context)
        {
            _context = context;
        }

        public async Task SendMessage(string eventName, object eventParam)
        {
            await _context.Clients.All.SendAsync(SignalREventBase.GeneralEventName, eventName, eventParam);
        }
    }
}
