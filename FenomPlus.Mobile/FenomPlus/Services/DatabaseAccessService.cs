using System;
using System.IO;
using FenomPlus.Interfaces;

namespace FenomPlus.Services
{
    public class DatabaseAccessService : BaseService, IDatabaseAccessService
    {
        public DatabaseAccessService(IAppServices services) : base(services)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbFile"></param>
        /// <returns></returns>
        public string DatabasePath(string dbFile)
        {
            string libPath = "./";

            string path = Path.Combine(libPath, dbFile);
            Console.WriteLine("DB:" + path);
            return path;
        }
    }
}
