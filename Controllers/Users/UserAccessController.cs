using CV_Central.Context;
using CV_Central.Models;
using CV_Central.App.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CV_Central.Controllers{
    public class UserAccessController : Controller{
        private readonly UserRepository _userRepository;

        public UserAccessController(UserRepository userRepository){
            _userRepository = userRepository;
        }

        //UserRepository obj = new UserRepository();

        /* Función para el login "GET" */
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        /* Función para el login "POST" */
        [HttpPost]
        public async Task<IActionResult> SignIn(User userRegister){
            /* Confirmar contraseña */
            /* if (userRegister.Email == userRegister.ConfirmPassword)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            } */

            /* Formar un nuevo usuario con los daros entrantes */
            var user = new User()
            {
                Name = userRegister.Name,
                Age = userRegister.Age,
                Email = userRegister.Email,
                Password = userRegister.Password,
                Phone = userRegister.Phone,
                Address = userRegister.Address,
                Image = userRegister.Image,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            };

           /* Llamar a la funcion del services */
            var userCreated = await _userRepository.CreateUser(user);

            /* Si el usuario se creo redireccionar al Login */
            if(userCreated){
                return RedirectToAction("Login", "Acceso");
            }

            /* Si no se creo mandar el mensaje */
            ViewData["Mensaje"] = "¡Error!, No se creó el usuario";
            return View();
        }
    
    }
}