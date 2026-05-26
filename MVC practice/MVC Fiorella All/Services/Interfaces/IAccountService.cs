using Microsoft.AspNetCore.Identity;
using MVC_Fiorella_All.ViewModels;
using MVC_Fiorella_All.ViewModels.Account;

namespace MVC_Fiorella_All.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(RegisterVM model);
        Task<SignInResult> LoginAsync(LoginVM model);
    }
}
