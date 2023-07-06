using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Bogus;

namespace FakeData
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Only Names");
            Console.WriteLine("2. Names and Last Names");
            Console.WriteLine("3. All İnformation");
            Console.WriteLine("0. Exit");
            Console.WriteLine();

            int choice=1;
            while (choice != 0) 
            {
                Console.Write("Make your choice: ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Wrong entry,please enter a valid number.");
                    Console.Write("Make your choice: ");
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    case 1:
                        ListNames();
                        break;
                    case 2:
                        ListNamesAndLastNames();
                        break;
                    case 3:
                        ListAllInfo();
                        break;
                    default:
                        Console.WriteLine("Wrong entry,please enter a valid number.");
                        break;
                }

                Console.WriteLine();
            } 
        }

        static void ListNames()
        {
            Console.Write("How many names do you want to list: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
            {
                Console.WriteLine("Wrong entry,please enter a valid number.");
                Console.Write("How many names do you want to list: ");
            }

            var faker = new Faker<User>()
                .RuleFor(u => u.FirstName, f => f.Person.FirstName);

            var generatedObject = faker.Generate(count);

            foreach (var item in generatedObject)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        static void ListNamesAndLastNames()
        {
            Console.Write("How many names and surnames do you want to list: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
            {
                Console.WriteLine("Wrong entry,please enter a valid number.");
                Console.Write("How many names and surnames do you want to list:");
            }

            var faker = new Faker<User>()
                .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                .RuleFor(u => u.LastName, f => f.Person.LastName);

            var generatedObject = faker.Generate(count);

            foreach (var item in generatedObject)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }

        static void ListAllInfo()
        {
            Console.Write("how many people do you want to list: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
            {
                Console.WriteLine("Wrong entry,please enter a valid number.");
                Console.Write("how many people do you want to list: ");
            }

            var addressFaker = new Faker<Address>()
                .RuleFor(i => i.City, i => i.Address.City())
                .RuleFor(i => i.StreetNmae, i => i.Address.StreetName())
                .RuleFor(i => i.ZipCode, i => i.Address.ZipCode());

            var userFaker = new Faker<User>()
                .RuleFor(i => i.Address, i => addressFaker)
                .RuleFor(i => i.Age, i => i.Random.Int(18, 65))
                .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                .RuleFor(i => i.LastName, i => i.Person.LastName)
                .RuleFor(i => i.UserName, (i, j) => i.Internet.UserName(j.FirstName, j.LastName))
                .RuleFor(i => i.Gender, i => i.PickRandom<Gender>())
                .RuleFor(i => i.EmailAddress, i => i.Person.Email)
                .RuleFor(i => i.GenderString, (i, j) => j.Gender == Gender.Male ? "men" : "women"); 

            var generatedObject = userFaker.Generate(count);

            foreach (var item in generatedObject)
            {
                Console.WriteLine($"Name: {item.FirstName}");
                Console.WriteLine($"Last Name: {item.LastName}");
                Console.WriteLine($"Age: {item.Age}");
                Console.WriteLine($"UserName: {item.UserName}");
                Console.WriteLine($"Email: {item.EmailAddress}");
                Console.WriteLine($"Gender: {item.GenderString}");
                Console.WriteLine($"City: {item.Address.City}");
                Console.WriteLine($"Zip Code: {item.Address.ZipCode}");
                Console.WriteLine($"Street Name: {item.Address.StreetNmae}");
                Console.WriteLine();
            }
        }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class User
    {
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }
        public Gender Gender { get; set; }
        public string? GenderString { get; set; } 
        public Address? Address { get; set; }
    }

    public class Address
    {
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? StreetNmae { get; set; }
    }
}