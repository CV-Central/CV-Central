using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV_Central.Context;
using CV_Central.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_Central.App.Services
{
    public class UserRepository
    {
        private readonly CVCentralContext _context;
        public UserRepository(CVCentralContext context)
        {
            _context = context;
        }

        /* SignUp: POST */
        /* Comprobar que el usuario se haya creado en la base ddatos */
        public async Task<bool> CreateUser(User userRegister){
            /* Agregar y guardar los datos */
            await _context.Users.AddAsync(userRegister);
            await _context.SaveChangesAsync();

            /* Combrobar si el usuario fue creado */
            return userRegister.Id != 0;
        }
        
        /* SignUp: POST */
        /* Verificar la existencia del usuario */
        public async Task<User> GetUserByEmail(string email){
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }



    }
}



