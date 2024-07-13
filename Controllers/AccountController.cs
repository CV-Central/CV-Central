using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Index(){
        return View();
    }

    [HttpGet("~/signin")]
    public async Task<IActionResult> SignInAsync()
    {
        var authenticationProperties = new AuthenticationProperties { RedirectUri = "/" };
        var authResult = await HttpContext.AuthenticateAsync();

        if (authResult?.Succeeded != true)
        {
            return Challenge(authenticationProperties, CookieAuthenticationDefaults.AuthenticationScheme);
        }
        return Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme);

    }

    [HttpGet("~/signout")]
    public IActionResult SignOut()
    {
        return SignOut(new AuthenticationProperties { RedirectUri = "/" }, CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
