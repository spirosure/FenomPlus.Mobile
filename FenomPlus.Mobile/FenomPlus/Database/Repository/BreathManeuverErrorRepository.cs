using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Adapters;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using FenomPlus.Models;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class BreathManeuverErrorRepository : GenericRepository<BreathManeuverErrorTb>, IBreathManeuverErrorRepository
    {
        private static string TblName = "BreathManeuverErrorRepository";

        public BreathManeuverErrorRepository() : base(TblName)
        {
        }

        public BreathManeuverErrorRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public BreathManeuverErrorRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public BreathManeuverErrorRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(BreathManeuverErrorDBModel model)
        {
            Delete(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BreathManeuverErrorTb Insert(BreathManeuverErrorDBModel model)
        {
            return Insert(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BreathManeuverErrorTb Update(BreathManeuverErrorDBModel model)
        {
            return Update(model.Convert());
        }
    }
}