namespace Library
{
    public abstract class MessageChannel
    {
        
        public abstract void Send(string message, string destination);
        
    }
}