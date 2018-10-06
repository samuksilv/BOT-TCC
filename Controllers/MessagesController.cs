using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using System;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System.Net.Http;
using System.Web.Http.Description;
using System.Diagnostics;

namespace Microsoft.Bot.Sample.FormBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
      
        /// <summary>
        /// POST: api/Messages
        /// receive a message from a user and send replies
        /// </summary>
        /// <param name="activity"></param>
        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            if (activity.Type == ActivityTypes.ConversationUpdate)
            {
                if (activity.MembersAdded.Any(o => o.Id == activity.Recipient.Id))
                {
                    var reply = activity.CreateReply();
                    reply.Text = "Olá, eu sou o **Bot Inteligentão**." ;

                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
            }
            
            if (activity.Type == ActivityTypes.Message)
            {              

                await Conversation.SendAsync(activity, () => {
                    return Chain.From(
                        ()=> FormDialog.FromForm(FormFlowHAD.BuildHADForm )
                    );
                });

            }
            else
            {
                HandleSystemMessageAsync(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}