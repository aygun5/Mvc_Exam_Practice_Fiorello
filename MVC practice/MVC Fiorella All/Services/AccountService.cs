using Microsoft.AspNetCore.Identity;
using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.Services.Interfaces;
using MVC_Fiorella_All.ViewModels;
using MVC_Fiorella_All.ViewModels.Account;

namespace MVC_Fiorella_All.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
             _signInManager=signInManager;
             _userManager=userManager;
        }
        public async Task<SignInResult> LoginAsync(LoginVM model)
        {
            var user = await _userManager.FindByNameAsync(model.EmailOrUserName) ?? 
                       await _userManager.FindByEmailAsync(model.EmailOrUserName);
            if(user == null) return SignInResult.Failed;

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            return result;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterVM model)
        {
            var user = new AppUser
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }
    }
}
