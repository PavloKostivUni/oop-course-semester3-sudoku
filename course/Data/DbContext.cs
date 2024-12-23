using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class DbContext
    {
        public List<User> Users { get; set; }
        public List<Game> Games { get; set; }

        public DbContext()
        {
            Users = new List<User>();
            Games = new List<Game>();
        }
    }
}
