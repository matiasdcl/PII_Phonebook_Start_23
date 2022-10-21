using WhatsAppApiUCU;
namespace Library
{
    public class WhatsAppChannel : MessageChannel
    {
        private readonly WhatsAppApi _api;
        /*var whatsApp = new WhatsAppApi();
        whatsApp.Send("+598<Poné tu teléfono acá>", "Hey! I'm using WhatsApp");*/

        public WhatsAppChannel (){
            _api = new WhatsAppApi();
        }
        public override void Send(string message, string destination){
            _api.Send(destination, message);
        }
    }
}