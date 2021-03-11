using Newtonsoft.Json.Linq;

namespace messages
{
    internal interface IMessage
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

        public Message (string json) => this.json = json;

        public abstract void Action ();

        public virtual void Parse ()
        {
            JObject tokens = JObject.Parse(json);

            this.id = (int)tokens["id"];
            this.jsonrpc = (string)tokens["jsonrpc"];
            this.method = (string)tokens["method"];
        }

    }

}