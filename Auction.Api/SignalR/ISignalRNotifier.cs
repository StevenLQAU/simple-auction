using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.SignalR
{
    public interface ISignalRNotifier
    {
        Task SendMessage(string eventName, object eventParam);
    }
}
