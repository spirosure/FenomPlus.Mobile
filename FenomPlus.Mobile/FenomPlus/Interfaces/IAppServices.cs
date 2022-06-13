
namespace FenomPlus.Interfaces
{
    public interface IAppServices
    {
        IBleHubService BleHub { get; }
        ICacheService Cache { get; set; }
        IDatabaseService Database { get; set; }
        ILogCatService LogCat { get; set; }
    }
}
