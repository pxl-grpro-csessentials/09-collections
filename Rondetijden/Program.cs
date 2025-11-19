using Rondetijden.Models;

namespace Rondetijden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Atlete[] atletes;
            byte index = 0;
            string name;
            byte time = 0;
            bool stopApplication;
            int numberOfParticipants;

            Console.WriteLine("Rondetijden");
            do
            {
                Console.Write("Geef aantal deelnemers: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfParticipants));

            atletes = new Atlete[numberOfParticipants];

            stopApplication = false;

            for (int i = 0; i < numberOfParticipants && !stopApplication; i++)
            {
                do
                {
                    Console.WriteLine();
                    Console.Write($"Geef naam atleet {index + 1}: ");
                    name = Console.ReadLine();
                    if (string.Equals(name, "STOP", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Bent u zeker dat u wil stoppen (J/N)? ");
                        stopApplication = Console.ReadLine().ToUpper() == "J";
                    }
                } while (!stopApplication && string.Equals(name, "STOP", StringComparison.OrdinalIgnoreCase));

                if (!stopApplication)
                {
                    do
                    {
                        try
                        {
                            do
                            {
                                Console.Write($"Geef rondetijd atleet {index + 1}: ");
                            } while (!byte.TryParse(Console.ReadLine(), out time));
                            if (time == 0)
                            {
                                Console.Write("Bent u zeker dat u wil stoppen (J/N)? ");
                                stopApplication = Console.ReadLine().ToUpper() == "J";
                            }
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Getal is te groot!");
                            Console.ResetColor();
                        }
                    } while (!stopApplication && time == 0);

                    if (!stopApplication)
                    {
                        atletes[index] = new Atlete();
                        atletes[index].Name = name;
                        atletes[index].Time = time;
                        index++;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("OVERZICHT");
            Console.WriteLine("=========");
            for (int i = 0; i < numberOfParticipants; i++)
            {
                //if (_atletes[i] is not null)
                //{
                Console.WriteLine($"Atleet {i + 1} is {atletes[i].Name} met tijd {atletes[i].Time}.");
                //}
            }
        }
    }
}
