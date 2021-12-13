using System;

namespace FenomPlus.SDK.Abstractions
{
    public interface IMonitoredSettableProperty<TData> : ISettableProperty<TData>, IMonitoredProperty<TData>
    {
    }
}
