using System;
using System.Collections.Generic;
using System.Text;

namespace FenomPlus.SDK.Core.Utils
{
    internal static class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// return if string is not empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
