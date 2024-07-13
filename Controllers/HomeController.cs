using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CV_Central.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CV_Central.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var claims = User.Claims.ToList();
        Console.WriteLine(claims.Count);
        foreach (var item in claims)
        {
            Console.WriteLine(item);
        }
        var email = User.FindFirstValue(ClaimTypes.Email);

        ViewData["Email"] = email;

        var authResult = await HttpContext.AuthenticateAsync();
        //Console.WriteLine(authResult.Succeeded);
        if (authResult.Succeeded){
        //var accessToken = authResult.Properties.GetTokenValue("access_token");
        var pictureUrlClaim = authResult.Principal.FindFirst("urn:google:picture");
        var pictureUrl = pictureUrlClaim?.Value;
        Console.WriteLine(pictureUrl);
        Console.WriteLine("hola");
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
