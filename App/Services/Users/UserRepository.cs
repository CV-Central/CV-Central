using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV_Central.Context;
using CV_Central.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_Central.App.Services.Users
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
        public async Task<bool> CreateUser(User userRegister){
            /* Agregar y guardar los adatos */
            await _context.Users.AddAsync(userRegister);
            await _context.SaveChangesAsync();

            /* Combrobar si el usuario fue creado */
            return userRegister.Id != 0;
        }


    }
}



