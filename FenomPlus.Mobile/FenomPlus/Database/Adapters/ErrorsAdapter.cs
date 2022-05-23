using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Adapters
{
    public static class ErrorsAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ErrorDBModel Convert(this ErrorsTb input)
        {
            if (input == null) return null;
            return new ErrorDBModel()
            {
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ErrorsTb Convert(this ErrorDBModel input)
        {
            if (input == null) return null;
            return new ErrorsTb()
            {
            };
        }
    }
}
