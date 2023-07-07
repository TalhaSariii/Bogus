using System;
using System.Collections.Generic;
using Bogus;

namespace FakeData
{
    public class FakeDataApp
    {
        public List<string> GetNamesList()
        {
            Console.Write("How many names do you want to list: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
            {
                Console.WriteLine("Wrong entry, please enter a valid number.");
                Console.Write("How many names do you want to list: ");
            }

            var faker = new Faker<User>()
                .RuleFor(u => u.FirstName, f => f.Person.FirstName);

            var generatedObject = faker.Generate(count);

            var namesList = new List<string>();
            foreach (var item in generatedObject)
            {
                namesList.Add(item.FirstName);
            }

            return namesList;
        }

        public List<string> GetNamesAndLastNamesList()
        {
            Console.Write("How many names and surnames do you want to list: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
            {
                Console.WriteLine("Wrong entry, please enter a valid number.");
                Console.Write("How many names and surnames do you want to list:");
            }

            var faker = new Faker<User>()
                .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                .RuleFor(u => u.LastName, f => f.Person.LastName);

            var generatedObject = faker.Generate(count);

            var namesList = new List<string>();
            foreach (var item in generatedObject)
            {
                namesList.Add($"{item.FirstName} {item.LastName}");
            }

            return namesList;
        }

        public List<User> GetAllInfoList()
        {
            Console.Write("How many people do you want to list: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
            {
                Console.WriteLine("Wrong entry, please enter a valid number.");
                Console.Write("How many people do you want to list: ");
            }

            var addressFaker = new Faker<Address>()
                .RuleFor(i => i.City, i => i.Address.City())
                .RuleFor(i => i.ZipCode, i => i.Address.ZipCode())
                .RuleFor(i => i.StreetName, i => i.Address.StreetName());

            var userFaker = new Faker<User>()
                .RuleFor(i => i.Address, () => addressFaker.Generate())
                .RuleFor(i => i.Age, i => i.Random.Int(18, 65))
                .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                .RuleFor(i => i.LastName, i => i.Person.LastName)
                .RuleFor(i => i.UserName, (i, j) => i.Internet.UserName(j.FirstName, j.LastName))
                .RuleFor(i => i.Gender, i => i.PickRandom<Gender>())
                .RuleFor(i => i.EmailAddress, i => i.Person.Email)
                .RuleFor(i => i.GenderString, (i, j) => j.Gender == Gender.Male ? "men" : "women");

            var generatedObject = userFaker.Generate(count);

            return generatedObject;
        }
    }
}
