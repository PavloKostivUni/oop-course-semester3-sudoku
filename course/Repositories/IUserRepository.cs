using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace course.Repositories
{
    public interface IUserRepository
    {
        void RegisterUser(User user);
        User? GetUserByUserName(string userName);
        IEnumerable<User> GetAllUsers();
    }
}
