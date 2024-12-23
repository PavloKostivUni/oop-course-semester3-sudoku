using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Repositories;

namespace course.Services
{
    public class UserService : IUserService
    {
        private IUserRepository Repository { get; set; }
        public User? LoggedInUser { get; set; }
        public UserService(IUserRepository Repository)
        {
            this.Repository = Repository;
        }

        public void RegisterUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Назва та пароль користувача не можуть бути пустими");
                return;
            }

            if (Repository.GetUserByUserName(username) != null)
            {
                throw new Exception("Користувач з таким iменем вже iснує");
            }

            PasswordHasher passwordHasher = new PasswordHasher();               ///
            password = passwordHasher.HashPassword(password);                   ////

            Console.WriteLine($"Password hashed: {password}");                  ////


            User user = UserFactory.CreateUser(username, password);
            Repository.RegisterUser(user);
        }
        public void LoginUser(string username, string password)
        {
            User? user = Repository.GetUserByUserName(username);

            PasswordHasher passwordHasher = new PasswordHasher();               ///

            if (user != null && passwordHasher.VerifyPassword(password, user.Password))         ///
            {
                LoggedInUser = user;
                Console.WriteLine("Вхiд успiшний");
                return;
            }

            Console.WriteLine("Iм'я або пароль користувача неправильнi");
        }
        public void LogoutUser()
        {
            LoggedInUser = null;
            Console.WriteLine("Ви вийшли з акаунту!");   
        }
        public User? GetUserByUserName(string userName)
        {
            return Repository.GetUserByUserName(userName);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return Repository.GetAllUsers();
        }
    }
}
