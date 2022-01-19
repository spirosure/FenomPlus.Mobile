using System;
using FenomPlus.Core.Interfaces;
using FenomPlus.Core.TinyIoC;
using TinyIoC;
using FenomPlus.Core.Essentials;

namespace FenomPlus.Core.Services
{
	public class BaseService
	{
		protected IAppServices Services;

		protected IBrowserEssentials Browser => Services.Essentials.Browser;
		protected ILauncherEssentials Launcher => Services.Essentials.Launcher;
		protected IMainThreadEssentials MainThread => Services.Essentials.MainThread;
		protected INetworkEssentials Network => Services.Essentials.Network;
		protected IPermissionsEssentials Permissions => Services.Essentials.Permissions;
		protected IPreferencesEssentials Preferences => Services.Essentials.Preferences;
		protected ISettingsEssentials Settings => Services.Essentials.Settings;
		
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
