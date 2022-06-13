using FenomPlus.Interfaces;
using TinyIoC;

namespace FenomPlus.Services
{
	public class BaseService
	{
		protected IAppServices Services;
		
		public BaseService(IAppServices services)
		{
			this.Services = services;
		}

		public BaseService()
		{
			this.Services = IOC.Services;
		}

		public TinyIoCContainer Container
		{
			get { return TinyIoCContainer.Current; }
		}
	}
}
