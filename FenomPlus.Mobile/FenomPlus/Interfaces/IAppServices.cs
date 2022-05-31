using System;
using FenomPlus.Interfaces;

namespace FenomPlus.Interfaces
{
    public interface IAppServices
    {
        IBleHubService BleHub { get; }
        ICacheService Cache { get; set; }
        IDatabaseService Database { get; set; }
        IDatabaseAccessService DatabaseAccess { get; set; }
        IEnvironmentService Environment { get; set; }
        ILogCatService LogCat { get; set; }
        INavigationService Navigation { get; }
        IStatusService Status { get; set; }
    }
}
