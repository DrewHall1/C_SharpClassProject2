using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpClassProject2
{
    class Program
    {

        public static void Main(string[] args)
        {
            var fileName = @"ListOfExercises.csv";
            List<Workouts> Exercises = new List<Workouts>();
            ReadWrite.ReadData(fileName, Exercises);
            var Finished = false;

            while (!Finished)
            {
                Console.WriteLine("Welcome to Basic Training you slimey maggot! ");
                Console.WriteLine("Choose your entrance to hell on earth - 1. View all workouts 2. Make my own, 3. Edit existing, 4. I'm not worthy today - I QUIT!");

                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        ReadWrite.ViewData(Exercises);
                        break;

                    case "2":
                        ReadWrite.AddWorkouts(Exercises);
                        break;

                    case "3":
                        ReadWrite.EditWorkouts(Exercises, fileName);
                        break;

                    case "4":
                        Finished = true;
                        break;

                    default:
                        Console.WriteLine("Your input was not valid.");
                        break;
                }

                ReadWrite.WriteData(fileName, Exercises);
            }
        }
    }
}
