using CV_Central.Data;
using CV_Central.Models;
using Microsoft.EntityFrameworkCore;
using CV_Central.ViewModels;

namespace CV_Central.Controllers{
    public class UserAccessController : Controller{
        private readonly UserRepository _userRepository;

        public UserAccessController(UserRepository userRepository){
            _userRepository = userRepository;
        }

        /* Función para el login "GET" */
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        /* Función para el login "POST" */
        [HttpPost]
        public async Task<IActionResult> SignIn(UserVM userVM){
            /* Confirmar contraseña */
            if (userVM.Password != userVM.ConfirmPassword)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            /* Formar un nuevo usuario con los daros entrantes */
            var user = new User()
            {
                Name = userVM.Name,
                Age = userVM.Age,
                Email = userVM.Email,
                Password = userVM.Password,
                Phone = userVM.Phone,
                Address = userVM.Address,
                Image = userVM.Image,
                CreateAt = DateTime.Now,
                UpdateAt = DataType.Now,
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