using BroodjesBar.Models;

namespace BroodjesBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Broodje> broodjes = new List<Broodje>();

            Console.WriteLine("--- BROODJESBESTELLING ---");
            Console.WriteLine($"Geldige types: {Broodje.ToonGeldigeTypes()}");
            Console.WriteLine();

            string naam = "";
            while (!string.Equals(naam, "stop", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Geef de naam van het broodje (of 'stop' om te eindigen):");
                naam = Console.ReadLine();

                if (!string.Equals(naam, "stop", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Geef het type:");
                    string type = Console.ReadLine();

                    Console.WriteLine("Geef de prijs:");
                    string prijsInput = Console.ReadLine();

                    if (!decimal.TryParse(prijsInput, out decimal prijs))
                    {
                        Console.WriteLine("Ongeldige prijs, broodje wordt overgeslagen.\n");
                    }
                    else
                    {
                        try
                        {
                            Broodje broodje = new Broodje(naam, type, prijs);
                            broodjes.Add(broodje);
                            Console.WriteLine("Broodje toegevoegd!\n");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Fout: {ex.Message}\n");
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("--- OVERZICHT BROODJES ---");
            foreach (Broodje brood in broodjes)
            {
                Console.WriteLine(brood);
            }

            // Dictionary: omzet per type
            Dictionary<string, decimal> omzetPerType = new Dictionary<string, decimal>();

            foreach (Broodje brood in broodjes)
            {
                if (!omzetPerType.ContainsKey(brood.Type))
                {
                    omzetPerType[brood.Type] = 0m;
                    //omzetPerType.Add(brood.Type, 0m);
                }

                omzetPerType[brood.Type] += brood.Price;
            }

            Console.WriteLine();
            Console.WriteLine("--- OMZET PER TYPE ---");
            foreach (var omzet in omzetPerType)
            {
                //Console.WriteLine($"{omzet.Key}: {omzet.Value:0.00}");
                Console.WriteLine($"{omzet.Key}: {omzet.Value:C2}");
            }

            Console.WriteLine("Druk op ENTER om af te sluiten...");
            Console.ReadLine();
        }
    }
}
