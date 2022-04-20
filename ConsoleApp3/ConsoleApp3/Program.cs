using System;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp3.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp3
{
    class Program
    {
        private const string Url = "https://swapi.dev/api/people";
        static async Task Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var service = serviceProvider.GetRequiredService<IProvideStarWarsDudes>();
            var dudes = await service.GetCharacters(Url);
            var buddies = dudes.GroupBy(x =>x, new DudesEqualityComparer());
            Console.WriteLine("Buddies");
            foreach (var @group in buddies)
            {
                var list = @group.ToList();
                Console.WriteLine($"Buddies in only these films: {string.Join(',', list.First().Films)}");
                Console.WriteLine(string.Join(',', list.Select(x =>x.Name)));
                Console.WriteLine();
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<IProvideStarWarsDudes, StarWarsService>();
            return collection.BuildServiceProvider();
        }
    }
}