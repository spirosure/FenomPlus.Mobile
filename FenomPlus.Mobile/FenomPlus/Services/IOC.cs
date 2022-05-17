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
				if(_Services == null)
                {
					TinyIoCContainer.Current.Register<IAppServices, AppServices>().AsSingleton();
					_Services = TinyIoCContainer.Current.Resolve<IAppServices>();
				}
				return _Services;
			}
		}
	}
}
