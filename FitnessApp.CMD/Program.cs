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
            Console.Write("1. Русский\n2. English\n-> ");
            var key = Console.ReadKey().Key;
            Language.CurrentCulture = key == ConsoleKey.D2 ? new CultureInfo("en-US") : new CultureInfo("ru-RU");
            new AuthorizationView();
        }
    }
}
