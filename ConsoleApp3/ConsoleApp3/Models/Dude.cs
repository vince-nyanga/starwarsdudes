using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3.Models
{
    public class Dude
    {
        public string Name { get; set; }
        public IEnumerable<string> Films { get; set; }


        public bool IsBuddie(Dude other)
        {
            return Films.Count() == other.Films.Count() && other.Films.Intersect(Films).Any();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}