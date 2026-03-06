using FitnessApp.BL.Controllers;
using FitnessApp.CMD.Services;
using System;

namespace FitnessApp.CMD.Views
{
    internal class UserView : BaseView
    {
        private readonly UserController _userController;

        public UserView(UserController userController) : base()
        {
            _userController = userController;
            Run();
        }

        protected override void Run()
        {
            Console.Title = Language.Text("Profile");
            Console.WriteLine($"{_userController.User.Name}, {_userController.User.Age}\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{Language.Text("Gender")}: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_userController.User.Gender.Name);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{Language.Text("BirthDate")}: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{_userController.User.BirthDate:dd.MM.yyyy}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{Language.Text("Weight")}: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_userController.User.Weight);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{Language.Text("Height")}: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_userController.User.Height);

            Console.ReadKey();
            new MainView(_userController);
        }
    }
}
