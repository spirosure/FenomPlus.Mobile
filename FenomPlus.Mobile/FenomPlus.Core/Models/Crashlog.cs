using System;
using System.Runtime.CompilerServices;
using FenomPlus.Core.Database.Tables;
using FenomPlus.Core.TinyIoC;

namespace FenomPlus.Core.Models
{
	public class Crashlog : CrashlogsTb
	{
		/// <summary>
		/// Crash the specified className, methodName and message.
		/// </summary>
		/// <returns>The crash.</returns>
		/// <param name="className">Class name.</param>
		/// <param name="methodName">Method name.</param>
		/// <param name="message">Message.</param>
		public Crashlog(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "")
		{
			Create(message, callerFilePath, callerLineNumber, callerMemberName);

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FirmwareUpdate.Models.Crash"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		public Crashlog(Exception ex, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "")
		{
			Create(ex.ToString(), callerFilePath, callerLineNumber, callerMemberName);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FirmwareUpdate.Models.Crash"/> class.
		/// </summary>
		public Crashlog([CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "")
		{
			Create("", callerFilePath, callerLineNumber, callerMemberName);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="className"></param>
		/// <param name="methodName"></param>
		/// <param name="message"></param>
		/// <param name="callerFilePath"></param>
		/// <param name="callerLineNumber"></param>
		/// <param name="callerMemberName"></param>
		public void Create(string message = "", string callerFilePath = "", int callerLineNumber = 0, string callerMemberName = "")
		{
			Uploaded = false;
			Message = message;
			CrashDate = DateTime.UtcNow;
			CallerMemberName = callerMemberName;
			CallerLineNumber = callerLineNumber;
			CallerFilePath = callerFilePath;
			Username = IOC.Services.Status.Username;
			DeviceInfo = IOC.Services.DeviceInfo;
			Environment = IOC.Services.Environment;
		}

		/// <summary>
		/// Print this instance.
		/// </summary>
		/// <returns>The print.</returns>
		public string Print()
		{
			return string.Format("<b>[{0} {2} {3} {4}]</b> {1}", CrashDate, Message, CallerFilePath, CallerLineNumber, CallerMemberName);
		}

		/// <summary>
		/// Prints the html.
		/// </summary>
		/// <returns>The html.</returns>
		public string PrintHtml()
		{
			return string.Format("<b>[{0} {2} {3} {4}]</b><br/> {1}<br/>", CrashDate, Message.Replace(" ", "&nbsp;").Replace("\n", "</br>"), CallerFilePath, CallerLineNumber, CallerMemberName);
		}
	}
}