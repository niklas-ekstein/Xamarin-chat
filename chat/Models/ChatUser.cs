using System;
namespace chat.Models
{
    public class ChatUser
    {
        public string ConnectionId { get; set; }
        public string ChatUsername { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhotoPath { get; set; }
        public bool IsOnline { get; set; }
        public DateTime ActionTime { get; set; }
    }
}
