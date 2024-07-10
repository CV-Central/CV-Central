using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV_Central.Data;
using CV_Central.Models;
using Microsoft.EntityFrameworkCore;
using CV_Central.ViewModels;

namespace CV_Central.App.Services
{
    public class UserRepository
    {
        private readonly CVCentralContext _context;
        public UserRepository(CVCentralContext context)
        {
            _context = context;
        }

        /* SignIn: POST */
        /* Verificar que Password y ConfirmPassword coincidan y que el usuario se haya creado */
        public async Task<bool> CreateUser(User user){
            /* Agregar y guardar los adatos */
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            /* Combrobar si el usuario fue creado */
            return user.Id != 0;
        }


    }
}



