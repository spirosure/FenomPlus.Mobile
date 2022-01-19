using System;
using System.Collections.Generic;

namespace FenomPlus.Core.Database.Tables
{
    public class CrashlogsTb : IEqualityComparer<CrashlogsTb>, IComparable<CrashlogsTb>
    {
        public string Id { get; set; }

        public string Message { get; set; }
        public bool Uploaded { get; set; }
        public string CallerFilePath { get; set; }
        public int CallerLineNumber { get; set; }
        public string CallerMemberName { get; set; }
        public IDeviceInfoService DeviceInfo { get; set; }
        public IEnvironmentService Environment { get; set; }
        public DateTime CrashDate { get; set; }
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CrashlogsTb()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(CrashlogsTb other)
        {
            return this.Id.CompareTo(other.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(CrashlogsTb x, CrashlogsTb y)
        {
            return x.Id == y.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(CrashlogsTb obj)
        {
            return obj.Id.GetHashCode();
        }

    }
}