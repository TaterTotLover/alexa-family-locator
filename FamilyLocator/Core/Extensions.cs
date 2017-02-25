using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyLocator.Core
{
    public static class Extensions
    {
        public static SkillResponse ToSkillResponse(this IOutputSpeech speech)
        {
            var skillResponse = new SkillResponse();
            skillResponse.Response = new Response { OutputSpeech = speech, ShouldEndSession = true };
            skillResponse.Version = "1.0";

            return skillResponse;
        }
    }
}
