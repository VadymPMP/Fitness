using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// User's controller.
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// List of users.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Application user.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Simple user verification.
        /// </summary>
        public bool IsNewUSer { get; } = false;
        /// <summary>
        /// Creating a new controller for user
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User's name can't be empty", nameof(userName));
            }

            Users = GetUsersData();


            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUSer = true;
            }
           
        }
        /// <summary>
        /// Get the saved user's list
        /// </summary>
        /// <returns>List of User</returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>(); 
            //return Load<List<User>>(UserFileName) ?? new List<User>();
            
        }


        /// <summary>
        /// Adding information about a new user.
        /// </summary>
        /// <param name="genderName"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Save data about users.  
        /// </summary>
        public void Save()
        {
            Save(Users);
            
        }
    }
}
