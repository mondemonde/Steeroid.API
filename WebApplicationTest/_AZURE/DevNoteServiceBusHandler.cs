using DevNoteHub.API.Models;
using DevNoteHub.Models;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationTest._Repo;

namespace DevNoteHub.Azure
{
    public class DevNoteServiceBusMessageHandler
    {
        //private readonly ISubscriptionClient client;
        private readonly IQueueClient client;


        public DevNoteServiceBusMessageHandler(IQueueClient client)
        {
            this.client = client;
            // azuBOT = bot;
        }

        //STEP.AZURE MessageReceivedHandler

        public async Task MessageReceivedHandler(Message message, CancellationToken token)
        {
            //STEP_.RECIEVER #2 MessageReceivedHandler
             Debug.WriteLine($"Received message1: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
            //you can also check for some user properties
            //object objMode = message.UserProperties["Mode"];

            var jsonMessage = Encoding.UTF8.GetString(message.Body);
            var result = JsonConvert.DeserializeObject<ResultMessage>(jsonMessage);

            Debug.WriteLine("-------------RESULT: " + result.OuputResponse);

            var msg = string.Format("(ID#{0}) REF#{1}: {2}",result.MessageId, result.ReferenceId, result.OuputResponse);
            MyDb.Results.Add(msg);

            await client.CompleteAsync(message.SystemProperties.LockToken);
        }



    }
}

