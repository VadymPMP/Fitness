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
        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be empty", nameof(user)); 
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

        /// <summary>
        /// Load data about the user.  
        /// </summary>
        /// <returns>Application user.</returns>>
        public User Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs) as User;
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

    }
}
