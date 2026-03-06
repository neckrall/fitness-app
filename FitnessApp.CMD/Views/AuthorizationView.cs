using FitnessApp.BL.Controllers;
using FitnessApp.BL.Models;
using FitnessApp.CMD.Services;
using System;

namespace FitnessApp.CMD.Views
{
    internal class AuthorizationView : BaseView
    {
        public AuthorizationView() : base() => Run();

        protected override void Run()
        {
            Console.Title = Language.Text("AuthorizationTitle");

            var userName = Message.Ask(Language.Text("EnterName"), User.MIN_NAME_LENGTH, User.MAX_NAME_LENGTH);
            var userController = new UserController(userName);

            if (userController.IsNewUser)
                new RegistrationView(userController);
            else 
                new MainView(userController);
        }
    }
}
