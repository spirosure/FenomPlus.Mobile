using System;
using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Adapters
{
    public static class QualityControlAdapter
    {
        public static QualityControlDBModel Convert(this QualityControlTb input)
        {
            if (input == null) return null;
            return new QualityControlDBModel()
            {
                Id = input.Id
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static QualityControlTb Convert(this QualityControlDBModel input)
        {
            if (input == null) return null;
            return new QualityControlTb()
            {
                Id = input.Id
            };
        }
    }
}
