using System;
using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Adapters
{
    public static class UsersAdapter
    {
        public static UsersModelDBModel Convert(this UsersTb input)
        {
            if (input == null) return null;
            return new UsersModelDBModel()
            {
                Id = input.Id
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static UsersTb Convert(this UsersModelDBModel input)
        {
            if (input == null) return null;
            return new UsersTb()
            {
                Id = input.Id
            };
        }
    }
}
