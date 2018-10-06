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
using System.Net;

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
                await HandleSystemMessageAsync(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private async Task<Activity> HandleSystemMessageAsync(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}