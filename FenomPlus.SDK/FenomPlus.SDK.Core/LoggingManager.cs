using System;
using Microsoft.Extensions.Logging;

namespace FenomPlus.SDK.Core
{
    public class LoggingManager
    {
        private static LoggingManager m_Instance = null;
        private static readonly Object m_Lock = new Object();

        private ILoggerFactory m_LoggerFactory = null;

        private LoggingManager()
        {

        }

        public static LoggingManager GetInstance
        {
            get
            {
                lock (m_Lock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new LoggingManager();
                    }
                }
                return m_Instance;
            }
        }

        public void SetLoggingFactory(ILoggerFactory LoggerFactory)
        {
            m_LoggerFactory = LoggerFactory;
        }

        public ILoggerFactory Factory
        {
            get
            {
                return m_LoggerFactory;
            }
        }
    }
}
