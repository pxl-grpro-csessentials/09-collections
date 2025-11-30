using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRoster.Models
{
    internal class Pokemon
    {
        private readonly string[] AvailableTypes = { "Fire", "Water", "Energy", "Dragon", "Fairy" };

        public string Name { get; set; }
        public int Level { get; set; }

        private string _type;

        public string Type
        {
            get { return _type; }
            set 
            { 
                if(Array.Exists(AvailableTypes, element => element.Equals(value)))
                {
                    _type = value; 
                }
                else
                {
                    throw new ArgumentException($"{value} is geen geldig type!");
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Level})";
        }

    }
}
