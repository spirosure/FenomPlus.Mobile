using LiteDB;

namespace FenomPlus.Database.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        ILiteCollection<T> Collection { get; }
    }
}
