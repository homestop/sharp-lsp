namespace messages
{
    // public class ResponseMessage : IMessage
    // {
    //     public string jsonrpc { get; set; }
    //     public string result { get; set; }
    //     public ResponseError error { get; set; }
    // }

    public class ResponseError
    {
        public int code { get; set; } 
        public string message { get; set; }
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
