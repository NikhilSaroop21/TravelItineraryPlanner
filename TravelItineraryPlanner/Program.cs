using System;

namespace TravelItineraryPlanner
{
    internal static class Program
    {
        private static readonly CustomArray<Destination> _itinerary = new();

        private static void Main()
        {
            Console.Title = "Travel Itinerary Planner (Custom Array)";
            while (true)
            {
                PrintMenu();
                Console.Write("Select an option: ");
                var input = Console.ReadLine()?.Trim();

                switch (input)
                {
                    case "1":
                        AddDestination();
                        break;
                    case "2":
                        ListDestinations();
                        break;
                    case "3":
                        SearchByName();
                        break;
                    case "4":
                        RemoveByName();
                        break;
                    case "5":
                        DemoGenericWithInts();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Pause();
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Travel Itinerary Planner ===");
            Console.WriteLine("1) Add destination");
            Console.WriteLine("2) List destinations");
            Console.WriteLine("3) Search destination by name");
            Console.WriteLine("4) Remove destination by name");
            Console.WriteLine("5) Demo: use CustomArray<int>");
            Console.WriteLine("0) Exit");
            Console.WriteLine();
        }

        private static void AddDestination()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? string.Empty;

            Console.Write("Country: ");
            var country = Console.ReadLine() ?? string.Empty;

            Console.Write("Description: ");
            var desc = Console.ReadLine() ?? string.Empty;

            var dest = new Destination(name, country, desc);
            _itinerary.Add(dest);
            Console.WriteLine("Added.");
        }

        private static void ListDestinations()
        {
            Console.WriteLine("--- Current Itinerary ---");
            _itinerary.Output();
        }

        private static void SearchByName()
        {
            Console.Write("Enter name to search: ");
            var name = (Console.ReadLine() ?? string.Empty).Trim();

            var found = _itinerary.Find(d =>
                d is not null &&
                d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (found is null)
                Console.WriteLine("No match found.");
            else
                Console.WriteLine($"Found: {found}");
        }

        private static void RemoveByName()
        {
            Console.Write("Enter name to remove: ");
            var name = (Console.ReadLine() ?? string.Empty).Trim();

            // Build a temp destination with only Name+Country if you want a stricter match,
            // but here we’ll remove by name regardless of country:
            int indexToRemove = -1;
            for (int i = 0; i < _itinerary.Count; i++)
            {
                var item = _itinerary[i];
                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                var removed = _itinerary[indexToRemove];
                _itinerary.RemoveAt(indexToRemove);
                Console.WriteLine($"Removed: {removed}");
            }
            else
            {
                Console.WriteLine("No destination with that name was found.");
            }
        }

        private static void DemoGenericWithInts()
        {
            var nums = new CustomArray<int>(2);
            nums.Add(10);
            nums.Add(20);
            nums.Add(30); // triggers resize
            Console.WriteLine($"Count={nums.Count}, Capacity={nums.Capacity}");
            nums.Output();

            Console.WriteLine("Contains 20? " + nums.Contains(20));
            nums.Remove(20);
            Console.WriteLine("After removing 20:");
            nums.Output();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
        }
    }
}
