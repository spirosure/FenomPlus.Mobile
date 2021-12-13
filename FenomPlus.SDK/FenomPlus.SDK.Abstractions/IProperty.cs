using System;
using System.Threading.Tasks;

namespace FenomPlus.SDK.Abstractions
{
    public interface IProperty<TData>
    {
        Task<TData> Get();
    }
}
