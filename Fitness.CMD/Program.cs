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

                var weight = ParseDouble("weight");

                var height = ParseDouble("height");

                var birthDate = ParseDateTime("date of birth");

                userController.SetNewUSerData(gender, birthDate, weight, height);

            }
            while (true)
            {

                Console.WriteLine(userController.CurrentUser);
                Console.WriteLine("Would you like to do? ");
                Console.WriteLine("E - input eating food");
                Console.WriteLine("A - input doing exercises");
                Console.WriteLine("Q - Quit");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value} ");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        //var exercise = new Exercise(exe.begin, exe.end, exe.activity, userController.CurrentUser);
                        exerciseController.Add(exe.activity, exe.begin, exe.end);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()};  ");
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

        private static (DateTime begin, DateTime end, Activity activity) EnterExercise()
        {
            Console.Write("Input the exercise name: ");
            var name = Console.ReadLine();
            var energy = ParseDouble("Energy consumption per minute");
            var begin = ParseDateTime("begin exercise");
            var end = ParseDateTime("end exercise");
            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        /// <summary>
        /// Read food information from the console and create an instance of the appropriate class.
        /// </summary>
        /// <returns>Cortège(Food food, double weight)</returns>
        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Input the food's name: ");
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
        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Input {value} (dd.MM.yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Wrong {value} format");
                }
            }

            return birthDate;
        }

        /// <summary>
        /// Parsing Double format for my application. 
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
