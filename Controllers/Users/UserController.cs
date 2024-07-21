using CV_Central.Context;
using CV_Central.Models;
using CV_Central.App.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using CV_Central.DTOs;

namespace CV_Central.Controllers{
    public class UserController : Controller{
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository, EmailRepository emailRepository){
            _userRepository = userRepository;
        }

        /* Obtener informacion personal */
        [HttpGet]
        public async Task<IActionResult> EditData(){
            /* Obtener el Id del usuario que se guardó en el Claim */
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            /* Obyener la informacion personal del usuario de la sesion y devolverla para mostrarla */
            var foundUser = await _userRepository.GetUserById(Convert.ToInt32(userId));
            return View(foundUser);
        }

        /* Actualizar información personal del usuario */
        [HttpPost]
        public async Task<IActionResult> EditData(userUpdateDTO userDTO){
            /* Obtener el Id del usuario que se guardó en el Claim */
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            /* Pasar el Id del usuario y los datos editados del formulario */
            await _userRepository.UserDataU(Convert.ToInt32(userId), userDTO);
            return RedirectToAction("Index", "Home");

        }
    }
}