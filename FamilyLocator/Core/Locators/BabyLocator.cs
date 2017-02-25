using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyLocator.Core.Locators
{
    public class BabyLocator : RandomizedLocatorBase, IFamilyMemberLocator
    {
        protected override IList<string> Locations
        {
            get
            {
                return new[]
                {
                    "I don't know where your baby is...",
                    "Your baby is not my problem.",
                    "How 'bout you get off your butt and find your own baby?"
                };
            }
        }

        public string GetLocation()
        {
            return GetRandomLocation();
        }
    }
}
