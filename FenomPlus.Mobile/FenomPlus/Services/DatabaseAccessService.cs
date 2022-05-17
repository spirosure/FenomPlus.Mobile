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
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbFile);
            Console.WriteLine("DB:" + path);
            return path;
        }
    }
}
