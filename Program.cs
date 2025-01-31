class Program
{
    static void Main()
    {
        Console.WriteLine("Choose an option: ");
        Console.WriteLine("1. Display Characters");
        Console.WriteLine("2. Add Character");
        Console.WriteLine("3. Level Up Character");

        var menuChoice = Console.ReadLine();

        if (menuChoice == "1")
        {
            ListCharacters();
        }

        if (menuChoice == "2")
        {
            Console.Write("Enter your character's name: ");
            string addedName = Console.ReadLine();

            Console.Write("Enter your character's class: ");
            string characterClass = Console.ReadLine();

            Console.Write("Enter your character's level: ");
            int level = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's hit points: ");
            int hitpoints = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's equipment (separate items with a '|'): ");
            string[] equipment = Console.ReadLine().Split('|');

            Console.WriteLine($"Welcome, {addedName} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", equipment)}.");

            using (StreamWriter writer = new StreamWriter("input.csv" , true))
            {
                writer.WriteLine($"{addedName},{characterClass},{level},{hitpoints},{equipment}");
            }
        }

        if (menuChoice == "3")
        {
            int timesLeveled = 0;

            ListCharacters();

            Console.Write("Enter your character's name: ");
            string? chosenCharacter = Console.ReadLine();


        }

    }

    public static void ListCharacters()
    {
        var lines = File.ReadAllLines("input.csv");

        for (int i = 0; i < lines.Length; i++)
        {
            var cols = lines[i].Split(',');

            var name = cols[0];
            var profession = cols[1];
            var level = cols[2];
            var hitpoints = cols[3];
            var equipment = cols[4];

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Job: {profession}");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Hit Points: {hitpoints}");
            Console.WriteLine($"Equipment: {equipment}");
        }
    }
}