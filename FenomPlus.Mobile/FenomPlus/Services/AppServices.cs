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
                Container.Register<IDatabaseService, DatabaseService>().AsSingleton();
                Container.Register<ILogCatService, LogCatService>().AsSingleton();                
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
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

        protected ICacheService _Cache;
        public ICacheService Cache
        {
            get { return _Cache ?? (_Cache = Container.Resolve<ICacheService>()); }
            set { _Cache = value; }
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
        protected ILogCatService _LogCat;
        public ILogCatService LogCat
        {
            get { return _LogCat ?? (_LogCat = Container.Resolve<ILogCatService>()); }
            set { _LogCat = value; }
        }
    }
}