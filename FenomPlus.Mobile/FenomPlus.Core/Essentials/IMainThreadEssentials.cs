using System;
using System.Threading;
using System.Threading.Tasks;

namespace FenomPlus.Core.Essentials
{
    public interface IMainThreadEssentials
    {
        bool IsMainThread { get; }
        void BeginInvokeOnMainThread(Action action);
        Task<SynchronizationContext> GetMainThreadSynchronizationContextAsync();
        Task InvokeOnMainThreadAsync(Action action);
        Task<T> InvokeOnMainThreadAsync<T>(Func<T> func);
        Task InvokeOnMainThreadAsync(Func<Task> funcTask);
        Task<T> InvokeOnMainThreadAsync<T>(Func<Task<T>> funcTask);
    }
}
