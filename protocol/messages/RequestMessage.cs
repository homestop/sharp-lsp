namespace protocol
{
    namespace messages
    {
        public class RequestMessage : IMessage
        {
            public int id { get; set; }
            public string jsonrpc { get; set; }
            public string method { get; set; }
            // Should like that: params?: array | object;
        }
    }
}
