using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UPSchool_Observer_Design_Pattern.DAL;
using UPSchool_Observer_Design_Pattern.Models;
using UPSchool_Observer_Design_Pattern.ObserverDesignPattern;

namespace UPSchool_Observer_Design_Pattern.Controllers
{
	public class DefaultController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly UserObserverSubject _userObserverSubject;
		public DefaultController(UserManager<AppUser> userManager, UserObserverSubject userObserverSubject)
		{
			_userManager = userManager;
			_userObserverSubject = userObserverSubject;
		}

		public IActionResult Index()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserVM userVM)
		{
			var appUser = new AppUser()
			{
				UserName = userVM.Username,
				Name = userVM.Name,
				Surname = userVM.Surname,
				Email=userVM.Mail,
			
			};

			var result = await _userManager.CreateAsync(appUser, userVM.Password);
			if (result.Succeeded)
			{
				_userObserverSubject.NotifyObserver(appUser);
				ViewBag.message = "Üyelik sistemi başarılşı bir şekilde oluşturulkdu";
			}
			else 
			{
				ViewBag.message = "Üyelik kaydında bir hata oluştu";

			}
			return View();
		}
	}
}
