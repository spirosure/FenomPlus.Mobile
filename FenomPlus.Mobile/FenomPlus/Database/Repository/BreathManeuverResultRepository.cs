using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Adapters;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using FenomPlus.Models;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class BreathManeuverResultRepository : GenericRepository<BreathManeuverResultTb>, IBreathManeuverResultRepository
    {
        private static string TblName = "BreathManeuverResultRepository";

        public BreathManeuverResultRepository() : base(TblName)
        {
        }

        public BreathManeuverResultRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public BreathManeuverResultRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public BreathManeuverResultRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(BreathManeuverResultDBModel model)
        {
            Delete(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BreathManeuverResultTb Insert(BreathManeuverResultDBModel model)
        {
            return Insert(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BreathManeuverResultTb Update(BreathManeuverResultDBModel model)
        {
            return Update(model.Convert());
        }
    }
}