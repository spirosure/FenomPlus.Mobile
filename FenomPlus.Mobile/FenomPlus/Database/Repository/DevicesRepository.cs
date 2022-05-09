using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class DevicesRepository : GenericRepository<DevicesTb>, IDevicesRepository
    {
        private static string TblName = "DevicesRepository";

        public DevicesRepository() : base(TblName)
        {
        }

        public DevicesRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public DevicesRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public DevicesRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

    }
}