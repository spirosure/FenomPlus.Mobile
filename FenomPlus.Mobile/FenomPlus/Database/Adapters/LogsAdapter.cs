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
        public static Log Convert(this LogsTb input)
        {
            if (input == null) return null;
            return new Log()
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
        public static LogsTb Convert(this Log input)
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
