using System.Reflection.Emit;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        //Display Options
        Console.WriteLine("Choose an option: ");
        Console.WriteLine("1. Display Characters");
        Console.WriteLine("2. Add Character");
        Console.WriteLine("3. Level Up Character");

        //User Select Option
        var menuChoice = Console.ReadLine();

        //List the characters
        if (menuChoice == "1")
        {
            //Use the listCharacters function
            ListCharacters();
        }

        //Adding a character
        if (menuChoice == "2")
        {
            //Geting user info
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

            //Display entered information back to the user
            Console.WriteLine($"Welcome, {addedName} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", equipment)}.");

            //Write entered information into the csv
            using (StreamWriter writer = new StreamWriter("input.csv" , true))
            {
                writer.WriteLine($"{addedName},{characterClass},{level},{hitpoints},{equipment}");
            }
        }

        //leveling up a character
        if (menuChoice == "3")
        {
            //listing characters to choose from
            ListCharacters();

            //selecting character
            Console.Write("Enter the character's name that would like to level up: ");
            string chosenCharacter = Console.ReadLine();

            var lines = File.ReadAllLines("input.csv");

            //creating list to store info while it's being updated
            List<string> updatedLines = new List<string>();

            //running through each line in the csv
            for (int i = 0; i < lines.Length; i++)
            {
                var cols = lines[i].Split(',');

                var name = cols[0];
                var profession = cols[1];
                var level = int.Parse(cols[2]);
                var hitpoints = cols[3];
                var equipment = cols[4];

                //checking if the character name per row is the same as the selected character
                if (name == chosenCharacter)
                {
                    //incrementing the character's level if it's the same
                    level += 1;
                }

                //pushing the existing/updated lines to the new list
                updatedLines.Add($"{name},{profession},{level},{hitpoints},{equipment}");
            }

            //write our new list over to the existing csv and replacing all lines
            using (StreamWriter writer = new StreamWriter("input.csv", false))
            {
                for (int i = 0; i < updatedLines.Count; i++)
                {
                    writer.WriteLine(updatedLines[i]);
                }
            }

            //display csv to show updated/existing characters
            ListCharacters();
        }

    }

    //create ListCharacters to be used elsewhere in the code
    public static void ListCharacters()
    {
        //read all the lines of the csv
        var lines = File.ReadAllLines("input.csv");

        //for each line, split each by a comma and output the values for the user
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
            Console.WriteLine("--------------------------------");
        }
    }
}