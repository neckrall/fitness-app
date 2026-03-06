using FitnessApp.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controllers
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : BaseController
    {
        private readonly List<User> _users;

        /// <summary>
        /// Создать новый контроллер пользователя.
        /// </summary>
        public UserController(string userName)
        {
            _users = Load<User>() ?? new List<User>();
            User = _users.SingleOrDefault(u => u.Name == userName);

            if (User is null) 
            {
                IsNewUser = true;
                User = new User(userName);
            }
        }

        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Является ли пользователь новым.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Зарегистрировать нового пользователя.
        /// </summary>
        public void Register(string genderName, DateTime birthDate, double weight, double height) 
        { 
            var genders = Load<Gender>() ?? new List<Gender>();
            var gender = genders.FirstOrDefault(g => g.Name == genderName);

            if (gender is null) 
            {
                gender = new Gender(genderName);
                genders.Add(gender);
                Save(genders);
            }

            User.Gender = gender;
            User.BirthDate = birthDate;
            User.Weight = weight;
            User.Height = height;

            _users.Add(User);
            Save(_users);
        }
    }
}
