using System;
using System.Collections.Generic;
using Bogus;


public class FakeDataApp
{
    private List<User> allList = new List<User>();

    public void ListNames()
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

        foreach (var item in generatedObject)
        {
            Console.WriteLine(item.FirstName);
        }

        allList.AddRange(generatedObject);
    }

    public void ListNamesAndLastNames()
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

        foreach (var item in generatedObject)
        {
            Console.WriteLine($"{item.FirstName} {item.LastName}");
        }

        allList.AddRange(generatedObject);
    }

    public void ListAllInfo()
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

        allList.AddRange(generatedObject);
    }
}