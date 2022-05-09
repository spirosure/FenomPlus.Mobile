using System;
using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Adapters
{
    public static class QualityControlAdapter
    {
        public static QualityControlModel Convert(this QualityControlTb input)
        {
            if (input == null) return null;
            return new QualityControlModel()
            {
                Id = input.Id
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static QualityControlTb Convert(this QualityControlModel input)
        {
            if (input == null) return null;
            return new QualityControlTb()
            {
                Id = input.Id
            };
        }
    }
}
