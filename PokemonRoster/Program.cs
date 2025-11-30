using PokemonRoster.Models;

namespace PokemonRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pokemon[] pokemons = new Pokemon[6];

                pokemons[0] = new Pokemon()
                {
                    Name = "Pikachu",
                    Level = 1,
                    Type = "Energy"
                };

                pokemons[1] = new Pokemon();
                pokemons[1].Name = "Bulbasaur";
                pokemons[1].Level = 2;
                pokemons[1].Type = "Water";

                pokemons[2] = new Pokemon()
                {
                    Name = "Charmander",
                    Level = 3,
                    Type = "Fire"
                };

                pokemons[3] = new Pokemon()
                {
                    Name = "Squirtle",
                    Level = 4,
                    Type = "Water"
                };


                Pokemon firstPokemon = pokemons[0];
                Console.WriteLine(firstPokemon);
                //Console.WriteLine(pokemons[0]);

                //Verwijder pokemon op index 3
                Array.Clear(pokemons, 3, 1);
                //pokemons[3] = null;

                PrintPokemonRoster(pokemons);

                Console.WriteLine("Is lengte 6? " + IsValidPokemonRosterSize(pokemons));

                Pokemon[] pokemons2 = new Pokemon[]
                {
                    new Pokemon() { Name = "Pikachu", Level = 1, Type = "Energy" },
                    new Pokemon() { Name = "Charmander", Level = 1, Type = "Fire" },
                    new Pokemon() { Name = "Eevee", Level = 1, Type = "Fairy" },
                };

                PrintPokemonRoster(pokemons2);


                Trainer trainer1 = new Trainer()
                {
                    Name = "Wim Bervoets",
                    Pokemons = pokemons,
                };

                Trainer trainer2 = new Trainer()
                {
                    Name = "Ash",
                    Pokemons = pokemons2,
                };

                Pokemon temp = trainer1.Pokemons[0];
                trainer1.Pokemons[0] = trainer2.Pokemons[0];
                trainer2.Pokemons[0] = temp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void PrintPokemonRoster(Pokemon[] pokemons)
        {
            foreach(Pokemon element in pokemons)
            {
                Console.WriteLine(element);
            }
        }

        static bool IsValidPokemonRosterSize(Pokemon[] pokemons)
        {
            return pokemons.Length == 6;
        }


        //static void Main(string[] args)
        //{
        //    string[] pokemons = new string[6];
        //    pokemons[0] = "Pikachu";
        //    pokemons[1] = "Bulbasaur";
        //    pokemons[2] = "Charmander";
        //    pokemons[3] = "Squirtle";

        //    Console.WriteLine(pokemons[0]);

        //    Array.Clear(pokemons, 3, 1);

        //    PrintPokemonRoster(pokemons);

        //    Console.WriteLine($"Lengte is 6? {IsValidPokemonRosterSize(pokemons)}");

        //    string[] secondRoster = { "Eevee", "Lopunny" };
        //}

        //static void PrintPokemonRoster(string[] pokemons)
        //{
        //    for (int index = 0; index < pokemons.Length; index++)
        //    {
        //        Console.WriteLine(pokemons[index]);
        //    }
        //}

        //static bool IsValidPokemonRosterSize(string[] pokemons)
        //{
        //    return pokemons.Length == 6;
        //    //if (pokemons.Length == 6)
        //    //{
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    return false;
        //    //}
        //}
    }
}
