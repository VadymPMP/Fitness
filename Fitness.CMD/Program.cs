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

            var userControler = new UserController(name);

            if (userControler.IsNewUSer)
            {

                Console.WriteLine("Input user's gender");
                var gender = Console.ReadLine();

                var weight = ParseDouble("weight");

                var height = ParseDouble("height");

                var birthDate = ParseDateTime();

                userControler.SetNewUSerData(gender, birthDate, weight, height);

            }

            Console.WriteLine(userControler.CurrentUser);
            Console.ReadLine();
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
