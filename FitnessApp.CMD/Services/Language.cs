using System.Globalization;
using System.Resources;

namespace FitnessApp.CMD.Services
{
    internal static class Language
    {
        private static ResourceManager _rm = new ResourceManager("FitnessApp.CMD.Languages.Messages", typeof(Program).Assembly);

        public static CultureInfo CurrentCulture { get; set; } = CultureInfo.CurrentCulture;

        public static string Text(string key) => _rm.GetString(key, CurrentCulture);
    }
}
