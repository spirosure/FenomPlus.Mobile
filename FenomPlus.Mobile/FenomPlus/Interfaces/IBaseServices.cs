using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.SDK.Abstractions;
using FenomPlus.SDK.Core.Ble.Interface;

namespace FenomPlus.Interfaces
{
    public interface IBaseServices
    {
        IBleDevice BleDevice { get; }
        IFenomHubSystemDiscovery FenomHub { get; }
        IAppServices Services { get; }

        // repo here
        IBreathManeuverErrorRepository ErrorsRepo { get; }
        IBreathManeuverResultRepository ResultsRepo { get; }
        IQualityControlRepository QCRepo { get; }
        IQualityControlDevicesRepository QCDevicesRepo { get; }
        IQualityControlUsersRepository QCUsersRepo { get; }
    }
}