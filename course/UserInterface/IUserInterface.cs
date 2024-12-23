using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.UserInterface
{
    public interface IUserInterface
    {
        void Execute();
        string CommandInfo();
    }
}
