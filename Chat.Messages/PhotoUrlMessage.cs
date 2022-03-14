using System;
namespace Chat.Messages
{
    public class PhotoUrlMessage : Message
    {
        public PhotoUrlMessage() { }
        public PhotoUrlMessage(string username) : base(username) { }

        public string Url { get; set; }
    }
}
