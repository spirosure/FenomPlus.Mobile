using System;

namespace FenomPlus.SDK.Abstractions
{
    public delegate void ValueChangedDelegate<TData>(TData value);

    public interface IMonitoredProperty<TData> : IProperty<TData>
    {
        event ValueChangedDelegate<TData> ValueChangedEvent;
    }
}
