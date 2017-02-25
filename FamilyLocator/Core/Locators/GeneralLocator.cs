using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyLocator.Core.Locators
{
    public class GeneralLocator : RandomizedLocatorBase, IFamilyMemberLocator
    {
        protected override IList<string> Locations
        {
            get
            {
                return new[]
                {
                    "I simply do not know.",
                    "I can't say..."
                };
            }
        }

        public string GetLocation()
        {
            return GetRandomLocation();
        }
    }
}
