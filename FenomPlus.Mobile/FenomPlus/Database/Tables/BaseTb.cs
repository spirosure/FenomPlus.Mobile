using System;
using System.Collections.Generic;
using LiteDB;

namespace FenomPlus.Database.Tables
{
    public class BaseTb<T>// : IEqualityComparer<T>, IComparable<T> where T : BaseTb<T> , new()
    {
        public BsonValue _id { get; set; }
        /*
        private string Id { get; set; }

        public BaseTb()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        // <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(T other)
        {
            return this.Id.CompareTo(other.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(T x, T y)
        {
            return x.Id == y.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(T obj)
        {
            return obj.Id.GetHashCode();
        }
        */
    }
}
