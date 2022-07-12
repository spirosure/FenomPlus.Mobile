using FenomPlus.Models;
using FenomPlus.Database.Tables;
using System.Collections.Generic;

namespace FenomPlus.Database.Repository.Interfaces
{
    public interface IBreathManeuverResultRepository // : IGenericRepository<BreathManeuverResultTb>
    {
        // inserts
        BreathManeuverResultTb Insert(BreathManeuverResultDBModel model);

        // delete
        void Delete(BreathManeuverResultDBModel model);

        // updates
        BreathManeuverResultTb Update(BreathManeuverResultDBModel model);

        IEnumerable<BreathManeuverResultTb> SelectAll();

    }
}