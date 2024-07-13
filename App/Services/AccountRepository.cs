using CV_Central.Models;
using CV_Central.Context;
using Microsoft.EntityFrameworkCore;

namespace CV_Central.App.Services
{
    public class AccountRepository
    {
        private readonly CVCentralContext _context;
        public AccountRepository(CVCentralContext context)
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

        /* LogIn: POST */
        /* Encontrar al usuario que inicia sesion */
        public async Task<User> GetUser(User user){
            return await _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefaultAsync();
        }
    }
}