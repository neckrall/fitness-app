using FitnessApp.BL.Controllers;
using System;
using System.Globalization;
using System.Text;

namespace FitnessApp.CMD.Services
{
    internal static class Message
    {
        public static string Ask(string question, int minLength, int maxLength)
        {
            Console.Clear();

            var buffer = new StringBuilder();
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            while (true)
            {
                Console.SetCursorPosition(0, top);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{question}: ");
                Console.Write(new string(' ', Console.WindowWidth - (question.Length + 2)));
                Console.SetCursorPosition(question.Length + 2, top);

                var errorMessage = string.Empty;
                var isValid = buffer.Length >= minLength && buffer.Length <= maxLength;

                if (buffer.Length > 0 && !isValid)
                    errorMessage = buffer.Length < minLength ? $"{Language.Text("NotLess")} {minLength}" : $"{Language.Text("NoMore")} {maxLength}";

                Console.ForegroundColor = isValid ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(buffer);
                Console.SetCursorPosition(0, top + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(new string(' ', Console.WindowWidth));

                if (!isValid && buffer.Length > 0)
                {
                    Console.SetCursorPosition(0, top + 1);
                    Console.Write(errorMessage);
                }

                Console.SetCursorPosition(question.Length + 2 + buffer.Length, top);

                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Backspace && buffer.Length > 0)
                    buffer.Length--;

                else if (key.Key == ConsoleKey.Enter)
                {
                    if (isValid)
                    {
                        Console.SetCursorPosition(0, top + 2);
                        Console.WriteLine();
                        return buffer.ToString();
                    }
                }

                else if (!char.IsControl(key.KeyChar))
                    buffer.Append(key.KeyChar);
            }
        }

        public static double AskDouble(string question, double min, double max)
        {
            Console.Clear();

            var buffer = new StringBuilder();
            var top = Console.CursorTop;

            while (true)
            {
                Console.SetCursorPosition(0, top);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{question}: ");
                Console.Write(new string(' ', Console.WindowWidth - (question.Length + 2)));
                Console.SetCursorPosition(question.Length + 2, top);

                var errorMessage = string.Empty;
                var parseOk = double.TryParse(buffer.ToString(), out double value);
                var isValid = parseOk && value >= min && value <= max;

                if (buffer.Length > 0)
                {
                    if (!parseOk)
                        errorMessage = Language.Text("EnterNumber");
                    else if (value < min)
                        errorMessage = $"{Language.Text("NotLess")} {min}";
                    else if (value > max)
                        errorMessage = $"{Language.Text("NoMore")} {max}";
                }

                Console.ForegroundColor = isValid ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(buffer);
                Console.SetCursorPosition(0, top + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(new string(' ', Console.WindowWidth));

                if (!isValid && buffer.Length > 0)
                {
                    Console.SetCursorPosition(0, top + 1);
                    Console.Write(errorMessage);
                }

                Console.SetCursorPosition(question.Length + 2 + buffer.Length, top);

                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Backspace && buffer.Length > 0)
                    buffer.Length--;

                else if (key.Key == ConsoleKey.Enter)
                {
                    if (isValid)
                    {
                        Console.SetCursorPosition(0, top + 2);
                        Console.WriteLine();
                        return value;
                    }
                }

                else if (!char.IsControl(key.KeyChar))
                    buffer.Append(key.KeyChar);
            }
        }

        public static DateTime AskDate(string question, DateTime minDate, DateTime maxDate)
        {
            Console.Clear();

            var buffer = new StringBuilder();
            var top = Console.CursorTop;
            var prefix = $"{question} ({Language.Text("DateFormat")}): ";

            while (true)
            {
                Console.SetCursorPosition(0, top);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(prefix);
                Console.Write(new string(' ', Console.WindowWidth - prefix.Length));
                Console.SetCursorPosition(prefix.Length, top);

                var errorMessage = string.Empty;
                var parseOk = DateTime.TryParseExact(buffer.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime value);
                var isValid = parseOk && value >= minDate && value <= maxDate;

                if (buffer.Length > 0)
                {
                    if (!parseOk)
                        errorMessage = $"{Language.Text("DateFormatError")} {Language.Text("DateFormat")}"; 
                else if (value < minDate)
                        errorMessage = $"{Language.Text("NoLater")} {minDate:dd.MM.yyyy}"; 
                    else if (value > maxDate)
                        errorMessage = $"{Language.Text("NoLater")} {maxDate:dd.MM.yyyy}"; 
                }

                Console.ForegroundColor = isValid ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(buffer);
                Console.SetCursorPosition(0, top + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(new string(' ', Console.WindowWidth));

                if (!isValid && buffer.Length > 0)
                {
                    Console.SetCursorPosition(0, top + 1);
                    Console.Write(errorMessage);
                }

                Console.SetCursorPosition(prefix.Length + buffer.Length, top);

                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Backspace && buffer.Length > 0)
                    buffer.Length--;

                else if (key.Key == ConsoleKey.Enter)
                {
                    if (isValid)
                    {
                        Console.SetCursorPosition(0, top + 2);
                        Console.WriteLine();
                        return value;
                    }
                }

                else if (!char.IsControl(key.KeyChar))
                    buffer.Append(key.KeyChar);
            }
        }

        public static void ShowControl(string keyTitle, string commandTitle) 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(keyTitle);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" - {commandTitle}");
        }

        public static void ShowParam(string paramName, string value) 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{paramName}: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(value);
        }
    }
}