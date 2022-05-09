using System;
using FenomPlus.Database.Repository.Interfaces;
using LiteDB;

namespace FenomPlus.Interfaces
{
    public interface IDatabaseService
    {
        ILiteDatabase DB { get; }
        IBreathManeuverRepository BreathManeuverRepo { get; }
        IDevicesRepository DevicesRepo { get; }
        ILogsRepository LogsRepo { get; }
        IQualityControlRepository QualityControlRepo { get; }
        IUsersRepository UsersRepo { get; } 
    }
}
