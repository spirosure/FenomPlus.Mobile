using System;
using FenomPlus.Interfaces;
using TinyIoC;

namespace FenomPlus.Services
{
    public class AppServices : IAppServices
    {
        public AppServices()
        {
            try
            {
                Container.Register<IBleHubService, BleHubService>().AsSingleton();
                Container.Register<ICacheService, CacheService>().AsSingleton();
                Container.Register<IDatabaseAccessService, DatabaseAccessService>().AsSingleton();
                Container.Register<IDatabaseService, DatabaseService>().AsSingleton();
                Container.Register<IEnvironmentService, EnvironmentService>().AsSingleton();
                Container.Register<INavigationService, NavigationService>().AsSingleton();
                Container.Register<IStatusService, StatusService>().AsSingleton();
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static TinyIoCContainer Container
        {
            get { return TinyIoCContainer.Current; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected IBleHubService _BleHub;
        public IBleHubService BleHub
        {
            get { return _BleHub ?? (_BleHub = Container.Resolve<IBleHubService>()); }
            set { _BleHub = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected IDatabaseAccessService _DatabaseAccess;
        public IDatabaseAccessService DatabaseAccess
        {
            get { return _DatabaseAccess ?? (_DatabaseAccess = Container.Resolve<IDatabaseAccessService>()); }
            set { _DatabaseAccess = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected IDatabaseService _Database;
        public IDatabaseService Database
        {
            get { return _Database ?? (_Database = Container.Resolve<IDatabaseService>()); }
            set { _Database = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected ICacheService _Cache;
        public ICacheService Cache
        {
            get { return _Cache ?? (_Cache = Container.Resolve<ICacheService>()); }
            set { _Cache = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected IEnvironmentService _Environment;
        public IEnvironmentService Environment
        {
            get { return _Environment ?? (_Environment = Container.Resolve<IEnvironmentService>()); }
            set { _Environment = value; }
        }

        protected INavigationService _Navigation;
        public INavigationService Navigation
        {
            get { return _Navigation ?? (_Navigation = Container.Resolve<INavigationService>()); }
            set { _Navigation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected IStatusService _Status;
        public IStatusService Status
        {
            get { return _Status ?? (_Status = Container.Resolve<IStatusService>()); }
            set { _Status = value; }
        }

    }
}