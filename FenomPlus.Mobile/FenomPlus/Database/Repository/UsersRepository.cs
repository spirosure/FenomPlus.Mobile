using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class UsersRepository : GenericRepository<UsersTb>, IUsersRepository
    {
        private static string TblName = "UsersRepository";

        public UsersRepository() : base(TblName)
        {
        }

        public UsersRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public UsersRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public UsersRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

    }
}