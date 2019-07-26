using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace C_SharpClassProject2
{
    public static class ReadWrite
    {
        //This method takes my CSV and uses a stream reader to read it into a list of exercises objects. This happens right when the app opens.
        public static List<Workouts> ReadData(string fileName, List<Workouts>Exercises)
        {
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine();
                    var column = row.Split(',');
                    var Workouts = new Workouts()
                    {
                        Id = column[0],
                        Type = column[1],
                        Name = column[2]
                    };
                    Exercises.Add(Workouts);
                }
            }
            return Exercises;
        }
        //This method writes all the exercises currently in the database to the console for the user to choose from.
        public static List<Workouts> ViewData(List<Workouts> Exercises)
        {
            foreach (Workouts workouts in Exercises)
            {
                Console.WriteLine(workouts);
            }
            return Exercises;
        }
        //This method promts the user to add a new/different exercise to the existing list and saves it.
        public static List<Workouts> AddWorkouts(List<Workouts> Exercises)
        {
            var newWorkouts = new Workouts();
            newWorkouts.Id = Exercises.Count.ToString();
            EditWorkouts(newWorkouts);

            Exercises.Add(newWorkouts);
            return Exercises;
        }
        //This method lets the user go to an existing exercise, edit it, and save it back to the list.
        public static void EditWorkouts(List<Workouts> Exercises, string path)
        {
            Console.WriteLine("Which workout/exercise would you like to edit?");
            var editItem = Console.ReadLine();
            Workouts tmp = null;

            foreach (Workouts workouts in Exercises)
            {
                if (workouts.Id == editItem)
                {
                    tmp = workouts;
                    break;
                }
            }
            if (tmp == null)
            {
                return;
            }
            Console.WriteLine(tmp);
            EditWorkouts(tmp);
        }
        //This method helps keep my code dry by holding the promts for add and edit in one place.
        public static void EditWorkouts(Workouts newWorkouts)
        {
            Console.WriteLine("Enter type of exercise: (Upper Body, Lower Body, Core Body) ");
            newWorkouts.Type = Console.ReadLine();

            Console.WriteLine("Enter the name of the exercise: ");
            newWorkouts.Name = Console.ReadLine();
        }
        //This method runs at the end and writes the list back to a string to be saved to the CSV to be used next time the app is launched.
        public static void WriteData(string fileName, List<Workouts> Exercises)
        {
            string WorkoutsString = string.Empty;

            foreach (Workouts workouts in Exercises)
            {
                WorkoutsString += workouts.ToString();
            //        //workouts.Id + "," +
            //        workouts.Type + "," +
            //        workouts.Name;
            }
            File.WriteAllText(fileName, WorkoutsString);
        }

    }
}

