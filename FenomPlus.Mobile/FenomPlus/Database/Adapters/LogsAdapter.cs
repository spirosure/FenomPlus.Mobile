using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Adapters
{
    public static class LogsAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static LogDBModel Convert(this LogsTb input)
        {
            if (input == null) return null;
            return new LogDBModel()
            {
                Id = input.Id,
                Log = input.Log,
                Uploaded = input.Uploaded
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static LogsTb Convert(this LogDBModel input)
        {
            if (input == null) return null;
            return new LogsTb()
            {
                Id = input.Id,
                Log = input.Log,
                Uploaded = input.Uploaded
            };
        }
    }
}
