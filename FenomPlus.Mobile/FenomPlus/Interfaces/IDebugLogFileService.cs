using System;
using System.Threading.Tasks;

namespace FenomPlus.Interfaces
{
    public interface IDebugLogFileService
    {
        string GetFilePath();
        void Write(DateTime dateTime, string msg);
        void Write(DateTime dateTime, byte[] msg);
    }
}
