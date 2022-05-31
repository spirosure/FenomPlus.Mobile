using FenomPlus.Database.Tables;
using FenomPlus.SDK.Core.Models.Characteristic;

namespace FenomPlus.Models
{
    public class BreathManeuverErrorDBModel : BreathManeuverErrorTb
    {
        public BreathManeuverErrorDBModel() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BreathManeuverErrorDBModel Create(BreathManeuver input)
        {
            return new BreathManeuverErrorDBModel()
            {
            };
        }
    }
}
