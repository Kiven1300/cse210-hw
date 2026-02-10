using System;

class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("  Welcome to the Mindfulness Program");
        Console.WriteLine($"  {DateTime.Now:dddd, MMMM dd, yyyy}");
        Console.WriteLine("========================================\n");
        System.Threading.Thread.Sleep(2000);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            
            int totalActivities = breathingCount + reflectingCount + listingCount;
            if (totalActivities > 0)
            {
                Console.WriteLine($"\n--- Activities completed this session: {totalActivities} ---");
                Console.WriteLine($"    Breathing: {breathingCount} | Reflecting: {reflectingCount} | Listing: {listingCount}");
            }
            
            Console.Write("\nSelect a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                listingCount++;
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("\n========================================");
                Console.WriteLine("  Thank you for using Mindfulness!");
                Console.WriteLine($"  Total activities completed: {totalActivities}");
                Console.WriteLine("========================================\n");
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please try again.");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
