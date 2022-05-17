using System;
using System.Threading.Tasks;
using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Adapters;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using FenomPlus.Models;
using FenomPlus.SDK.Core.Models.Characteristic;
using FenomPlus.Services;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class BreathManeuverRepository : GenericRepository<BreathManeuverTb>, IBreathManeuverRepository
    {
        private static string TblName = "BreathManeuverRepository";

        public BreathManeuverRepository() : base(TblName)
        {
        }

        public BreathManeuverRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public BreathManeuverRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public BreathManeuverRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

        /// <summary>
        /// Insert a record
        /// </summary>
        /// <param name="breathManeuver"></param>
        /// <returns></returns>
        public void Insert(BreathManeuverModel breathManeuver)
        {
            BreathManeuverTb breathManeuverTb = breathManeuver.Convert();
            try
            {
                if (breathManeuver != null)
                {
                    this.Collection.Insert(breathManeuverTb);
                }
            }
            catch (Exception ex)
            {
                //IOC.Services.LogCat.Print(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="breathManeuver"></param>
        /// <returns></returns>
        public void Insert(BreathManeuver breathManeuver)
        {
            this.Insert(BreathManeuverModel.Create(breathManeuver));
        }
    }
}