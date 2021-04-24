
namespace message
{
    public class MessageTextDocumentDidOpen : Message
    {
        public MessageTextDocumentDidOpen()
        {}

        public MessageTextDocumentDidOpen(string json) => this.json = json;

        public override void Action ()
        {
            this.responce = "From server TextDocumentDidOpen";
        }
    }

}