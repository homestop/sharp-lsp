
namespace message
{
    public class MessageInitialize : Message
    {
        public MessageInitialize()
        {}

        public MessageInitialize(string json) => this.json = json;

        public override void Action ()
        {
        }
    }
}