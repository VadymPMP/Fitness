using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Fitness.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FoodsFileName = "foods.dat";
        private const string EatingsFileName = "eatings.dat";
        private readonly User user;

        public List<Food> Foods { get;  }

        public Eating Eating { get;  }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Name of the user can't be empty", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating(); 
        }
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
        private Eating GetEating()
        {
            return Load<Eating>(EatingsFileName) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FoodsFileName) ?? new List<Food>();
        }
        private void Save()
        {
            Save(FoodsFileName, Foods);
            Save(EatingsFileName, Eating);
        }


    }
}
