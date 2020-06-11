using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Eating foods.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; }
        /// <summary>
        /// Dictionary about foods.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        
        public User User { get; }
        /// <summary>
        /// Create a new Eating.
        /// </summary>
        /// <param name="user"></param>
        public Eating(User user) 
        {
            User = user ?? throw new ArgumentNullException("Name of the user can't be empty", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        /// <summary>
        /// Adding the new food and weight of the food
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void Add(Food food, double weight)
        {
            
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
                 
        }
    }
}
