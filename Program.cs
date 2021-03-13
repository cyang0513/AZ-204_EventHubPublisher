using System;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;

namespace EventHubTest
{
   class Program
   {
      static async Task Main(string[] args)
      {
         var hubEndPoint = "Endpoint=sb://chyaeventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=//JboujWToYmJ2tytgSKApsCgERt2OC4O4/H5uXD7CQ=";
         Console.WriteLine("Event Hub event publisher...");


         var hub = EventHubClient.Create(new EventHubsConnectionStringBuilder(hubEndPoint)
                                         {
                                            EntityPath = "chyahub"
                                         });

         Console.WriteLine("enter event data (Q to quit):");
         while (true)
         {
            var data = Console.ReadLine();

            if (data == "Q")
            {
               break;
            }

            await hub.SendAsync(new EventData(Encoding.UTF8.GetBytes($"Event data: {data} at {DateTime.Now}")));
         }

      }
   }
}
