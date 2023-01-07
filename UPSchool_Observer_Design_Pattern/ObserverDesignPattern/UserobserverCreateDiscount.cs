using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using UPSchool_Observer_Design_Pattern.DAL;

namespace UPSchool_Observer_Design_Pattern.ObserverDesignPattern
{
	public class UserobserverCreateDiscount : IUserObserver
	{
		private readonly IServiceProvider _serviceProvider;

		public UserobserverCreateDiscount(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void CreateUser(AppUser appUser)
		{
			//burada scope ile farklı yöntemle discounta ekleme yaptık istek sadece context üzerinden de yapabilirdik

			var logger = _serviceProvider.GetRequiredService<ILogger<UserobserverCreateDiscount>>();
			var scoped = _serviceProvider.CreateScope();
			var context = scoped.ServiceProvider.GetRequiredService<Context>();
			context.Discounts.Add(new Discount
			{
				Rate = 25,
				UserId = appUser.Id,
			});
			context.SaveChanges();
			logger.LogInformation($"yeni kayıt olan kullanıcınız:{appUser.Name + " " + appUser.Surname} için Yüzde 25 oranında infirim tanımlandı");
		}
	}
}
