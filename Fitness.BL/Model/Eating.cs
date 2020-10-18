using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Class about eating foods.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        /// <summary>
        /// Dictionary about foods.
        /// </summary>
        public List<Food> Foods { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Eating() { }
        /// <summary>
        /// Create a new Eating.
        /// </summary>
        /// <param name="user"></param>

        public Eating(User user) 
        {
            User = user ?? throw new ArgumentNullException("Name of the user can't be empty", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new List<Food>();
        }
        /// <summary>
        /// Adding the new food and weight of the food
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void Add(Food food)
        {
            
            var product = Foods.SingleOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food);
            }
                 
        }
    }
}
