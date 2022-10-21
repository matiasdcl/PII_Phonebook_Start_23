using System;
using TwitterUCU;
namespace Library
{
    public class TwitterChannel : MessageChannel
    {   
        private readonly TwitterMessage _api;
        /*var twitter = new TwitterMessage();
        twitter.SendMessage("Hola!", "<userId>");*/
        public TwitterChannel (){
            _api= new TwitterMessage();
        }
        public override void Send(string message, string destination){
            _api.SendMessage(message, destination);
        }
    }
}