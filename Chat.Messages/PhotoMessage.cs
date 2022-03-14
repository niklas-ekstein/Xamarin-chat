using System;
namespace Chat.Messages
{
    public class PhotoMessage : Message
    {
        public PhotoMessage() { }
        public PhotoMessage(string username) : base(username) { }

        public string Base64Photo { get; set; }
        public string FileEnding { get; set; }
    }
}
