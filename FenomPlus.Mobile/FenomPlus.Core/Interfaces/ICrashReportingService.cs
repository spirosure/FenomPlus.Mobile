using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FenomPlus.Core.Interfaces.Ble
{
	public interface ICrashReportingService
	{
		bool Enabled { get; }
		Task Push(Exception ex, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "");
		Task Push(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "");
		Task Push(Crashlog crash, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "");
		Task Push(Crashlog crash);
		Task<List<CrashlogsTb>> GetList();
		Task<string> Print();
		Task<string> PrintHtml();
	}
}
