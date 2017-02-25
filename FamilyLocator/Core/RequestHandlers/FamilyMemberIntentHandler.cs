using Amazon.Lambda.Core;
using FamilyLocator.Core.Locators;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyLocator.Core.RequestHandlers
{
    public class FamilyMemberIntentHandler: RequestHandlerBase
    {
        public const string FamilyMemberSlotName = "FamilyMember";
        private readonly IFamilyMemberLocatorFactory _locatorFactory;

        protected string FamilyMember { get { return GetSlotValue(FamilyMemberSlotName); } }

        public FamilyMemberIntentHandler(IFamilyMemberLocatorFactory locatorFactory, SkillRequest request, ILambdaContext context) 
            : base(request, context)
        {
            _locatorFactory = locatorFactory;
        }

        public override SkillResponse HandleRequest()
        {
            Logger.LogLine($"Intent Requested: {IntentName}");

            if (string.IsNullOrEmpty(FamilyMember))
            {
                Logger.LogLine($"A family member was not specified.");
                return CreateSpeechResponse("Please specify a family member.");
            }

            Logger.LogLine($"Requesting location of {FamilyMember}");

            var locator = _locatorFactory.GetLocator(FamilyMember);

            if (locator == null)
            {
                Logger.LogLine($"A locator was not implemented for the requested family member: {FamilyMember}.");
                return CreateSpeechResponse("I'm sorry. I don't know what you're talking about.");
            }

            Logger.LogLine($"Created instance of {locator.GetType()}.");

            var location = locator.GetLocation();

            Logger.LogLine($"Responding with location: \"{location}\"");

            return CreateSpeechResponse(location);
        }
    }
}
