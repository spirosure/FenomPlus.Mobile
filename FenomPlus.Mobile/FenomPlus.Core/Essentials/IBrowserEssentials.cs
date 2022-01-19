using System;
using System.Threading.Tasks;

namespace FenomPlus.Core.Essentials
{
    public interface IBrowserEssentials
    {
        Task OpenAsync(string uri);
        Task OpenAsync(string uri, bool launchMode = false);
        Task OpenAsync(Uri uri);
        Task OpenAsync(Uri uri, bool launchMode = false);
    }
}
