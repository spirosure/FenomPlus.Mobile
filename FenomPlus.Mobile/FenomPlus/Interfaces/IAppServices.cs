
namespace FenomPlus.Interfaces
{
    public interface IAppServices
    {
        IBleHubService BleHub { get; }
        ICacheService Cache { get; }
        IDatabaseService Database { get; }
        IDebugLogFileService DebugLogFile { get; }
        ILogCatService LogCat { get; }
    }
}
