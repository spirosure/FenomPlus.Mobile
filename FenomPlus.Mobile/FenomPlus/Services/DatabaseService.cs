﻿using System;
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

        private IBreathManeuverErrorRepository _BreathManeuverErrorRepo;
        public IBreathManeuverErrorRepository BreathManeuverErrorRepo { get { return (_BreathManeuverErrorRepo == null) ? _BreathManeuverErrorRepo = new BreathManeuverErrorRepository() : _BreathManeuverErrorRepo; } }

        private IBreathManeuverResultRepository _BreathManeuverResultRepo;
        public IBreathManeuverResultRepository BreathManeuverResultRepo { get { return (_BreathManeuverResultRepo == null) ? _BreathManeuverResultRepo = new BreathManeuverResultRepository() : _BreathManeuverResultRepo; } }

        private IQualityControlRepository _QualityControlRepo;
        public IQualityControlRepository QualityControlRepo { get { return (_QualityControlRepo == null) ? _QualityControlRepo = new QualityControlRepository() : _QualityControlRepo; } }

        private IQualityControlDevicesRepository _QualityControlDevicesRepo;
        public IQualityControlDevicesRepository QualityControlDevicesRepo { get { return (_QualityControlDevicesRepo == null) ? _QualityControlDevicesRepo = new QualityControlDevicesRepository() : _QualityControlDevicesRepo; } }

        private IQualityControlUsersRepository _QualityControlUsersRepo;
        public IQualityControlUsersRepository QualityControlUsersRepo { get { return (_QualityControlUsersRepo == null) ? _QualityControlUsersRepo = new QualityControlUsersRepository() : _QualityControlUsersRepo; } }
    }
}
