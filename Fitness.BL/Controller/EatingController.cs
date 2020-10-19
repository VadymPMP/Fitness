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
    /// Eating controller
    /// </summary>
    [Serializable]
    public class EatingController : ControllerBase
    {
        /// <summary>
        /// Our current user.
        /// </summary>
        private readonly User user;
        /// <summary>
        /// List of food
        /// </summary>
        public List<Food> Foods { get;  }
        /// <summary>
        /// Eating process.
        /// </summary>
        public Eating Eating { get;  }
        /// <summary>
        /// Create a new EatingController.
        /// </summary>
        /// <param name="user"></param>
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Name of the user can't be empty", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating(); 
        }
        /// <summary>
        /// Adding information about food and its weight
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        /// <summary>
        /// Get the saved eating's list.
        /// </summary>
        /// <returns>List of Eating.</returns>
        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }
        /// <summary>
        /// Get the saved food's list.
        /// </summary>
        /// <returns>List of Food.</returns>
        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }
        /// <summary>
        /// Save data about foods and eatings.
        /// </summary>
        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() {Eating});
        }


    }
}
