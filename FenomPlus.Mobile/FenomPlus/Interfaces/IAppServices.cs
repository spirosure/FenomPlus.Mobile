using System;
using FenomPlus.Interfaces;

namespace FenomPlus.Interfaces
{
    public interface IAppServices
    {
        IBleHubService BleHub { get; }
        IDatabaseService Database { get; set; }
        IDatabaseAccessService DatabaseAccess { get; set; }
        IEnvironmentService Environment { get; set; }
        INavigationService Navigation { get; }
        IStatusService Status { get; set; }
    }
}
