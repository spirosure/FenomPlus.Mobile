using System;
using FenomPlus.Interfaces;

namespace FenomPlus.Services
{
    public class DatabaseAccessService : BaseService, IDatabaseAccessService
    {
        public DatabaseAccessService()
        {
        }

        public string DatabasePath(string dbFile)
        {
            throw new NotImplementedException();
        }
    }
}
