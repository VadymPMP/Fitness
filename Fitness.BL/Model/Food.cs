using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Class describing food. 
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// The name of food.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Proteins for certain food per 100 grams.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Fats for a certain food per 100 grams.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Carbohydrates for a certain food per 100 grams.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Calories for a certain food per 100 grams.
        /// </summary>
        public double Calories { get; }
        ///// <summary>
        ///// Calories for a certain food per 1 gram.
        ///// </summary>
        //private double CaloriesOneGramm { get { return Calories / 100.0; } }
        ///// <summary>
        ///// Calories for a certain food per 1 gram.
        ///// </summary>
        //private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }
        ///// <summary>
        ///// Carbohydrates for a certain food per 1 gram.
        ///// </summary>
        //private double FatsOneGramm {get { return Fats / 100.0; } }
        ///// <summary>
        ///// Proteins for certain food per 1 gram.
        ///// </summary>
        //private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        /// <summary>
        /// Create a new food.
        /// </summary>
        /// <param name="name"></param>
        public Food(string name): this (name, 0, 0, 0, 0) { }

        /// <summary>
        /// Create a new food.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="calories"></param>
        /// <param name="proteins"></param>
        /// <param name="fats"></param>
        /// <param name="carbohydrates"></param>
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            //TODO exception
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
