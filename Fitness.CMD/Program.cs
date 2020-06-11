using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the application Fitness");
             
            Console.WriteLine("Input user's name");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUSer)
            {

                Console.WriteLine("Input user's gender");
                var gender = Console.ReadLine();

                var weight = ParseDouble("weight");

                var height = ParseDouble("height");

                var birthDate = ParseDateTime();

                userController.SetNewUSerData(gender, birthDate, weight, height);

            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Would you like to do? ");
            Console.WriteLine("E - input eating food");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value} ");
                }
            }
            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Input the food's name");
            var food = Console.ReadLine();

            var calories = ParseDouble("calories of the food");
            var proteins = ParseDouble("proteins of the food");
            var fats = ParseDouble("fats of the food");
            var carbohydrates = ParseDouble("carbohydrates of the food");

            var weight = ParseDouble("weight of the food");
            var product = new Food(food, calories, proteins, fats, carbohydrates);
            return (Food : product, Weight : weight);
        }


        /// <summary>
        /// Parsing DateTime format for my app.
        /// </summary>
        /// <returns>DateTime</returns>
        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Input user's birthday (dd.MM.yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong date format");
                }
            }

            return birthDate;
        }

        /// <summary>
        /// Parsing Double format for my app. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Double</returns>
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Input user's {name}");
             
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong {name} format");
                }
            }
        }
    }
}
