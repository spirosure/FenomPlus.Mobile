using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FenomPlus.Core.Essentials
{
    public interface INetworkEssentials
    {
        bool IsSupported { get; }
        bool IsConnected { get; }
        IEnumerable<ConnectionTypeEnum> ConnectionTypes { get; }
        IEnumerable<ulong> Bandwidths { get; }
        Task<bool> IsReachable(string host, int msTimeout = 5000);
        Task<bool> IsRemoteReachable(string host, int port = 80, int msTimeout = 5000);
    }
}

