using System;
using FenomPlus.Interfaces;

namespace FenomPlus.Services
{
    public class EnvironmentService : BaseService, IEnvironmentService
    {
        public EnvironmentService(IAppServices services) : base(services)
        {
        }
    }
}
