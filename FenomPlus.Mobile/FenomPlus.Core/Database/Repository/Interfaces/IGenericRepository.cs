using System;

namespace FenomPlus.Core.Database.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        ILiteCollection<T> Collection { get; }
    }
}
