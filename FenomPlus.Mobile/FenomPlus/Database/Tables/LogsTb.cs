using System;
using System.Collections.Generic;

namespace FenomPlus.Database.Tables
{
    public class LogsTb : IEqualityComparer<LogsTb>, IComparable<LogsTb>
    {
        public string Id { get; set; }
        public string Log { get; set; }
        public bool Uploaded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LogsTb()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(LogsTb other)
        {
            return this.Id.CompareTo(other.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(LogsTb x, LogsTb y)
        {
            return x.Id == y.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(LogsTb obj)
        {
            return obj.Id.GetHashCode();
        }

    }
}