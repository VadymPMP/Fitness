using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// Application user.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Creating a new controller for user
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDate, double weigth, double height)
        {
            //TODO: exception 
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weigth, height);
            
                //?? throw new ArgumentNullException("User can't be empty", nameof(user)); 
        }
        /// <summary>
        /// Creating a new controller for user
        /// </summary>
        /// <param name="user"></param>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }


                // TODO: What we should do if user doesn't load?


                //if (formatter.Deserialize(fs) is User user)
                //{
                //    return user;
                //}
                //else
                //{
                //    //throw new FileLoadException("Failed to get data about user from file", "users.dat");

                //}

            }
        }
        /// <summary>
        /// Save data about the user.  
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate)) 
            {
                formatter.Serialize(fs, User);    
            }
            
        }


    }
}
