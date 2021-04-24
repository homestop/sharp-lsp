using Newtonsoft.Json.Linq;

namespace message
{
    interface IMessage
    {
        public string json { get; set; }
        public string jsonrpc { get; set; }

        public int id { get; set; }
        public string method { get; set; }

        public void Action ();
    }

    public abstract class Message : IMessage
    {
        public string json { get; set; }
        public string jsonrpc { get; set; }

        public int id { get; set; }
        public string method { get; set; }

        public string responce { get; set; }
        
        // public Message (string json) => this.json = json;

        public abstract void Action ();

        public virtual void Parse ()
        {
            JObject tokens = JObject.Parse(json);

            this.id = (int)tokens["id"];
            this.jsonrpc = (string)tokens["jsonrpc"];
            this.method = (string)tokens["method"];
        }
    }

    public class MessageProvider
    {
        public static Message GetMessage (string method)
        {
            switch(method)
            {
                case "initialize": 
                    return new MessageInitialize();

                case "textDocument/didOpen":
                    return new MessageTextDocumentDidOpen(); 

                default:
                    return null;
            }
        }
    }

    public enum ErrorCode
        {
            ParseError = -32700,

            InvalidRequest = -32600,
            MethodNotFound = -32601,
            InvalidParams = -32602,
            InternalError = -32603,

            ServerNotInitialized = -32002,
            UnknowErrorCode = -32001,
            jsonrpcReservedErrorRangeEnd = 32000
        }
}