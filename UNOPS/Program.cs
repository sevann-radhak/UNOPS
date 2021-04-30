using System;
using System.Collections.Generic;
using UNOPS.Entity;
using UNOPS.Service;

namespace UNOPS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonEntity> people = new();
            people = PersonService.GetPeople();
            PersonService.PrintPeople(people);
        }
    }
}
