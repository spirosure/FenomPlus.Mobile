using System;

namespace FenomPlus.SDK.Abstractions
{
    public interface IFenomHubSystem
    {
        void Initialize();
        void Connect();
        void Disconnect();
    }
}