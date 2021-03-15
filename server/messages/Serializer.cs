using System;
using Newtonsoft.Json.Linq;

namespace message
{
    interface ISerializer
    {}

    public class MessageSerializer : ISerializer, IDisposable
    {
        public string json { get; private set; }
        
        public MessageSerializer()
        {}

        public MessageSerializer(string json) => this.json = json;

        public string getMethod(string json)
        {
            JObject tokens =  JObject.Parse(json);

            return (string)tokens["method"];
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        { }
    }
}