using System.Security.Claims;
using CV_Central.App.Services;
using CV_Central.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly AccountRepository _accountRepository;

    public AccountController(AccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

   public IActionResult Index(){
        return View();
    }

    [HttpGet("~/signin")]
    public async Task<IActionResult> SignInAsync()
    {
        var authenticationProperties = new AuthenticationProperties { RedirectUri = "/UserAccess/LogIn" };
        var user = User.Identity as ClaimsIdentity;
        var providerKey = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        bool exists = await _accountRepository.Getprovider(providerKey);
            Console.WriteLine("la accion fue nula " + exists);
        if (!exists)
        {
            var googleUser = new User();
            googleUser.Name = user.FindFirst(ClaimTypes.Name)?.Value;
            googleUser.Email = user.FindFirst(ClaimTypes.Email)?.Value;
            googleUser.Image = user?.FindFirst("urn:google:picture")?.Value;
            googleUser.Status = "ACTIVE";
            googleUser.CreateAt = DateTime.Now;

            var id = _accountRepository.CreateUser(googleUser);
            var provaider = new ExternalAuthentication();
            provaider.ProviderKey = providerKey;
            provaider.Provider = "Google";
            provaider.UserId = id;
            provaider.CreateAt = DateTime.Now;
            _accountRepository.createProvider(provaider);

        }
        return Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("~/signout")]
    public IActionResult SignOut()
    {
        return SignOut(new AuthenticationProperties { RedirectUri = "/UserAccess/LogIn" }, CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
