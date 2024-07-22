using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CV_Central.Models;
using CV_Central.App.Services;
using Microsoft.AspNetCore.Authentication;

/* using para el [Authorize] */
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CV_Central.Controllers{
    /* Usamos este atributo para restringir el acceso de este controlador y sus funciones */
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
        var authResult = await HttpContext.AuthenticateAsync();
        
        if (authResult.Succeeded){
            var user = User.Identity as ClaimsIdentity;
            var pictureClaim = user?.FindFirst("urn:google:picture")?.Value;
            ViewBag.PictureUrl = pictureClaim;
        }

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var foundUser = await _userRepository.GetUserById(Convert.ToInt32(userId));
        
        return View(foundUser);
        }

        // [HttpGet]
        // public async Task<IActionResult> EditData(){
        //     /* Obtener el Id del usuario que se guardó en el Claim */
        //     var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     /* Obyener la informacion personal del usuario de la sesion y devolverla para mostrarla */
        //     var foundUser = await _userRepository.GetUserById(Convert.ToInt32(userId));
        //     return View(foundUser);
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
