using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));
             
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUSer)
            {

                Console.WriteLine(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();

                var weight = ParseDouble(resourceManager.GetString("We",culture), resourceManager, culture);

                var height = ParseDouble(resourceManager.GetString("He", culture), resourceManager, culture);

                var birthDate = ParseDateTime(resourceManager.GetString("Date", culture), resourceManager, culture);

                userController.SetNewUSerData(gender, birthDate, weight, height);

            }
            while (true)
            {

                Console.WriteLine(userController.CurrentUser);
                Console.WriteLine(resourceManager.GetString("Choose", culture));
                Console.WriteLine(resourceManager.GetString("Eating", culture));
                Console.WriteLine(resourceManager.GetString("Exercises", culture));
                Console.WriteLine(resourceManager.GetString("Exit", culture));
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating(resourceManager, culture);
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value} ");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise(resourceManager, culture);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} {resourceManager.GetString("From", culture)} {item.Start.ToShortTimeString()} {resourceManager.GetString("To", culture)} {item.Finish.ToShortTimeString()};  ");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
            
        }
        /// <summary>
        /// Read activity information from the console and create an instance of the appropriate class.
        /// </summary>
        /// <returns>Cortège(DateTime Begin, DateTime End, Activity activity)</returns>

        private static (DateTime begin, DateTime end, Activity activity) EnterExercise(ResourceManager resourceManager, CultureInfo culture)
        {
            Console.Write(resourceManager.GetString("ExerciseName", culture));
            var name = Console.ReadLine();
            var energy = ParseDouble(resourceManager.GetString("Energy", culture), resourceManager, culture);
            var begin = ParseDateTime(resourceManager.GetString("Begin", culture), resourceManager, culture);
            var end = ParseDateTime(resourceManager.GetString("End", culture), resourceManager, culture);
            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        /// <summary>
        /// Read food information from the console and create an instance of the appropriate class.
        /// </summary>
        /// <returns>Cortège(Food food, double weight)</returns>
        private static (Food Food, double Weight) EnterEating(ResourceManager resourceManager, CultureInfo culture)
        {
            Console.Write(resourceManager.GetString("FoodName", culture));
            var food = Console.ReadLine();

            var calories = ParseDouble(resourceManager.GetString("Calories", culture), resourceManager, culture);
            var proteins = ParseDouble(resourceManager.GetString("Proteins", culture), resourceManager, culture);
            var fats = ParseDouble(resourceManager.GetString("Fats", culture), resourceManager, culture);
            var carbohydrates = ParseDouble(resourceManager.GetString("Carboh", culture), resourceManager, culture);

            var weight = ParseDouble(resourceManager.GetString("Weight", culture), resourceManager, culture);
            var product = new Food(food, calories, proteins, fats, carbohydrates);
            return (Food : product, Weight : weight);
        }


        /// <summary>
        /// Parsing DateTime format for my app.
        /// </summary>
        /// <returns>DateTime</returns>
        private static DateTime ParseDateTime(string value, ResourceManager resourceManager, CultureInfo culture)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"{resourceManager.GetString("In", culture)} {value} {resourceManager.GetString("Da", culture)}");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"{resourceManager.GetString("Wr", culture)} {value} {resourceManager.GetString("Fo", culture)}");
                }
            }

            return birthDate;
        }

        /// <summary>
        /// Parsing Double format for my application. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Double</returns>
        private static double ParseDouble(string name, ResourceManager resourceManager, CultureInfo culture)
        {
            while (true)
            {
                Console.WriteLine($"{resourceManager.GetString("In", culture)} {resourceManager.GetString("User", culture)} {name}");
             
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"{resourceManager.GetString("Wr", culture)} {name} {resourceManager.GetString("Fo", culture)}");
                }
            }
        }
    }
}
