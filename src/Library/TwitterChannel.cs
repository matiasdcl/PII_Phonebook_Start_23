using System;
namespace Library
{
    public class TwitterChannel : MessageChannel
    {   
        public string Message {get; set;}
        public TwitterChannel (string message){
            this.Message = message;
        }
        public void Send(string message){
            Console.WriteLine (message);
        }
    }
}