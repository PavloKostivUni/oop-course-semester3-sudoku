using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;

namespace course
{
    public class UserFactory
    {
        public static User CreateUser(string userName, string password)
        {
            return new User(userName, password);
        }
    }
}
