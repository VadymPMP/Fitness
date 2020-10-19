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
        public int Id { get; set; }
        /// <summary>
        /// The name of food.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Proteins for certain food per 100 grams.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Fats for a certain food per 100 grams.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Carbohydrates for a certain food per 100 grams.
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Calories for a certain food per 100 grams.
        /// </summary>
        public double Calories { get; set; }

        public double Weight { get; set; }

        //public virtual ICollection<Eating> Eatings { get; set; }
        /// <summary>
        /// Create a new food.
        /// </summary>
        /// <param name="name"></param>
        public Food() { }

        /// <summary>
        /// Create a new food.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="calories"></param>
        /// <param name="proteins"></param>
        /// <param name="fats"></param>
        /// <param name="carbohydrates"></param>
        public Food(string name, double calories, double proteins, double fats, double carbohydrates, double weight)
        {
            //TODO exception
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Weight = weight;
            

        }
        /// <summary>
        /// To display simple food's information
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
