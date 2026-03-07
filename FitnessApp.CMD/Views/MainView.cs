using FitnessApp.BL.Controllers;
using FitnessApp.CMD.Services;
using System;

namespace FitnessApp.CMD.Views
{
    internal class MainView : BaseView
    {
        private readonly UserController _userController;

        public MainView(UserController userController) : base()
        {
            _userController = userController;
            Run();
        }

        protected override void Run()
        {
            Console.Title = Language.Text("Main");
            Console.WriteLine($"{Language.Text("Hello")}, {_userController.User.Name}!\n");
            Console.WriteLine(Language.Text("Menu"));

            Message.ShowControl("P", Language.Text("Profile"));
            Message.ShowControl("Q", Language.Text("Exit"));

            var input = Console.ReadKey();

            switch (input.Key) 
            {
                case ConsoleKey.P:
                    new UserView(_userController);
                    break;

                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;

                default:
                    new MainView(_userController);
                    break;
            }
        }
    }
}
