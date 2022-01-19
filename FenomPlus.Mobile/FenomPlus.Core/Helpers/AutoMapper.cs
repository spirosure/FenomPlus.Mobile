using System;
using System.Linq;
using System.Reflection;
using FenomPlus.Core.TinyIoC;

namespace FenomPlus.Core.Helpers
{
    public static class AutoMapper
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="srcObject"></param>
        /// <param name="destObject"></param>
        /// <returns></returns>
        public static TDest CopyPropertyValuesNotNulls<TDest>(object srcObject, TDest destObject)
        {
            return CopyPropertyValues<TDest>(srcObject, destObject, false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="srcObject"></param>
        /// <param name="destObject"></param>
        /// <param name="copyIfNull"></param>
        /// <returns></returns>
        public static TDest CopyPropertyValues<TDest>(object srcObject, TDest destObject, bool copyIfNull = true)
        {
            if ((srcObject != null) && ((object)destObject != null))
            {
                var srcValuesMap = srcObject.GetType().GetTypeInfo().DeclaredProperties.ToDictionary(i => i.Name, i => i.GetValue(srcObject));
                foreach (var property in destObject.GetType().GetTypeInfo().DeclaredProperties)
                {
                    try
                    {
                        object srcValue = null;
                        if (property.SetMethod == null) continue;
                        if (srcValuesMap.TryGetValue(property.Name, out srcValue) == false) continue;
                        if (srcValue.IsPrimitive() == false) continue;
                        if ((copyIfNull == false) && (srcValue == null)) continue;
                        property.SetValue(destObject, srcValue);
                    }
                    catch (Exception ex)
                    {
                        IOC.Services.CrashReporting.Push(ex);
                    }
                }
            }
            return destObject;
        }
    }
}