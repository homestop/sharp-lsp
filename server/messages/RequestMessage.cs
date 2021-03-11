using System;

namespace messages
{
    public class RequestMessage : Message
    {
        public RequestMessage (string json)
            : base (json)
        {}

        public override void Action ()
        {
            Parse();
            // HERE: Should be logic
        }
    }
}
