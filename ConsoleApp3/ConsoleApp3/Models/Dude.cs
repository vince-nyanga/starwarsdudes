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
            var otherCount = other.Films.ToList().Count;
            return Films.Count() == other.Films.Count();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}