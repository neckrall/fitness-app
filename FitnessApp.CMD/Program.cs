using FitnessApp.CMD.Services;
using FitnessApp.CMD.Views;
using System;
using System.Globalization;

namespace FitnessApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Fitness App";
            Message.ShowControl("1", "Русский");
            Message.ShowControl("2", "English");
            Console.Write("-> ");
            Language.CurrentCulture = Console.ReadKey().Key == ConsoleKey.D2 ? new CultureInfo("en-US") : new CultureInfo("ru-RU");
            new AuthorizationView();
        }
    }
}
