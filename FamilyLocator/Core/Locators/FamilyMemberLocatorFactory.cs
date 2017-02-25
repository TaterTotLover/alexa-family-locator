using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyLocator.Core.Locators
{
    public class FamilyMemberLocatorFactory: IFamilyMemberLocatorFactory
    {
        private Dictionary<string, Type> _locatorMap;

        public FamilyMemberLocatorFactory()
        {
            _locatorMap = new Dictionary<string, Type>();

            // Setup string-to-type locator mappings.

            _locatorMap.Add("BABY", typeof(BabyLocator));
            _locatorMap.Add("CHILD", typeof(BabyLocator));

            _locatorMap.Add("MOM", typeof(GeneralLocator));
            _locatorMap.Add("MOTHER", typeof(GeneralLocator));

            _locatorMap.Add("DAD", typeof(GeneralLocator));
            _locatorMap.Add("FATHER", typeof(GeneralLocator));

            _locatorMap.Add("SON", typeof(GeneralLocator));
            _locatorMap.Add("BOY", typeof(GeneralLocator));

            _locatorMap.Add("DAUGHTER", typeof(GeneralLocator));
            _locatorMap.Add("GIRL", typeof(GeneralLocator));
        }

        public IFamilyMemberLocator GetLocator(string familyMember)
        {
            if (!_locatorMap.ContainsKey(familyMember.ToUpper())) { return null; }
            //throw new KeyNotFoundException($"A locator for the family member \"{familyMember}\" could not be found.");

            var locatorType = _locatorMap[familyMember.ToUpper()];

            return Activator.CreateInstance(locatorType) as IFamilyMemberLocator;
        }
    }
}
