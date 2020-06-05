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

            Console.WriteLine("Input user's gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Input user's birthday");
            var birthdate = DateTime.Parse(Console.ReadLine()); //TODO: rewrite

            Console.WriteLine("Input user's weight");
            var weight = Double.Parse(Console.ReadLine());

            Console.WriteLine("Input user's heighr");
            var height = Double.Parse(Console.ReadLine());

            var userControler = new UserController(name, gender, birthdate, weight, height);
            userControler.Save(); 
            //if (name.Length <= 1)
            //{

            //}
            //while(Console.ReadLine().Length)
        }
    }
}
