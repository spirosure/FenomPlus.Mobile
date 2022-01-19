using System;
using System.Threading.Tasks;

namespace FenomPlus.Core.Essentials
{
    public interface ILauncherEssentials
    {
        Task<bool> CanOpenAsync(string uri);
        Task<bool> CanOpenAsync(Uri uri);
        Task OpenAsync(string uri);
        Task OpenAsync(Uri uri);
        Task OpenFileRequestAsync(string uri);
        Task<bool> TryOpenAsync(string uri);
        Task<bool> TryOpenAsync(Uri uri);
    }
}
