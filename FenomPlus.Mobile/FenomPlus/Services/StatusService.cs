using System;
using FenomPlus.Interfaces;

namespace FenomPlus.Services
{
    public class StatusService : BaseService, IStatusService
    {
        public StatusService(IAppServices services) : base(services)
        {
        }
    }
}
