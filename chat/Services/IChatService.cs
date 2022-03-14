using chat.Events;
using Chat.Messages;
using System;
using System.Threading.Tasks;

namespace Chat.Services
{
    public interface IChatService
    {
        event EventHandler<NewMessageEventArgs> NewMessage;

        bool IsConnected { get; }

        Task CreateConnection();
        Task SendMessage(Message message);
        Task Dispose();
    }
}