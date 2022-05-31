using System.Threading.Tasks;
using FenomPlus.Models;
using FenomPlus.SDK.Core.Models.Characteristic;
using FenomPlus.Database.Tables;

namespace FenomPlus.Database.Repository.Interfaces
{
    public interface IBreathManeuverResultRepository : IGenericRepository<BreathManeuverResultTb>
    {
        // inserts
        BreathManeuverResultTb Insert(BreathManeuverResultDBModel model);

        // delete
        void Delete(BreathManeuverResultDBModel model);

        // updates
        BreathManeuverResultTb Update(BreathManeuverResultDBModel model);

    }
}