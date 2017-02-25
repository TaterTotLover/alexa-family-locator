using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using FamilyLocator.Core.Locators;
using FamilyLocator.Core.RequestHandlers;
using Slight.Alexa.Framework.Models.Requests.RequestTypes;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace FamilyLocator
{
    public class Function
    {       
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            if (input.GetRequestType() == typeof(ILaunchRequest))
            {
                // Default launch request, let's just let them know what you can do.

                var launchHandler = new LaunchRequestHandler(input, context);

                return launchHandler.HandleRequest();
            }
            else if (input.GetRequestType() == typeof(IIntentRequest))
            {
                // Intent request, process the intent.
                // It's not currently necessary to route intents (by name) to a request handler since we're only supporting one intent.

                // Poor man's IoC...
                var locatorFactory = new FamilyMemberLocatorFactory();
                var intentHandler = new FamilyMemberIntentHandler(locatorFactory, input, context);

                return intentHandler.HandleRequest();
            }

            return new SkillResponse();
        }
    }
}
