using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using UPSchool_Observer_Design_Pattern.DAL;

namespace UPSchool_Observer_Design_Pattern.ObserverDesignPattern
{
	public class UserObserverSendMail : IUserObserver
	{
		private readonly IServiceProvider _serviceProvider;

		public UserObserverSendMail(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void CreateUser(AppUser appUser)
		{

			var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendMail>>();

			MimeMessage mimeMessage = new MimeMessage();

			//Gönderen mail adresi
			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin Observer", "tubatastan24@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			//alıcı mail adresi
			MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
			mimeMessage.To.Add(mailboxAddressTo);

			//Mesajın içeriği
			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = "Observer Design Pattern Dersimiz , Kodunuz:GIFT0001";
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			//mesajın konusu
			mimeMessage.Subject = "Hoş Geldin Indirim Hediyesi";

			//mailin gönderilmesi için protokol 
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("tubatastan24@gmail.com", "difpgpzybdkytrlrn");
			client.Send(mimeMessage);
			client.Disconnect(true);

			logger.LogInformation($"{appUser.Name + " " + appUser.Surname} isimli kullanıcınının {appUser.Email} adlı mail başarı ile gönderildi");
			
		}
	}
}
