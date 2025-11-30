using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Models
{
    internal class StarWarsCharacter
    {
        public string Name { get; set; }
        public string Alliance { get; set; }
        public string Rank { get; set; }
        public string LightSaberColor { get; set; }
        public List<string> Quotes { get; set; }

        public string DescribeCharacter()
        {
            return $"{this.Name} - {this.Alliance}: a {this.Rank} that has a {this.LightSaberColor} lightsaber.";
        }

        public void ShowQuotes()
        {
            foreach (string quote in Quotes)
            {
                Console.WriteLine(quote);
            }
        }

        public void AddQuote(string quote)
        {
            this.Quotes.Add(quote);
        }

        public void RemoveQuote(int quoteNumber)
        {
            if (quoteNumber >= 0 && quoteNumber < this.Quotes.Count)
            {
                this.Quotes.RemoveAt(quoteNumber);
            }
            else
            {
                Console.WriteLine("Deze quote bestaat niet.");
            }

            //try
            //{
            //    this.Quotes.RemoveAt(quoteNumber);
            //}
            //catch (IndexOutOfRangeException ex)
            //{
            //    Console.WriteLine("Deze quote bestaat niet.");
            //}
        }

        //public void RemoveQuote(string quote)
        //{
        //    if(!this.Quotes.Remove(quote))
        //    {
        //        Console.WriteLine("Deze quote bestaat niet.");
        //    }
        //}

        public bool KnowsQuote(string quote)
        {
            return this.Quotes.Contains(quote);
        }

        public void ForgetAllQuotes()
        {
            this.Quotes.Clear();
        }

    }
}
