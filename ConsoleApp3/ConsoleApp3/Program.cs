using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp3.Models;
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
            var dudesList = dudes.ToList();
            var buddies = new HashSet<Dude>();

            for (int i = 0; i < dudesList.Count - 1 ; i++)
            {
                var firstDude = dudesList[i];
                var hasBuddies = false;
                for (int j = i+1; j < dudes.Count(); j++)
                {
                    var otherDude = dudesList[i];
                    if (firstDude.IsBuddie(otherDude))
                    {
                        hasBuddies = true;
                        buddies.Add(otherDude);
                    }
                }

                if (hasBuddies)
                {
                    buddies.Add(firstDude);
                }
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