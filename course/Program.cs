using System;
using course.Repositories;
using course.Services;

namespace course
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext db = new DbContext();

            UserRepository userRepository = new UserRepository(db);
            UserService userService = new UserService(userRepository);
            GameRepository gameRepository = new GameRepository(db);
            GameService gameService = new GameService(gameRepository);


            Menu menu = new Menu(gameService, userService);
            menu.Display();
        }
    }
}