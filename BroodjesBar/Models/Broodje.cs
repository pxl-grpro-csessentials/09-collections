using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroodjesBar.Models
{
    internal class Broodje
    {
        private static readonly string[] _allowedTypes = { "warm", "koud", "veggie", "speciaal" };
        public string Name { get; set; }
        public decimal Price { get; set; }
        private string _type;

        public string Type
        {
            get { return _type; }
            set
            {
                if (!_allowedTypes.Contains(value))
                {
                    throw new ArgumentException(
                        $"Ongeldig type '{value}'. Geldige types zijn: {string.Join(", ", _allowedTypes)}");
                }

                _type = value.ToLower();
            }
        }

        public Broodje(string name, string type, decimal price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Type} - {Price:C2}";
        }

        public static string ToonGeldigeTypes()
        {
            return string.Join(", ", _allowedTypes);
        }
    }
}
