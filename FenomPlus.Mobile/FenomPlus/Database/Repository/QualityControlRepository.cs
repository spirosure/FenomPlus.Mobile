using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class QualityControlRepository : GenericRepository<QualityControlTb>, IQualityControlRepository
    {
        private static string TblName = "QualityControlRepository";

        public QualityControlRepository() : base(TblName)
        {
        }

        public QualityControlRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public QualityControlRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public QualityControlRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

    }
}