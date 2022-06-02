using System.Collections.Generic;
using System.Linq;

namespace FenomPlus.Database.Adapters
{
    public abstract class AdapterBase<Tout, Tin>
    {
        public abstract Tout ConvertFrom(Tin input);

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual IEnumerable<Tout> Convert(IEnumerable<Tin> list)
        {
            return list.Select(tn => ConvertFrom(tn));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual IList<Tout> Convert(IList<Tin> list)
        {
            return list.Select(tn => ConvertFrom(tn)).ToList();
        }
    }
}
