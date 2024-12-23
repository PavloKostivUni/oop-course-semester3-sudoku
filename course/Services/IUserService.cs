using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.Services
{
    public interface IUserService
    {
        User? LoggedInUser { get; set; }
        void RegisterUser(string username, string password);
        void LoginUser(string username, string password);
        void LogoutUser();
        User? GetUserByUserName(string userName);
        IEnumerable<User> GetAllUsers();
    }
}
