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
        public static Error Convert(this ErrorsTb input)
        {
            if (input == null) return null;
            return new Error()
            {
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ErrorsTb Convert(this Error input)
        {
            if (input == null) return null;
            return new ErrorsTb()
            {
            };
        }
    }
}
