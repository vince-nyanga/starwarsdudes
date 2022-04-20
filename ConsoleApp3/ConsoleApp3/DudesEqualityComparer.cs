using System.Collections.Generic;
using System.Linq;
using ConsoleApp3.Models;

namespace ConsoleApp3
{
    internal class DudesEqualityComparer : IEqualityComparer<Dude>
    {
        public bool Equals(Dude x, Dude y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return HasSameContents(x.Films, y.Films);
        }

        private bool HasSameContents(IEnumerable<string> xFilms, IEnumerable<string> yFilms)
        {
            if (xFilms.Count() != yFilms.Count())
            {
                return false;
            }

            var contains = true;
            foreach (var xFilm in xFilms)
            {
                if (!yFilms.Contains(xFilm))
                {
                    contains = false;
                    break;
                }
            }

            return contains;
        }

        public int GetHashCode(Dude obj)
        {
            unchecked
            {
                return obj.Films.Aggregate(19, (current, film) => current * 31 + film.GetHashCode());
            }
        }
    }
}