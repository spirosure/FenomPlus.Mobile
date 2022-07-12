using System.Collections.Generic;
using LiteDB;

namespace FenomPlus.Database.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        //ILiteCollection<T> Collection { get; }
        //void Delete(T model);
        //void DeleteAll();
        //T FindById(BsonValue id);
        //T Insert(T model);
        //IEnumerable<T> SelectAll();
    }
}
