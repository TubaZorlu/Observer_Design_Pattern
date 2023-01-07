using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using UPSchool_Observer_Design_Pattern.DAL;

namespace UPSchool_Observer_Design_Pattern.ObserverDesignPattern
{
	public class UserObserverWritetoConsole : IUserObserver
	{
		private readonly IServiceProvider _serviceProvider;

		public UserObserverWritetoConsole(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void CreateUser(AppUser appUser)
		{
			var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverWritetoConsole>>();
			logger.LogInformation($"{appUser.Name + " " + appUser.Surname} kullanıcı sisteme kayıt oldu");
		}
	}
}
