using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UNOPS.Entity;

namespace UNOPS.Service
{
    public class PersonService
    {
        public static List<PersonEntity> GetPeople()
        {
            List<PersonEntity> people = new();
            string filePath = GetPath();
            string myJsonString = File.ReadAllText(filePath);
            people = JsonConvert.DeserializeObject<List<PersonEntity>>(myJsonString);

            return people;
        }

        public static void PrintPeople(ICollection<PersonEntity> people)
        {
            Console.WriteLine("P E O P L E");

            if (people.Count == 0)
            {
                Console.WriteLine($"No records found.");
            }

            _ = people.Select(p =>
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
                return p;
            }
            ).ToList();
        }

        private static string GetPath()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath + @"peopledata.json";
        }

    }
}
