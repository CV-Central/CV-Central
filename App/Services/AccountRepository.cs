using CV_Central.Models;
using CV_Central.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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
        public int CreateUser(User userRegister){
            /* Agregar y guardar los datos */
             _context.Users.Add(userRegister);
             _context.SaveChanges();

            /* Combrobar si el usuario fue creado */
            return userRegister.Id;
        }

        public void createProvider(ExternalAuthentication registro){
             _context.ExternalAuthentications.Add(registro);
             _context.SaveChanges();
        }
        
        /* SignUp: POST */
        /* Verificar la existencia del usuario */
        public async Task<bool> Getprovider(string ProviderKey){
             bool exists = await _context.ExternalAuthentications.AnyAsync(u => u.ProviderKey == ProviderKey);
            return exists;
        }


        /* LogIn: POST */
        /* Encontrar al usuario que inicia sesion */
        public async Task<User> GetUser(User user){
            return await _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefaultAsync();
        }
    }
}