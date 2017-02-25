using Amazon.Lambda.Core;
using Slight.Alexa.Framework.Models.Requests;
using Slight.Alexa.Framework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyLocator.Core.RequestHandlers
{
    public abstract class RequestHandlerBase
    {
        protected ILambdaContext LambdaContext { get; private set; }

        protected SkillRequest SkillRequest { get; private set; }

        protected ILambdaLogger Logger { get { return LambdaContext.Logger; } }

        protected string IntentName { get { return SkillRequest.Request.Intent.Name; } }

        protected DateTime RequestTimestamp { get { return SkillRequest.Request.Timestamp; } }

        public RequestHandlerBase(SkillRequest request, ILambdaContext context)
        {
            SkillRequest = request;
            LambdaContext = context;
        }

        public abstract SkillResponse HandleRequest();

        /// <summary>
        /// Safely accesses the slot dictionary, returning the value for the given key. Returns null if the key doesn't exist.
        /// </summary>
        /// <param name="slotKey"></param>
        /// <returns></returns>
        protected string GetSlotValue(string slotKey)
        {
            return SkillRequest.Request.Intent.Slots.ContainsKey(slotKey)
                ? SkillRequest.Request.Intent.Slots[slotKey].Value : null;
        }

        /// <summary>
        /// Creates an Alexa skill response for the provided speech text.
        /// </summary>
        /// <param name="speechText"></param>
        /// <returns></returns>
        protected SkillResponse CreateSpeechResponse(string speechText)
        {
            return new PlainTextOutputSpeech { Text = speechText }.ToSkillResponse();
        }
    }
}
