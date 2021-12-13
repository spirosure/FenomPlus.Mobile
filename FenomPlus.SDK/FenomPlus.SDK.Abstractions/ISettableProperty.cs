using System;

namespace FenomPlus.SDK.Abstractions
{
    public interface ISettableProperty<TData> : IProperty<TData>
    {
        void Set(TData value);
    }
}
