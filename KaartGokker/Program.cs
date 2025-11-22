using KaartGokker.Models;
using System.ComponentModel.Design.Serialization;
using System.Security.Principal;
using System.Text;

namespace KaartGokker
{
    internal class Program
    {
        static List<Card> _cardDeck = new List<Card>()
        {
            new Card(){ Color="Rood", Name = "Harten 1"},
            new Card(){ Color="Rood", Name = "Harten 1" },
            new Card(){ Color="Rood", Name = "Harten 2" },
            new Card(){ Color="Rood", Name = "Harten 3" },
            new Card(){ Color="Rood", Name = "Harten 4" },
            new Card(){ Color="Rood", Name = "Harten 5" },
            new Card(){ Color="Rood", Name = "Harten 6" },
            new Card(){ Color="Rood", Name = "Harten 7" },
            new Card(){ Color="Rood", Name = "Harten 8" },
            new Card(){ Color="Rood", Name = "Harten 9" },
            new Card(){ Color="Rood", Name = "Harten 10" },
            new Card(){ Color="Rood", Name = "Harten boer" },
            new Card(){ Color="Rood", Name = "Harten dame" },
            new Card(){ Color="Rood", Name = "Harten heer" },
            new Card(){ Color="Rood", Name = "Ruiten 1" },
            new Card(){ Color="Rood", Name = "Ruiten 2" },
            new Card(){ Color="Rood", Name = "Ruiten 3" },
            new Card(){ Color="Rood", Name = "Ruiten 4" },
            new Card(){ Color="Rood", Name = "Ruiten 5" },
            new Card(){ Color="Rood", Name = "Ruiten 6" },
            new Card(){ Color="Rood", Name = "Ruiten 7" },
            new Card(){ Color="Rood", Name = "Ruiten 8" },
            new Card(){ Color="Rood", Name = "Ruiten 9" },
            new Card(){ Color="Rood", Name = "Ruiten 10" },
            new Card(){ Color="Rood", Name = "Ruiten boer" },
            new Card(){ Color="Rood", Name = "Ruiten dame" },
            new Card(){ Color="Rood", Name = "Ruiten heer" },
            new Card(){ Color="Zwart", Name = "Schuppen 1" },
            new Card(){ Color="Zwart", Name = "Schuppen 2" },
            new Card(){ Color="Zwart", Name = "Schuppen 3" },
            new Card(){ Color="Zwart", Name = "Schuppen 4" },
            new Card(){ Color="Zwart", Name = "Schuppen 5" },
            new Card(){ Color="Zwart", Name = "Schuppen 6" },
            new Card(){ Color="Zwart", Name = "Schuppen 7" },
            new Card(){ Color="Zwart", Name = "Schuppen 8" },
            new Card(){ Color="Zwart", Name = "Schuppen 9" },
            new Card(){ Color="Zwart", Name = "Schuppen 10" },
            new Card(){ Color="Zwart", Name = "Schuppen boer" },
            new Card(){ Color="Zwart", Name = "Schuppen dame" },
            new Card(){ Color="Zwart", Name = "Schuppen heer" },
            new Card(){ Color="Zwart", Name = "Klaveren 1" },
            new Card(){ Color="Zwart", Name = "Klaveren 2" },
            new Card(){ Color="Zwart", Name = "Klaveren 3" },
            new Card(){ Color="Zwart", Name = "Klaveren 4" },
            new Card(){ Color="Zwart", Name = "Klaveren 5" },
            new Card(){ Color="Zwart", Name = "Klaveren 6" },
            new Card(){ Color="Zwart", Name = "Klaveren 7" },
            new Card(){ Color="Zwart", Name = "Klaveren 8" },
            new Card(){ Color="Zwart", Name = "Klaveren 9" },
            new Card(){ Color="Zwart", Name = "Klaveren 10" },
            new Card(){ Color="Zwart", Name = "Klaveren boer" },
            new Card(){ Color="Zwart", Name = "Klaveren dame" },
            new Card(){ Color="Zwart", Name = "Klaveren heer" }
        };

        static Dictionary<Card, int> _pulledCards = new Dictionary<Card, int>();

        static Dictionary<string, string> _cardColors = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Harten", "Rood" },
            { "Koeken", "Rood" },
            { "Ruiten", "Zwart" },
            { "Klaveren", "Zwart" }
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int credits = 1000;
            //int stake = 0;
            //do
            //{
            //    try
            //    {
            //        stake = GetStake(credits);
            //    }
            //    catch (ArgumentOutOfRangeException ex)
            //    {
            //        ShowError(ex);
            //    }
            //} while (stake == 0);
            do
            {
                int stake = GetStake(credits);
                credits = PullCard(GetCardChoice(), credits, stake);
            } while (credits > 0);
        }

        //static void ShowError(Exception exception)
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    if(exception is ArgumentOutOfRangeException)
        //    {
        //        Console.WriteLine(((ArgumentOutOfRangeException)exception).ParamName);
        //    }
        //    else
        //    { 
        //        Console.WriteLine(exception.Message);
        //    }
        //    Console.ResetColor();
        //}

        static int GetStake(int credits)
        {
            int stake;
            Console.WriteLine();
            do
            {
                do
                {
                    Console.Write($"Je hebt {credits:c2}, hoeveel zet je in? ");
                } while (!int.TryParse(Console.ReadLine(), out stake));
                if (stake > credits)
                {
                    //throw new ArgumentOutOfRangeException($"Je zet {stake:c2} in, maar hebt maar {credits:c2}!");
                    Console.WriteLine($"Je zet {stake:c2} in, maar hebt maar {credits:c2}!");
                }
            } while (stake > credits);
            return stake;
        }

        static string GetCardChoice()
        {
            string input;
            Console.WriteLine();
            StringBuilder sb  = new StringBuilder();
            sb.Append("Kies een kleur (");
            foreach (var card in _cardColors.Keys)
            {
                sb.AppendFormat($"{card}, ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("): ");
            do
            {
                Console.Write(sb.ToString());
                input = Console.ReadLine();
            } while (!_cardColors.Keys.Contains(input));
            return _cardColors[input];
        }

        static int PullCard(string cardChoice, int credits, int stake)
        {
            Random rnd = new Random();
            int idx = rnd.Next(0, _cardDeck.Count);

            var card = _cardDeck[idx];

            int difference;
            bool hasWon = string.Equals(cardChoice, card.Color, StringComparison.OrdinalIgnoreCase);
            if (hasWon)
            {
                difference = 2 * stake;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                difference = -stake;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            credits += difference;
            _pulledCards.Add(card, difference);
            _cardDeck.RemoveAt(idx);
            Console.WriteLine($"{card.Name} is getrokken met kleur {card.Color}. Je {(hasWon ? "wint" : "verliest")} {stake:c2}.");
            Console.ResetColor();
            ShowHistory();
            return credits;
        }

        static void ShowHistory()
        {
            Console.WriteLine();
            Console.WriteLine("HISTORIEK");
            foreach (var pulledCard in _pulledCards)
            {
                Console.ForegroundColor = pulledCard.Value < 0 ? ConsoleColor.Red : ConsoleColor.Green;
                Console.WriteLine($"{pulledCard.Key.Name}: {pulledCard.Value}");
            }
            Console.ResetColor();
        }
    }
}
