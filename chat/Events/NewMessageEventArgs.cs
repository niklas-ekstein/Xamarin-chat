using Chat.Messages;
using System;

namespace chat.Events
{
    public class NewMessageEventArgs : EventArgs
    {
        public Message Message { get; private set; }

        public NewMessageEventArgs(Message message)
        {
            Message = message;
        }
    }
}