using System;
using FenomPlus.Core.Interfaces.Ble;

namespace FenomPlus.Core.Interfaces
{
    public interface IAppServices
    {
        IBleHubService BleHub { get; }

        //IBrandingService Branding { get; }
        //ICacheService Cache { get; set; }
        //ICrashReportingService CrashReporting { get; set; }
        //IDatabaseService Database { get; set; }
        //IDatabaseAccessService DatabaseAccess { get; set; }
        //IDebugConsoleService Debug { get; set; }
        //IDeviceInfoService DeviceInfo { get; set; }
        //IGlobalService Global { get; }
        //IEnvironmentService Environment { get; set; }
        //IExceptionsService Exceptions { get; set; }
        //IEssentialsServices Essentials { get; set; }
        //IGlobalService Global { get; set; }
        //ILogCatService LogCat { get; set; }
        //IMobileRestClientService MobileRestClient { get; }
        //INavigationService Navigation { get; }
        //INetworkService Network { get; set; }
        //IPreferencesService Preferences { get; set; }
        //IPushNotificationService PushNotifications { get; }
        //IResourceService Resource { get; set; }
        //IStatusService Status { get; set; }
        //IToastService Toast { get; }
    }
}
