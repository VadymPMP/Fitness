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
    public class EatingController : ControllerBase<Eating>
    {
        /// <summary>
        /// File's name with information about foods
        /// </summary>
        private const string FoodsFileName = "foods.dat";
        /// <summary>
        /// File's name with information about eating
        /// </summary>
        private const string EatingsFileName = "eatings.dat";
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
        public void Add(Food food)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food);
                Save();
            }
            else
            {
                Eating.Add(product);
                Save();
            }
        }
        /// <summary>
        /// Get the saved eating's list.
        /// </summary>
        /// <returns>List of Eating.</returns>
        private Eating GetEating()
        {
            return Load().First();
        }
        /// <summary>
        /// Get the saved food's list.
        /// </summary>
        /// <returns>List of Food.</returns>
        private List<Food> GetAllFoods()
        {
            return Load();
        }
        /// <summary>
        /// Save data about foods and eatings.
        /// </summary>
        private void Save()
        {
            Save();
            Save();
        }


    }
}
