using System;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Interfaces;
using LiteDB;

namespace FenomPlus.Services
{
    public class DatabaseService : BaseService, IDatabaseService
    {
        public DatabaseService()
        {
        }

        public ILiteDatabase DB => throw new NotImplementedException();

        public ILogsRepository LogsRepo => throw new NotImplementedException();
    }
}
