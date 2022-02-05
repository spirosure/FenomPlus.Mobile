using System;
using FenomPlus.Database.Repository.Interfaces;
using LiteDB;

namespace FenomPlus.Interfaces
{
    public interface IDatabaseService
    {
        ILiteDatabase DB { get; }
        ILogsRepository LogsRepo { get; }
    }
}
