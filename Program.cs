namespace Cast_The_Dice;

class Program
{
    static void Main()
    {
        // Aktiverar stöd för UTF-8 så emojis/specialtecken visas korrekt i konsolen
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        WelcomeMessage();
        ShowMenu();
        // Initierar slumptalsgenerator utanför loopen för att få unika kast var
        var rnd = new Random();

        while (true)
        {
            int dice1 = rnd.Next(1, 7);
            int dice2 = rnd.Next(1, 7);

            //Läser knapptryckning utan att visa tecknet på skärmen
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                // Fejk-laddning som simulerar känslan av att tärningarna rullar.
                case ConsoleKey.Spacebar:
                    Console.Write("Kastar tärningarna [");
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(100);
                    }
                    Console.WriteLine("]");
                    Console.WriteLine("─────────────────────────");



                    Console.WriteLine($"🎲 {dice1}");
                    Console.WriteLine($"🎲 {dice1}");

                    break;

                case ConsoleKey.X:

                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{key} är inte ett giltigt val!");
                    Console.ResetColor();
                    ShowMenu();
                    continue;
            }



            if (dice1 + dice2 == 12)
            {
                Console.WriteLine("─────────────────────────");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Grattis 🥳 Du har vunnit!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("─────────────────────────");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Försök igen!");
                Console.ResetColor();
                ShowMenu();
            }
        }
    }

    // ASCII-art - varför inte...
    static void WelcomeMessage()
    {
        Console.Write(@"

       ·  ·  ─────────────────────═══[ SO NICE ]═══─────────────────────  ·  ·

 _________   ___________   ________  ________   ____  ________________
  / ____/   | / ___/_  __/  /_  __/ / / / ____/  / __ \/  _/ ____/ ____/
 / /   / /| | \__ \ / /      / / / /_/ / __/    / / / // // /   / __/
/ /___/ ___ |___/ // /      / / / __  / /___   / /_/ // // /___/ /___
\____/_/  |_/____//_/      /_/ /_/ /_/_____/  /_____/___/\____/_____/

       ·  ·  ───────────────────────────────────────────────────────────  ·  ·

Reglerna är enkla: Kasta tärningarna tills båda landar på 6..

");
    }
    static void ShowMenu()
    {
        Console.WriteLine("─────────────────────────");
        Console.WriteLine("[Space] Kasta [X] Avsluta");
        Console.WriteLine("─────────────────────────");
    }
}