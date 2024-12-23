using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext Context { get; set; }
        public UserRepository(DbContext Context)
        {
            this.Context = Context;
        }

        public void RegisterUser(User user)
        {
            Context.Users.Add(user);
            Console.WriteLine("Користувач зареєстрований!");
        }
        public User? GetUserByUserName(string userName)
        {
            foreach (User user in Context.Users)
            {
                if (user.UserName == userName) return user;
            }
            return null;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return Context.Users.AsEnumerable();
        }
    }
}
