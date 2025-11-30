using StarWars.Models;
using System.Runtime.CompilerServices;

namespace StarWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> scores = new Dictionary<string, int>
            {
                { "Tom", 12 },
                { "Elise", 16 },
                { "Ozgun", 17 }
            };

            foreach(string key in scores.Keys)
            {
                int score = scores[key];
                Console.WriteLine(score);
            }




            List<StarWarsCharacter> characters = new List<StarWarsCharacter>()
            {
                new StarWarsCharacter()
                {
                    Name = "Anakin Skywalker",
                    Alliance = "Jedi",
                    Rank = "Jedi Knight",
                    LightSaberColor = "Blue",
                    Quotes = new List<string>
                    {
                        "I see through the lies of the Jedi.",
                        "This is where the fun begins."
                    }
                },
                new StarWarsCharacter()
                {
                    Name = "Obi-Wan Kenobi",
                    Alliance = "Jedi",
                    Rank = "Jedi Master",
                    LightSaberColor = "Blue",
                    Quotes = new List<string>
                    {
                        "I have the high ground.",
                        "Only a Sith deals in absolutes.",
                        "These are not the droids you are looking for."
                    }
                },
                new StarWarsCharacter()
                {
                    Name = "Darth Vader",
                    Alliance = "Sith",
                    Rank = "Sith Lord",
                    LightSaberColor = "Red",
                    Quotes = new List<string>
                    {
                        "I find your lack of faith disturbing.",
                        "You don't know the power of the Dark Side."
                    }
                },
                new StarWarsCharacter()
                {
                    Name = "Yoda",
                    Alliance = "Jedi",
                    Rank = "Grand Master",
                    LightSaberColor = "Green",
                    Quotes = new List<string>
                    {
                        "Do or do not. There is no try.",
                        "Fear is the path to the dark side."
                    }
                },
                new StarWarsCharacter()
                {
                    Name = "Darth Sidious",
                    Alliance = "Sith",
                    Rank = "Emperor",
                    LightSaberColor = "Red",
                    Quotes = new List<string>
                    {
                        "Power! Unlimited power!",
                        "The Dark Side of the Force is a pathway to many abilities some consider to be unnatural."
                    }
                },
                new StarWarsCharacter()
                {
                    Name = "Luke Skywalker",
                    Alliance = "Jedi",
                    Rank = "Jedi Knight",
                    LightSaberColor = "Green",
                    Quotes = new List<string>
                    {
                        "I am a Jedi, like my father before me.",
                        "No one’s ever really gone."
                    }
                },
                new StarWarsCharacter()
                {
                    Name = "Darth Maul",
                    Alliance = "Sith",
                    Rank = "Sith Apprentice",
                    LightSaberColor = "Red",
                    Quotes = new List<string>
                    {
                        "At last, we will reveal ourselves to the Jedi. At last, we will have revenge.",
                        "I was lost, and yet I found purpose again."
                    }
                },
                new StarWarsCharacter()
                {
                    Name = "Qui-Gon Jinn",
                    Alliance = "Jedi",
                    Rank = "Jedi Master",
                    LightSaberColor = "Green",
                    Quotes = new List<string>
                    {
                        "Your focus determines your reality.",
                        "Feel, don’t think. Trust your instincts."
                    }
                }
            };

            int index = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Deel 2 Collections:\n");
                Console.WriteLine(characters[index].DescribeCharacter());
                Console.WriteLine("\nQuotes:");
                characters[index].ShowQuotes();

                Console.WriteLine("\nGebruik de pijltjestoetsen om te navigeren (Links/Rechts), of druk op Escape om af te sluiten.");

                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.RightArrow)
                {
                    index++;
                    if (index >= characters.Count)
                    {
                        index = 0;
                    }
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    index--;
                    if (index < 0)
                    {
                        index = characters.Count - 1;
                    }
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key == ConsoleKey.Add)
                {
                    Console.WriteLine("\nWelke quote wil je toevoegen?");
                    string quote = Console.ReadLine();

                    characters[index].AddQuote(quote);
                }
                else if (key == ConsoleKey.Delete)
                {
                    Console.WriteLine("\nWelke quote wil je verwijderen?");
                    int quoteNumber = int.Parse(Console.ReadLine());

                    characters[index].RemoveQuote(quoteNumber);
                    Console.ReadLine();
                }
                else if (key == ConsoleKey.OemComma)
                {
                    Console.WriteLine("\nWelke quote wil je controleren?");
                    string quote = Console.ReadLine();

                    if (characters[index].KnowsQuote(quote))
                    {
                        Console.WriteLine("Dit komt wel vaker uit zijn mond.");
                    }
                    else
                    {
                        Console.WriteLine("Dit heeft ie nog nooit gezegd!?");
                    }
                    Console.ReadLine();
                }
                else if (key == ConsoleKey.End)
                {
                    characters[index].ForgetAllQuotes();
                }
                else if (key == ConsoleKey.Enter)
                {
                    foreach(StarWarsCharacter sith in FilterSiths(characters))
                    {
                        Console.WriteLine(sith.DescribeCharacter());
                    }
                    Console.ReadLine();
                }
            }
        }

        static List<StarWarsCharacter> FilterSiths(List<StarWarsCharacter> characters)
        {
            List<StarWarsCharacter> filtered = new List<StarWarsCharacter>();

            foreach (StarWarsCharacter character in characters)
            {
                if(character.Alliance.Equals("Sith"))
                {
                    filtered.Add(character);
                }    
            }

            return filtered;
        }
    }
}
