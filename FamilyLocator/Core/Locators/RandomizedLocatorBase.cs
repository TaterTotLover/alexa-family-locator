using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyLocator.Core.Locators
{
    public abstract class RandomizedLocatorBase
    {
        private static Random Rng = new Random();

        protected abstract IList<string> Locations { get; }

        protected string GetRandomLocation()
        {
            var randomIndex = Rng.Next(Locations.Count());

            return Locations[randomIndex];
        }
    }
}
