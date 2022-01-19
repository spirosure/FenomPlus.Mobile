using System;
using System.Threading.Tasks;

namespace FenomPlus.Core.Essentials
{
    public interface IPermissionsEssentials
    {
        Task<PermissionStatusEnum> CheckStatusAsync(PermissionsEnum permissionsEnum);
        Task<PermissionStatusEnum> RequestAsync(PermissionsEnum permissionsEnum);
    }
}
