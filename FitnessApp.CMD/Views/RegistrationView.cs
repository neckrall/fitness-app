using FitnessApp.BL.Controllers;
using FitnessApp.BL.Models;
using FitnessApp.CMD.Services;
using System;

namespace FitnessApp.CMD.Views
{
    internal class RegistrationView : BaseView
    {
        private readonly UserController _userController;

        public RegistrationView(UserController userController) : base()
        {
            _userController = userController;
            Run();
        }

        protected override void Run()
        {
            Console.Title = $"{Language.Text("RegistrationTitle")} (1/4)";
            var userGender = Message.Ask(Language.Text("EnterGender"), Gender.MIN_NAME_LENGTH, Gender.MAX_NAME_LENGTH);
            Console.Clear();

            Console.Title = $"{Language.Text("RegistrationTitle")} (2/4)";
            var userBirthDate = Message.AskDate(Language.Text("EnterBirthDate"), User.MIN_BIRTH_DATE, User.MAX_BIRTH_DATE);
            Console.Clear();

            Console.Title = $"{Language.Text("RegistrationTitle")} (3/4)";
            var userWeight = Message.AskDouble(Language.Text("EnterWeight"), User.MIN_WEIGHT, User.MAX_WEIGHT);
            Console.Clear();

            Console.Title = $"{Language.Text("RegistrationTitle")} (4/4)";
            var userHeight = Message.AskDouble(Language.Text("EnterHeight"), User.MIN_HEIGHT, User.MAX_HEIGHT);
            Console.Clear();

            _userController.Register(userGender, userBirthDate, userWeight, userHeight);
            new MainView(_userController);
        }
    }
}
