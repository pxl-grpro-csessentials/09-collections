using Rondetijden.Models;

namespace Rondetijden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            byte time = 0;
            string fastestName = "";
            int fastestTime = int.MaxValue;
            int hours;
            int minutes;
            int seconds;
            List<Atlete> atletes = new List<Atlete>();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Snelste atleet");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.WriteLine();
                Console.Write("Naam atleet: ");
                name = Console.ReadLine();
                if (name != "STOP")
                {
                    do
                    {
                        Console.Write("Looptijd: ");
                    } while (!byte.TryParse(Console.ReadLine(), out time));
                    if (time != 0)
                    {
                        atletes.Add(new Atlete() { Name = name, Time = time });
                    }
                }
            } while (name != "STOP" && time != 0);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Overzicht rondetijden");
            atletes.Sort((x, y) => x.Time.CompareTo(y.Time));
            foreach (Atlete atlete in atletes)
            {
                Console.WriteLine($"{atlete.Name,-10} {atlete.Time} seconden");
            }
        }
    }
}
