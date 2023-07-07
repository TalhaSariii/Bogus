using System;

namespace FakeData
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fakeDataApp = new FakeDataApp();

            Console.WriteLine("1. Only Names");
            Console.WriteLine("2. Names and Last Names");
            Console.WriteLine("3. All Information");
            Console.WriteLine("0. Exit");
            Console.WriteLine();

            int choice = 1;
            while (choice != 0)
            {
                Console.Write("Make your choice: ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Wrong entry, please enter a valid number.");
                    Console.Write("Make your choice: ");
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    case 1:
                        var namesList = fakeDataApp.GetNamesList();
                        DisplayList(namesList);
                        break;
                    case 2:
                        var namesAndLastNamesList = fakeDataApp.GetNamesAndLastNamesList();
                        DisplayList(namesAndLastNamesList);
                        break;
                    case 3:
                        var allInfoList = fakeDataApp.GetAllInfoList();
                        DisplayList(allInfoList);
                        break;
                    default:
                        Console.WriteLine("Wrong entry, please enter a valid number.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void DisplayList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine("\n"+item);
            }
        }
    }
}
