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

            Message.ShowParam(Language.Text("Gender"), _userController.User.Gender.Name);
            Message.ShowParam(Language.Text("BirthDate"), $"{_userController.User.BirthDate:dd.MM.yyyy}");
            Message.ShowParam(Language.Text("Weight"), _userController.User.Weight.ToString());
            Message.ShowParam(Language.Text("Height"), _userController.User.Height.ToString());

            Console.ResetColor();

            Console.WriteLine("\n" + Language.Text("Menu"));
            Message.ShowControl("E", Language.Text("Back"));

            var input = Console.ReadKey();

            switch (input.Key) 
            {
                case ConsoleKey.E:
                    new MainView(_userController);
                    break;

                default:
                    new UserView(_userController);
                    break;
            }
        }
    }
}
