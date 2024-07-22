using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV_Central.Context;
using CV_Central.Models;
using Microsoft.EntityFrameworkCore;
using CV_Central.DTOs;

namespace CV_Central.App.Services
{
    public class UserRepository
    {
        private readonly CVCentralContext _context;
        public UserRepository(CVCentralContext context)
        {
            _context = context;
        }

        /* Get All Users */
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
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

        /* Edit  */
        /* Encontrar el usuario por Id */
        public async Task<User> GetUserById(int id){
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        /* Edit: PUT */
        /* Actualizar los datos personales del usuario */
        public async Task UserDataU(int id, userUpdateDTO userDTO){
            var foundUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            foundUser.Name = userDTO.Name;
            foundUser.Age = userDTO.Age;
            foundUser.Password = userDTO.Password;
            foundUser.Phone = userDTO.Phone;
            foundUser.Address = userDTO.Address;

            if(string.IsNullOrEmpty(userDTO.Image)){
                foundUser.Image = "https://static.vecteezy.com/system/resources/previews/005/544/718/non_2x/profile-icon-design-free-vector.jpg";
            }
            foundUser.Image = userDTO.Image;
            foundUser.UpdateAt = DateTime.Now;
            
            _context.Users.Update(foundUser);
            await _context.SaveChangesAsync();
        }



    }
}



