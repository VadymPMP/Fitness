using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Class about User.
    /// </summary>
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        #region User class properties
        /// <summary>
        /// Name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gender of the user.
        /// </summary>
        public Gender Gender { get; set; } 

        /// <summary>
        /// Birthday of the user.
        /// </summary>
        public DateTime BirthDate { get; set; }
        
        /// <summary>
        /// Weight of the user.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height of the user.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Age of the user.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate,
                    double weight, 
                    double height)
        {
            #region Condition check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of the user can't be empty", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender can't be empty", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Date of birth isn't possible", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight cannot be <= 0", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height cannot be <= 0", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="name"></param>
        public User(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of the user can't be empty", nameof(name));
            }

            Name = name;

        }

        /// <summary>
        /// To display simple user's information
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return Name + " " + Age;
        }


    }
}
