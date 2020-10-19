using System;
using System.Collections.Generic;


namespace Fitness.BL.Model
{
    /// <summary>
    /// Class about User.
    /// </summary>
    [Serializable]
    public class User
    {
        public int ID { get; set; }
        #region User class properties
        /// <summary>
        /// Name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gender of the user.
        /// </summary>
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Birthday of the user.
        /// </summary>
        //public DateTime BirthDate { get; set; }

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
        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        #endregion
        public User() { }
        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        //DateTime nowDate = DateTime.Today;
        //int age = nowDate.Year - birthDate.Year;
        //if (birthDate > nowDate.AddYears(-age)) age--;

      

        public User(string name,
                    Gender gender,
                   
                    double weight,
                    double height)
        {
            #region 
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name can't be empty or null", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender can't be null.", nameof(gender));
            }

           

            if (weight <= 0)
            {
                throw new ArgumentException("Weight can't be <= 0 .", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height can't be <= 0 .", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
          
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
            return Name + " " + Gender + " " + Weight + " " + Height ;
        }


    }
}
