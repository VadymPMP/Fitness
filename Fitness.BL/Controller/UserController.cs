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
    public class UserController
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
            //TODO: exception 
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
                Save();
            }
           
            
                //?? throw new ArgumentNullException("User can't be empty", nameof(user)); 
        }
        /// <summary>
        /// Get the saved user's list
        /// </summary>
        /// <returns>List of User</returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
                // TODO: What we should do if user doesn't load?
            }
        }


        /// <summary>
        /// If the user is new, I set all the necessary fields and properties.
        /// </summary>
        /// <param name="genderName"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public void SetNewUSerData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // exception
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
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate)) 
            {
                formatter.Serialize(fs, Users);    
            }
            
        }


    }
}
