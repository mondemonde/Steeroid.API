using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;
using DevNoteHub.Azure;

namespace WebApplicationTest
{
    public class Global : HttpApplication
    {

        //public static SubscriptionClient MyAzure;
        public static QueueClient MyAzure;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



            #region AZURE BUS---------------------------------


            var connectionString = @"Endpoint=sb://devnote.servicebus.windows.net/;SharedAccessKeyName=SteerAccess;SharedAccessKey=UsPOVthgtxQuHN0yN4RRsabW9LGzDaQdUWx2sbY8qOs=";
            var subscriptionName = "appsteerqueue";

           

            MyAzure = new QueueClient(connectionString,subscriptionName);


            var options = new MessageHandlerOptions((args) =>
            {
                Console.WriteLine($"Message handler encountered an exception {args.Exception}.");
                var context = args.ExceptionReceivedContext;
                Console.WriteLine("Exception context for troubleshooting:");
                Console.WriteLine($"- Endpoint: {context.Endpoint}");
                Console.WriteLine($"- Entity Path: {context.EntityPath}");
                Console.WriteLine($"- Executing Action: {context.Action}");

                return Task.CompletedTask;
            });

            options.MaxConcurrentCalls = 10;
            options.AutoComplete = false;


            // STEP_.RECIEVER AZURE REcieve EVENT DevNoteServiceBusMessageHandler DevNoteServiceBusMessageHandler
            var serviceBusHandler = new DevNoteServiceBusMessageHandler(MyAzure);
            MyAzure.RegisterMessageHandler(serviceBusHandler.MessageReceivedHandler, options);


            #endregion -----------------------------------


        }
    }
}