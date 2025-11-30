using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace Crypto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> portfolio = new Dictionary<string, decimal>()
            {
                { "BTC", 0.5M },
                { "ETH", 2M },
                { "SOL", 10M }
            };

            PrintPortfolio(portfolio);

            portfolio.Add("DOG", 1M);
            if(!portfolio.TryAdd("BTC", 1.5M))
            {
                Console.WriteLine("Deze coin bestaat al");
            }

            PrintPortfolio(portfolio);

            portfolio["BTC"] = 2M;
            portfolio["WIM"] = 5M; //Doet eigenlijk een Add()

            PrintPortfolio(portfolio);

            Console.WriteLine("Welke coin wil je opvragen?");
            string coin = Console.ReadLine();

            try
            {
                decimal value = portfolio[coin];
                Console.WriteLine($"Je hebt {value} munten van {coin}");
            }
            catch (KeyNotFoundException knfe)
            {
                Console.WriteLine($"Deze coin zit niet in je portfolio");
            }

            if(portfolio.ContainsKey(coin))
            {
                decimal value = portfolio[coin];
                Console.WriteLine($"Je hebt {value} munten van {coin}");
            }
            else
            {
                Console.WriteLine("Deze coin zit niet in je portfolio.");
            }

            if(portfolio.TryGetValue(coin, out decimal outValue))
            {
                Console.WriteLine($"Je hebt {outValue} munten van {coin}");
            }
            else
            {
                Console.WriteLine("Deze coin zit niet in je portfolio.");
            }

            Console.WriteLine("Welke coin wil je verwijderen?");
            string coinToRemove = Console.ReadLine();

            if(!portfolio.Remove(coinToRemove))
            {
                Console.WriteLine("Deze coin zit niet in je portfolio.");
            }

            PrintPortfolio(portfolio);
        }

        static void PrintPortfolio(Dictionary<string, decimal> crypto)
        {
            //foreach(KeyValuePair<string, decimal> element in crypto)
            //{
            //    Console.WriteLine(element.Key);
            //    Console.WriteLine(element.Value);
            //}

            foreach(string key in crypto.Keys)
            {
                //decimal value = crypto[key];
                Console.WriteLine($"{key}: {crypto[key]}");
            }

            Console.ReadLine();
        }
    }
}
