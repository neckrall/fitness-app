using FitnessApp.BL.Services;
using System;

/*
 * ВАЖНО:
 * Атрибут [Serializable] НЕ наследуется.
 * Каждый класс модели, который участвует в сериализации, должен явно быть помечен этим атрибутом.
 */

namespace FitnessApp.BL.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        public const int MIN_NAME_LENGTH = 2;
        public const int MAX_NAME_LENGTH = 100;
        public const double MIN_WEIGHT = 2;
        public const double MAX_WEIGHT = 500;
        public const double MIN_HEIGHT = 50;
        public const double MAX_HEIGHT = 300;

        // Границы даты динамические, чтобы не устаревали
        public static DateTime MIN_BIRTH_DATE => DateTime.Today.AddYears(-120);
        public static DateTime MAX_BIRTH_DATE => DateTime.Today;

        // Для бинарной сериализации сохраняются поля, включая private.
        private int _id;
        private int? _genderId;
        private string _name;
        private Gender _gender;
        private DateTime _birthDate = DateTime.Now;
        private double _weight;
        private double _height;

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        public User(string name) => Name = name;

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public User() { }

        /// <summary>
        /// Идентификатор для EF.
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = Validate.Length(value, MIN_NAME_LENGTH, MAX_NAME_LENGTH, nameof(Name));
        }

        /// <summary>
        /// Идентификатор для EF.
        /// </summary>
        public int? GenderId
        {
            get => _genderId;
            set => _genderId = value;
        }

        /// <summary>
        /// Пол.
        /// </summary>
        public virtual Gender Gender
        {
            get => _gender;
            set
            {
                _gender = Validate.NotNull(value, nameof(Gender));
                _genderId = value?.Id;
            }
        }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = Validate.Range(value, MIN_BIRTH_DATE, MAX_BIRTH_DATE, nameof(BirthDate));
        }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - _birthDate.Year;

                if (_birthDate > now.AddYears(-age))
                    age--;

                return age;
            }
        }

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight
        {
            get => _weight;
            set => _weight = Validate.Range(value, MIN_WEIGHT, MAX_WEIGHT, nameof(Weight));
        }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height
        {
            get => _height;
            set => _height = Validate.Range(value, MIN_HEIGHT, MAX_HEIGHT, nameof(Height));
        }
    }
}
