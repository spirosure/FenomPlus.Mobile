using System;
using FenomPlus.Database.Repository;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Interfaces;
using LiteDB;
using LiteDB.Engine;

namespace FenomPlus.Services
{
    public class DatabaseService : BaseService, IDatabaseService
    {
        public static string DBName = "database.db";

        private ILiteDatabase _db;
        public ILiteDatabase DB
        {
            get
            {
                if (_db == null)
                {
                    var dbSettings = new EngineSettings()
                    {
                        Filename = Services.DatabaseAccess.DatabasePath(DBName),
                        Password = "passwordhere"
                    };
                    var dbEngine = new LiteEngine(dbSettings);
                    _db = new LiteDatabase(dbEngine);
                }
                return _db;
            }
        }

        public DatabaseService(IAppServices services) : base(services)
        {
        }


        private IBreathManeuverRepository _BreathManeuverRepo;
        public IBreathManeuverRepository BreathManeuverRepo { get { return (_BreathManeuverRepo == null) ? _BreathManeuverRepo = new BreathManeuverRepository() : _BreathManeuverRepo; } }

        private IDevicesRepository _DevicesRepo;
        public IDevicesRepository DevicesRepo { get { return (_DevicesRepo == null) ? _DevicesRepo = new DevicesRepository() : _DevicesRepo; } }

        private ILogsRepository _LogsRepo;
        public ILogsRepository LogsRepo { get { return (_LogsRepo == null) ? _LogsRepo = new LogsRepository() : _LogsRepo; } }

        private IQualityControlRepository _QualityControlRepo;
        public IQualityControlRepository QualityControlRepo { get { return (_QualityControlRepo == null) ? _QualityControlRepo = new QualityControlRepository() : _QualityControlRepo; } }

        private IUsersRepository _UsersRepo;
        public IUsersRepository UsersRepo { get { return (_UsersRepo == null) ? _UsersRepo = new UsersRepository() : _UsersRepo; } }
    }
}
