﻿using System;

namespace FenomPlus.Interfaces
{
    public interface IDebugLogFileService
    {
        void Write(string msg);
        void Write(byte[] msg);
    }
}
