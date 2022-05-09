using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class ErrorsRepository : GenericRepository<ErrorsTb>, IErrorsRepository
    {
        private static string TblName = "errors";

        public ErrorsRepository() : base(TblName)
        {
        }

        public ErrorsRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public ErrorsRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public ErrorsRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

    }
}