using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;

namespace FamilyLocator.Core.RequestHandlers
{
    public class LaunchRequestHandler : RequestHandlerBase
    {
        public LaunchRequestHandler(SkillRequest request, ILambdaContext context) 
            : base(request, context)
        {
        }

        public override SkillResponse HandleRequest()
        {
            Logger.LogLine($"Default LaunchRequest made");

            return CreateSpeechResponse("Welcome to Family Locator. You can ask us find your family members!");
        }
    }
}
