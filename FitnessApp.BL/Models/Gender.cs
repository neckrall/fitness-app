using FitnessApp.BL.Services;
using System;
using System.Collections.Generic;

/*
 * ВАЖНО:
 * Атрибут [Serializable] НЕ наследуется.
 * Каждый класс модели, который участвует в сериализации, должен явно быть помечен этим атрибутом.
 */

namespace FitnessApp.BL.Models
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public const int MIN_NAME_LENGTH = 1;
        public const int MAX_NAME_LENGTH = 10;

        // Для бинарной сериализации сохраняются поля, включая private.
        private int _id;
        private string _name;

        /// <summary>
        /// Создать новый пол.
        /// </summary>
        public Gender(string name) => Name = name;

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public Gender() { }

        /// <summary>
        /// Идентификатор для EF.
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = Validate.Length(value, MIN_NAME_LENGTH, MAX_NAME_LENGTH, nameof(Name));
        }

        /// <summary>
        /// Список пользователей, принадлежащих к этому полу.
        /// </summary>
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
