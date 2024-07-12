using CV_Central.Context;
using CV_Central.Models;
using CV_Central.App.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
             /* Si el usuario todavia esta autenticado y no ha cerrado sesion, al abrir la página volvera a la página principal */
            if(User.Identity!.IsAuthenticated){
                return RedirectToAction("Index", "Home");
            }
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
                Status = "ACTIVE",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            };

            // Llamar a la función del servicio para crear el usuario
            var userCreated = await _userRepository.CreateUser(user);

            // Si el usuario se creó, redireccionar al Login
            if (userCreated)
            {
                return RedirectToAction("Login", "UserAccess");
            }

            // Si no se creó, enviar un mensaje de error
            ViewData["Mensaje"] = "¡Error!, No se creó el usuario";
            return View();
        }

        /* Función para Iniciar sesion "GET" */
        [HttpGet]
        public IActionResult LogIn()
        {
            /* Si el usuario todavia esta autenticado y no ha cerrado sesion, al abrir la página volvera a la página principal */
            if(User.Identity!.IsAuthenticated){
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /* Función para Iniciar sesion "POST" */
        [HttpPost]
        public async Task<IActionResult> LogIn(User userLogIn){
            /* Encontrar al usuario con los datos ingresados con la funcion de Services */
            var foundUser = await _userRepository.GetUser(userLogIn);
            if(foundUser == null){
                ViewData["ErrorMessage"] = "¡Los datos no coinciden con los de algún usuario!";
                return View();
            }

            /* Claim: Es una declaracion acerca de un sujeto. Es una pieza de información acerca del usuario */
            /* Crear un Claim y guardar el nombre del usuario que inicio sesion */
            List<Claim>claims = new List<Claim>(){
                /* Identificador estándar que indica que claim contiene el nombre del usuario */
                new Claim(ClaimTypes.Name, foundUser.Name)
            };

            /* ClaimsIdentity: Es una colección de Claims que describen la identidad del usuario */
            /* Crear un nuevo ClaimsIdentity en el que a traves de "claims" le pasaremos los datos que guardamos anteriormente(Name) */
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties(){
                /* Refercar la sesion del usuario */
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                /* Utilizar el esquema de autenticaion por Cookie */
                CookieAuthenticationDefaults.AuthenticationScheme,
                /* Pasarle el ClaimsIdentity que creamos anteriormente */
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index", "Home");
        }

        /* Función para SALIR y cerrar sesion */
        public async Task<IActionResult> LogOut(){
            /* SignOutAsync: Eliminar Cookies de autenticación */
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogIn", "UserAccess");
        }

    
    }
} 