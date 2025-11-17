using System.Diagnostics.Metrics;

namespace SimonSays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] colors = { "rood", "groen", "blauw", "geel" };
            string[] range = new string[10]; //Max 10, daarna is spel gewonnen
            int rangeLength = 0;

            Random random = new Random();

            Console.WriteLine("Welkom bij Simon Says!");
            Console.WriteLine("Onthoud de reeks kleuren en typ ze daarna in.");
            Console.WriteLine("Mogelijke kleuren: rood, groen, blauw, geel");
            Console.WriteLine("Druk op ENTER om te starten...");
            Console.ReadLine();

            bool stilInGame = true;

            while (stilInGame)
            {
                // 1. Ronde voorbereiden
                // Nieuwe kleur toevoegen
                int randomIndex = random.Next(0, colors.Length);
                range[rangeLength] = colors[randomIndex];
                rangeLength++;

                Console.Clear();
                Console.WriteLine($"Ronde {rangeLength}");

                // 2. Kleur tonen
                Console.Write($"Kleur: {colors[randomIndex]}");
                Console.WriteLine();
                Console.WriteLine("Typ de reeks kleuren, gescheiden door spaties:");

                // 3. Invoer van speler
                string input = Console.ReadLine();
                string[] inputRange = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // 4. Controle: eerst lengte
                if (inputRange.Length != rangeLength)
                {
                    Console.WriteLine("FOUT! Verkeerd aantal kleuren.");
                    Console.WriteLine($"Je haalde ronde {rangeLength - 1}.");
                    stilInGame = false;
                }
                else
                {
                    bool allCorrect = true;
                    for (int i = 0; i < rangeLength; i++)
                    {
                        if (!inputRange[i].Equals(range[i], StringComparison.OrdinalIgnoreCase))
                        {
                            allCorrect = false;
                            break;
                        }
                    }

                    if (!allCorrect)
                    {
                        Console.WriteLine("FOUT! Eén of meer kleuren waren verkeerd.");
                        Console.WriteLine($"Je haalde ronde {rangeLength - 1}.");
                        stilInGame = false;
                    }
                    else
                    {
                        stilInGame = rangeLength < range.Length;
                        Console.WriteLine("Correct! Op naar de volgende ronde.");
                        Console.WriteLine("Druk op ENTER voor de volgende ronde...");
                        Console.ReadLine();
                    }
                }
            }

            if (rangeLength >= range.Length)
            {
                Console.Write("Proficiat, je hebt het spel volledig uitgespeeld!");
            }
            else
            {
                Console.Write("Game over.");
            }
            Console.WriteLine(" Druk op ENTER om af te sluiten.");
            Console.ReadLine();
        }
    }
}
