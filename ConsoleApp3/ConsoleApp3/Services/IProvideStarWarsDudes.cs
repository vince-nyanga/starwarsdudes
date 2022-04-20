using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp3.Models;

namespace ConsoleApp3.Services
{
    public interface IProvideStarWarsDudes
    {
        Task<IEnumerable<Dude>> GetCharacters(string url);
    }
}