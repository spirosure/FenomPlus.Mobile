using System;
using FenomPlus.Interfaces;
using TinyIoC;

namespace FenomPlus.Services
{
	public static class IOC
	{
		private static IAppServices _Services;
		public static IAppServices Services
		{
			get
			{
				return (_Services == null) ? _Services = TinyIoCContainer.Current.Resolve<IAppServices>() : _Services;
			}
		}
	}
}
