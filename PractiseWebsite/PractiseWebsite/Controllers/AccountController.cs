using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PractiseWebsite.Models;
using System.Security.Claims;

namespace PractiseWebsite.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult CreateAccount()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAccount(LoginDto loginDto)
		{
			var account = "Kenny@gmali.com";
			var password = "123456";

			if(loginDto.Account == account && loginDto.Password == password)
			{
				// 製作聲明
				var claimList = new List<Claim>
				{
					new Claim(ClaimTypes.Name, "Kenny"),
					new Claim(ClaimTypes.Role, "User")
				};

				// 製作一個物件放入聲明
				var identity =  new ClaimsIdentity(claimList, CookieAuthenticationDefaults.AuthenticationScheme);
                
                // 原則
                var principal = new ClaimsPrincipal(identity);

				// 設定登入時效等等
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
				{
					ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
				});

				return RedirectToAction("Index", "Home");
			}
			
			return View();
		}

		public IActionResult NotAllow()
		{
			return View();
		}
	}
}