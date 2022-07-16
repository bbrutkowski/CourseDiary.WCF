using System;
using System.Collections.Generic;

namespace CourseDiary.Wcf.Client
{
    public class Interactions
    {
        public string GetInfoFromUser(string message)
        {
            Console.Write($"{message}: ");
            return Console.ReadLine();
        }

        public int GetIntFromUser(string message)
        {
            int result = 0;
            bool success = false;

            while (!success)
            {
                string text = GetInfoFromUser(message);
                success = int.TryParse(text, out result);

                if (!success)
                {
                    Console.WriteLine("Not a number. Try again...");
                }
            }

            return result;
        }

        public DateTime GetDateFromUser(string message)
        {
            Console.WriteLine(message);
            string line = Console.ReadLine();
            DateTime data;
            while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data))
            {
                Console.WriteLine("Invalid date, please retry");
                line = Console.ReadLine();
            }

            return data;
        }

        public List<int> GetStudentIds()
        {
            List<int> idList = new List<int>();
            bool exit = false;
            while (!exit)
            {
                switch (GetInfoFromUser("Choose(Add/Exit): "))
                {
                    case "Add":
                        idList.Add(GetIntFromUser("Choose student id you wish to add(Student amount must be between 5 and 20): "));
                        break;
                    case "Exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong option!");
                        break;
                }
            }

            return idList;
        }
    }
}
