using FenomPlus.Models;
using FenomPlus.Database.Tables;

namespace FenomPlus.Database.Repository.Interfaces
{
    public interface IBreathManeuverErrorRepository : IGenericRepository<BreathManeuverErrorTb>
    {
        // inserts
        BreathManeuverErrorTb Insert(BreathManeuverErrorDBModel model);

        // delete
        void Delete(BreathManeuverErrorDBModel model);

        // updates
        BreathManeuverErrorTb Update(BreathManeuverErrorDBModel model);

    }
}