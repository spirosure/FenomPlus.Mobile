using System;

namespace FenomPlus.Core.Interfaces
{
    public interface IDatabaseService
    {
        ILiteDatabase DB { get; }
        ICrashlogsRepository CrashLogRepo { get; }
    }
}
