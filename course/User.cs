using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.Services;

namespace course
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Rating { get; private set; } = 1000;

        private readonly int accountNumber;
        private static int acountNumberSeed = 123456789;

        public User(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
            accountNumber = acountNumberSeed;
            acountNumberSeed++;
        }

        public void ChangeRating(int gameRating)
        {
            if (gameRating > 0)
            {
                Rating = Rating + gameRating;
            }
            else
            {
                if (Rating + gameRating < 1) Rating = 1;
                else Rating += gameRating;
            }
        }

    }
}
