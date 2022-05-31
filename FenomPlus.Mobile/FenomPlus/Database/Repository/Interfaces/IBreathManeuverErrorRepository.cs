using System.Threading.Tasks;
using FenomPlus.Models;
using FenomPlus.SDK.Core.Models.Characteristic;
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