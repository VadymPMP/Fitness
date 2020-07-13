﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Class about activity
    /// </summary>
    [Serializable]
    public class Activity
    {
     
        /// <summary>
        /// Activity name
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// The number of calories expended during exercise
        /// </summary>
        public double CaloriesPerMinute { get; }

        /// <summary>
        /// Creating new activity
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caloriesPErMinute"></param>
        public Activity(string name, double caloriesPErMinute)
        {
            // Exception
            Name = name;
            CaloriesPerMinute = caloriesPErMinute;
        }
        /// <summary>
        /// To display simple user's information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}