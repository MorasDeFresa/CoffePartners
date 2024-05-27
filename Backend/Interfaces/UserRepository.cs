using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public class UserShow
    {
        public required string EmailUser { get; set; }
        public required string NickNameFarmer { get; set; }
        public required int CountArchivements { get; set; }
    }

    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int IdUser);
        Task<User> CreateUser(User User);
        string EscryptPassword(string PasswordUser);
        string DecryptPassword(string PasswordUser);
        Task<int[]> LoginUser(string EmailUser, string PasswordUser);
        Task<User> UpdateUser(User User);
        Task<bool> DeleteUser(int IdUser);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _db;

        public UserRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<User> CreateUser(User User)
        {
            var decryptPasswordUser = EscryptPassword(User.PasswordUser);
            User.PasswordUser = decryptPasswordUser;
            await _db.Users.AddAsync(User);
            _db.SaveChanges();
            return User;
        }

        public string DecryptPassword(string PasswordUser)
        {
            if (string.IsNullOrEmpty(PasswordUser)) return null;
            else
            {
                Console.WriteLine(PasswordUser);
                byte[] encryptedPassword = Convert.FromBase64String(PasswordUser);
                string decryptPassword = Encoding.ASCII.GetString(encryptedPassword);
                return decryptPassword;
            }
        }

        public async Task<bool> DeleteUser(int IdUser)
        {
            var UserAtDelete = await GetUser(IdUser);
            _db.Users.Remove(UserAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public string EscryptPassword(string PasswordUser)
        {
            if (string.IsNullOrEmpty(PasswordUser)) return null;
            else
            {
                byte[] storePassword = Encoding.ASCII.GetBytes(PasswordUser);
                string encryptedPassword = Convert.ToBase64String(storePassword);
                return encryptedPassword;
            }
        }

        public async Task<User> GetUser(int IdUser)
        {
            return await _db.Users.FirstOrDefaultAsync(cu => cu.IdUser == IdUser);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<int[]> LoginUser(string EmailUser, string PasswordUser)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.EmailUser == EmailUser);
            if (user == null) throw new Exception("Usuario no encontrado");
            var decryptPasswordUser = DecryptPassword(user.PasswordUser);
            if (decryptPasswordUser != PasswordUser) throw new Exception("Contraseña incorrecta");
            var Farmer = await _db.Farmers.FirstOrDefaultAsync(u => u.IdUser == user.IdUser);
            var admin = await _db.Admins.FirstOrDefaultAsync(u => u.IdUser == user.IdUser);
            var loginUser = new int[2];

            if (admin != null)
            {
                loginUser[0] = 1;
                loginUser[1] = admin.IdAdmin;
            }
            else if (Farmer != null)
            {
                loginUser[0] = 0;
                loginUser[1] = Farmer.IdFarmer;
            }
            else if (admin == null && Farmer == null) throw new Exception("Usuario no encontrado");
            return loginUser;
        }



        public async Task<User> UpdateUser(User User)
        {
            _db.Users.Update(User);
            await _db.SaveChangesAsync();
            return User;
        }
    }
}