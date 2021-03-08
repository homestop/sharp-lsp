using protocol.messages;

using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

using System;

namespace protocol
{
    public class MessageHandler
    {
        public static string Handle (string message)
        {
            RequestMessage current = new RequestMessage();

            try
            {
                JObject tokens = JObject.Parse(message);

                current.jsonrpc = (string)tokens["jsonrpc"];
                current.id = (int)tokens["id"];
                current.method = (string)tokens["method"];
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return "Handle was not implemented yet...";
        }
    }
}
