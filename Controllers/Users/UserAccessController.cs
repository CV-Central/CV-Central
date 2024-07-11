using CV_Central.Context;
using CV_Central.Models;
using CV_Central.App.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CV_Central.Controllers{
    public class UserAccessController : Controller{
        private readonly UserRepository _userRepository;

        public UserAccessController(UserRepository userRepository){
            _userRepository = userRepository;
        }

        /* Función para el registro "GET" */
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        /* Función para el registro "POST" */
        [HttpPost]
        public async Task<IActionResult> SignUp(User userRegister)
        {
            // Verificar si ya existe un usuario con el mismo correo electrónico
            var foundUser = await _userRepository.GetUserByEmail(userRegister.Email);

            if (foundUser != null)
            {
                // Si el usuario ya existe, enviar un mensaje de error
                ViewData["Mensaje"] = "El correo electrónico ya está registrado.";
                return View();
            }

            // Formar un nuevo usuario con los datos entrantes
            var user = new User()
            {
                Name = userRegister.Name,
                Age = userRegister.Age,
                Email = userRegister.Email,
                Password = userRegister.Password,
                Phone = userRegister.Phone,
                Address = userRegister.Address,
                Image = null,
                Status = "ACTIVE",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            };

            // Llamar a la función del servicio para crear el usuario
            var userCreated = await _userRepository.CreateUser(user);

            // Si el usuario se creó, redireccionar al Login
            if (userCreated)
            {
                return RedirectToAction("Login", "Acceso");
            }

            // Si no se creó, enviar un mensaje de error
            ViewData["Mensaje"] = "¡Error!, No se creó el usuario";
            return View();
        }
    
    }
} 