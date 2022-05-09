using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class LogsRepository : GenericRepository<LogsTb>, ILogsRepository
    {
        private static string TblName = "logs";

        public LogsRepository() : base(TblName)
        {
        }

        public LogsRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public LogsRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public LogsRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

    }
}