namespace FamilyLocator.Core.Locators
{
    public interface IFamilyMemberLocatorFactory
    {
        IFamilyMemberLocator GetLocator(string familyMember);
    }
}