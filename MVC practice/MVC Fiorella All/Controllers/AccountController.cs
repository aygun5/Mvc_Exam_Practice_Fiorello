using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Fiorella_All.Helpers.Enums;
using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.Services.Interfaces;
using MVC_Fiorella_All.ViewModels;
using MVC_Fiorella_All.ViewModels.Account;

namespace MVC_Fiorella_All.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
       // private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(IAccountService accountService,
                                 RoleManager<IdentityRole> roleManager)
        {
             _accountService = accountService;
       //      _roleManager = roleManager;
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

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }


        //[HttpGet]
        //public async Task<IActionResult> CreateRole()
        //{
        //    foreach(var role in Enum.GetValues(typeof(Role)))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
        //    }
        //    return Ok();


        //admin=Aygun1           parol=Salam123_
        //member1=Zehra1         parol=Zehra123_
        //member2=Aytac1         parol=Aytac123_
        //member3=Bahruz1        parol=Bahruz123_
        //member4=Isi1           parol=Ismayil123_
        //member5=Samire1        parol=Samire123_
    }
}
