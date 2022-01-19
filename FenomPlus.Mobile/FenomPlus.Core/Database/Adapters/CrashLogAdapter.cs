using System;
using FenomPlus.Core.Database.Tables;
using FenomPlus.Core.Models;

namespace FenomPlus.Core.Database.Adapters
{
    public static class CrashLogAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Crashlog Convert(this CrashlogsTb input)
        {
            if (input == null) return null;
            Crashlog crashLog = (new Crashlog()).CopyFrom(input);

            return crashLog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static CrashlogsTb Convert(this Crashlog input)
        {
            if (input == null) return null;
            CrashlogsTb crashLogTb = (new CrashlogsTb()).CopyFrom(input);

            return crashLogTb;
        }
    }
}
