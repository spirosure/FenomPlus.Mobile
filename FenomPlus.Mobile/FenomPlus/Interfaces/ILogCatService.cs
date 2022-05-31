using System;

namespace FenomPlus.Interfaces
{
    public interface ILogCatService
    {
        void Print(string msg);
        void Print(Exception ex);
    }
}
