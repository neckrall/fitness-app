using System;

namespace FitnessApp.BL.Services
{
    internal static class Validate
    {
        public static string Length(string value, int minLength, int maxLength, string paramName)
        {
            value = NotNull(value, paramName);
            value = value.Trim();

            if (value.Length < minLength || value.Length > maxLength)
                throw new ArgumentOutOfRangeException(paramName);

            return value;
        }

        public static T NotNull<T>(T value, string paramName) where T : class
        {
            if (value is null)
                throw new ArgumentNullException(paramName);

            return value;
        }

        public static T Range<T>(T value, T min, T max, string paramName) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                throw new ArgumentOutOfRangeException(paramName);

            return value;
        }
    }
}
