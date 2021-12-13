using System;
using System.Collections.Generic;
using System.Text;

namespace FenomPlus.SDK.Core.Utils
{
    public static class PerformanceLogger
    {
        private static Logger _logger = new Logger(nameof(PerformanceLogger));

        private static readonly Dictionary<string, PerformanceLogEntry> logsDictionary = new Dictionary<string, PerformanceLogEntry>();

        public static void CheckShouldThrowThreadException(bool isBackgroundThreadRequired, bool isMainThreadRequired, string key, int thread)
        {
#if DEBUG
            var isAlwaysOnMainThread = logsDictionary[key].IsMainThreadRequired;
            var isNeverOnMainThread = logsDictionary[key].IsBackgroundThreadRequired;

            if (isAlwaysOnMainThread && thread != 1)
                throw new Exception("This method call should be on the main thread!");

            if (isNeverOnMainThread && thread == 1)
                throw new Exception("This method call should never be on the main thread!");
#endif
        }

        public static long EndLog(Type classType, string methodName)
        {
#if DEBUG
            var key = string.Format("{0}.{1}", classType.Name, methodName);
            var thread = Environment.CurrentManagedThreadId;

            var message = $"[PerformanceLog]: Thread #{thread} - {DateTime.Now.ToString("hh:mm:ss.ffff")} - {key}";

            if (!logsDictionary.ContainsKey(key))
            {
                message += " [Missing Start Tag]";
                _logger.LogDebug(message + System.Environment.NewLine);
                //System.Diagnostics.Debug.WriteLine(message + System.Environment.NewLine);
                return 0;
            }

            long ticks = DateTime.Now.Ticks;
            long diff = ticks - logsDictionary[key].Ticks;
            TimeSpan ts = new TimeSpan(diff);

            logsDictionary[key].SumTicks += diff;

            var tsSum = new TimeSpan(logsDictionary[key].SumTicks);
            var tsAvg = new TimeSpan(logsDictionary[key].AvgTicks);

            if (logsDictionary[key].Count > 1)
                message += $": Count {logsDictionary[key].Count} - Sum: {tsSum.ToString(@"ss\.ffff")} - Avg: {tsAvg.ToString(@"ss\.ffff")}";
            else
                message += $": Count {logsDictionary[key].Count} ";

            message += $" - { ts.ToString(@"ss\.ffff") }";

            if (ts.TotalSeconds >= 60)
                message += " - very long running";
            else if (ts.TotalSeconds >= 5)
                message += " - long running";

            _logger.LogDebug(message);
            //System.Diagnostics.Debug.WriteLine(message);

            CheckShouldThrowThreadException(logsDictionary[key].IsBackgroundThreadRequired, logsDictionary[key].IsMainThreadRequired, key, thread);

            return ticks;
#else
            return 0;
#endif
        }

        public static long StartLog(Type classType, string methodName, bool isBackgroundThreadRequired = false, bool isMainThreadRequired = false)
        {
#if DEBUG
            var key = string.Format("{0}.{1}", classType.Name, methodName);

            var thread = Environment.CurrentManagedThreadId;

            long ticks = DateTime.Now.Ticks;
            if (logsDictionary.ContainsKey(key))
            {
                logsDictionary[key].Ticks = ticks;
                logsDictionary[key].Count++;
            }
            else
                logsDictionary[key] = new PerformanceLogEntry { Ticks = ticks, Count = 1, IsBackgroundThreadRequired = isBackgroundThreadRequired, IsMainThreadRequired = isMainThreadRequired };

            var message = $"[PerformanceLog]: Thread #{thread} - {DateTime.Now.ToString("hh:mm:ss.ffff")} - {key}";
            _logger.LogDebug(message);
            //System.Diagnostics.Debug.WriteLine(message);

            CheckShouldThrowThreadException(isBackgroundThreadRequired, isMainThreadRequired, key, thread);

            return ticks;
#else
            return 0;
#endif
        }

        public class PerformanceLogEntry
        {
            public long AvgTicks => Count > 0 ? (long)(SumTicks / Count) : 0;
            public int Count { get; set; } = 0;
            public bool IsBackgroundThreadRequired { get; set; } = false;
            public bool IsMainThreadRequired { get; set; } = false;
            public long SumTicks { get; set; } = 0;
            public long Ticks { get; set; } = 0;
        }
    }
}