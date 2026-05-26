using Microsoft.AspNetCore.Mvc;
using MVC_Fiorella_All.Services.Interfaces;
using MVC_Fiorella_All.ViewModels;
using MVC_Fiorella_All.ViewModels.Account;

namespace MVC_Fiorella_All.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
             _accountService = accountService;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = await _accountService.RegisterAsync(model);
            if(!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View(model);
            }
            return RedirectToAction("Login","Account");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View();
            var result = await _accountService.LoginAsync(model);
            if(!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email or password is wrong");
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
