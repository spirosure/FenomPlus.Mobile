using System;
using FenomPlus.Core.Interfaces;

namespace FenomPlus.Core.Services
{
    public class AppServices : IAppServices
    {
        public AppServices()
        {
            try
            {
                Container.Register<ICacheService, CacheService>().AsSingleton();
                Container.Register<ICrashReportingService, CrashReportingService>().AsSingleton();
                Container.Register<IDatabaseAccessService, DatabaseAccessService>().AsSingleton();
                Container.Register<IDatabaseService, DatabaseService>().AsSingleton();
                Container.Register<IDebugConsoleService, DebugConsoleService>().AsSingleton();
                Container.Register<IDependencyService, DependencyService>().AsSingleton();
                Container.Register<IEnvironmentService, EnvironmentService>().AsSingleton();
                Container.Register<IEssentialsServices, EssentialsServices>().AsSingleton();
                Container.Register<IExceptionsService, ExceptionsService>().AsSingleton();
                Container.Register<IGlobalService, GlobalService>().AsSingleton();
                Container.Register<ILogCatService, LogCatService>().AsSingleton();
                Container.Register<INetworkService, NetworkService>().AsSingleton();
                Container.Register<IPreferencesService, PreferencesService>().AsSingleton();
                Container.Register<IResourceService, ResourceService>().AsSingleton();
                Container.Register<ISecureFirmwareService, SecureFirmwareService>().AsSingleton();
                Container.Register<IStatusService, StatusService>().AsSingleton();

                // 3rd party componets
                Container.Register<IBrowserEssentials, BrowserEssentials>().AsSingleton();
                Container.Register<ICameraEssentials, CameraEssentials>().AsSingleton();
                Container.Register<ILauncherEssentials, LauncherEssentials>().AsSingleton();
                Container.Register<IMainThreadEssentials, MainThreadEssentials>().AsSingleton();
                Container.Register<INetworkEssentials, NetworkEssentials>().AsSingleton();
                Container.Register<IPermissionsEssentials, PermissionsEssentials>().AsSingleton();
                Container.Register<IPreferencesEssentials, PreferencesEssentials>().AsSingleton();
                Container.Register<ISettingsEssentials, SettingsEssentials>().AsSingleton();
            }
            catch (Exception ex)
            {
                CrashReporting?.Push(ex);
            }
        }

        public static TinyIoCContainer Container
        {
            get { return TinyIoCContainer.Current; }
        }

        protected IEssentialsServices _EssentialsServices;
        public IEssentialsServices Essentials
        {
            get { return _EssentialsServices ?? (_EssentialsServices = Container.Resolve<IEssentialsServices>()); }
            set { _EssentialsServices = value; }
        }

        protected IDatabaseAccessService _DatabaseAccess;
        public IDatabaseAccessService DatabaseAccess
        {
            get { return _DatabaseAccess ?? (_DatabaseAccess = Container.Resolve<IDatabaseAccessService>()); }
            set { _DatabaseAccess = value; }
        }

        protected INetworkService _Network;
        public INetworkService Network
        {
            get { return _Network ?? (_Network = Container.Resolve<INetworkService>()); }
            set { _Network = value; }
        }

        protected IDatabaseService _Database;
        public IDatabaseService Database
        {
            get { return _Database ?? (_Database = Container.Resolve<IDatabaseService>()); }
            set { _Database = value; }
        }

        protected ICacheService _Cache;
        public ICacheService Cache
        {
            get { return _Cache ?? (_Cache = Container.Resolve<ICacheService>()); }
            set { _Cache = value; }
        }

        protected ICrashReportingService _CrashReporting;
        public ICrashReportingService CrashReporting
        {
            get { return _CrashReporting ?? (_CrashReporting = Container.Resolve<ICrashReportingService>()); }
            set { _CrashReporting = value; }
        }

        protected IDebugConsoleService _Debug;
        public IDebugConsoleService Debug
        {
            get { return _Debug ?? (_Debug = Container.Resolve<IDebugConsoleService>()); }
            set { _Debug = value; }
        }

        protected IDeviceInfoService _DeviceInfo;
        public IDeviceInfoService DeviceInfo
        {
            get { return _DeviceInfo ?? (_DeviceInfo = Container.Resolve<IDeviceInfoService>()); }
            set { _DeviceInfo = value; }
        }

        protected IEnvironmentService _Environment;
        public IEnvironmentService Environment
        {
            get { return _Environment ?? (_Environment = Container.Resolve<IEnvironmentService>()); }
            set { _Environment = value; }
        }


        protected IDependencyService _Dependency;
        public IDependencyService Dependency
        {
            get { return _Dependency ?? (_Dependency = Container.Resolve<IDependencyService>()); }
            set { _Dependency = value; }
        }

        protected IExceptionsService _Exceptions;
        public IExceptionsService Exceptions
        {
            get { return _Exceptions ?? (_Exceptions = Container.Resolve<IExceptionsService>()); }
            set { _Exceptions = value; }
        }

        protected IGlobalService _GlobalService;
        public IGlobalService Global
        {
            get { return _GlobalService ?? (_GlobalService = Container.Resolve<IGlobalService>()); }
            set { _GlobalService = value; }
        }

        protected ILogCatService _LogCat;
        public ILogCatService LogCat
        {
            get { return _LogCat ?? (_LogCat = Container.Resolve<ILogCatService>()); }
            set { _LogCat = value; }
        }

        protected IPreferencesService _Preferences;
        public IPreferencesService Preferences
        {
            get { return _Preferences ?? (_Preferences = Container.Resolve<IPreferencesService>()); }
            set { _Preferences = value; }
        }

        protected IResourceService _Resource;
        public IResourceService Resource
        {
            get { return _Resource ?? (_Resource = Container.Resolve<IResourceService>()); }
            set { _Resource = value; }
        }

        protected ISecureFirmwareService _SecureFirmware;
        public ISecureFirmwareService SecureFirmware
        {
            get { return _SecureFirmware ?? (_SecureFirmware = Container.Resolve<ISecureFirmwareService>()); }
            set { _SecureFirmware = value; }
        }

        protected IStatusService _Status;
        public IStatusService Status
        {
            get { return _Status ?? (_Status = Container.Resolve<IStatusService>()); }
            set { _Status = value; }
        }

    }
}