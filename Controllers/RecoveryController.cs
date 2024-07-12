using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV_Central.App.Services;
using CV_Central.Context;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;

namespace CV_Central.Controllers.Recuperacion
{
    public class PasswordRecovery : Controller {
       public readonly CVCentralContext _context;
       private readonly EmailRepository _emailrepository;


       public PasswordRecovery(CVCentralContext context, EmailRepository emailRepository){
        _context = context;
        _emailrepository = emailRepository;
       }

       public IActionResult Index(){
        return View();
       }
       public void Recovery(string email) {
        var user = _context.Users.FirstOrDefault(e => e.Email == email);
        if(user != null){

                var subject = "recuperacion de contraseña";
                var mensajeUser = $"Hola, {user.Name},\nEsta es tu contraseña: {user.Password}.";
                _emailrepository.SendEmail( user.Email, mensajeUser, subject, user);
                Console.WriteLine("hols" + email);
        }
       }
    }
    
}