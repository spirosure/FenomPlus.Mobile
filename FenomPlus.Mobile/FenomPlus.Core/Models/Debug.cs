using System;

namespace FenomPlus.Core.Models
{
	public class Debug
	{
		public string ClassName;
		public string MethodName;
		public string Message;
		public DateTime DebugDate;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FirmwareUpdate.Services.DebugConsole.Debug"/> class.
		/// </summary>
		/// <param name="className">Class name.</param>
		/// <param name="methodName">Method name.</param>
		/// <param name="message">Message.</param>
		public Debug(string className, string methodName, string message)
		{
			Message = message;
			ClassName = className;
			MethodName = methodName;
			DebugDate = DateTime.UtcNow;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FirmwareUpdate.Services.DebugConsole.Debug"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		public Debug(string message)
		{
			Message = message;
			ClassName = "";
			MethodName = "";
			DebugDate = DateTime.UtcNow;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FirmwareUpdate.DebugConsole.Debug"/> class.
		/// </summary>

		public Debug()
		{
			DebugDate = DateTime.UtcNow;
		}

		/// <summary>
		/// Print this instance.
		/// </summary>
		/// <returns>The print.</returns>
		public string Print()
		{
			return string.Format("[{0} {1} {2}] {3}", DebugDate, ClassName, MethodName, Message);
		}

		/// <summary>
		/// Prints the html.
		/// </summary>
		/// <returns>The html.</returns>
		public string PrintHtml()
		{
			return string.Format("<tr><td><b>{0}</b></td><td><b>{1}</b></td><td><b>{2}</b></td><td>{3}</tr>",
								 DebugDate.ToLongTimeString().Replace(" ", "&nbsp;"),
								 ClassName,
								 MethodName,
								 Message.Replace(" ", "&nbsp;").Replace("\n", "</br>")
								);
		}
	}
}