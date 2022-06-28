using System;
using System.Threading.Tasks;

namespace FenomPlus.Interfaces
{
    public interface IDebugLogFileService
    {
        string GetFilePath();
        void Write(string msg);
        void Write(byte[] msg);
    }
}
