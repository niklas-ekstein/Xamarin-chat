//using chat.Helpers;
using chat.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
//using chat.Services;

namespace chat.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        public INavigationService navigationService;
        HubConnection hubConnection;
        public Command SendMessageCommand { get; }
        public Command ConnectCommand { get; }
        public Command DisconnectCommand { get; }
        public ICommand GoHomeCommand { get; set; }
        public ICommand TextChangedCommand { get; set; }
        public string PairConnectionId { get; set; }
        public string PairUserId { get; set; }
        public string PairPhoto { get; set; }
        public string MyPhoto { get; set; }
        public string MyUserId { get; set; }
        public string MyName { get; set; }

        string _pairName = String.Empty;
        public string PairName
        {
            get
            {
                return _pairName;
            }
            set
            {
                _pairName = value;
                RaisePropertyChanged();
            }
        }

        public string MessageHistoryKey
        {
            get
            {
                return this.MyUserId + "_" + this.PairUserId;
            }
        }

        //ObservableCollection<ChatMessage> _chatMessageList = new ObservableCollection<ChatMessage>();
        //public ObservableCollection<ChatMessage> ChatMessageList
        //{
        //    get
        //    {
        //        return _chatMessageList;
        //    }
        //    set
        //    {
        //        _chatMessageList = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //string _sendingMessage = String.Empty;
        //public string SendingMessage
        //{
        //    get
        //    {
        //        return _sendingMessage;
        //    }
        //    set
        //    {
        //        _sendingMessage = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //string _titleText = String.Empty;
        //public string TitleText
        //{
        //    get
        //    {
        //        return _titleText;
        //    }
        //    set
        //    {
        //        _titleText = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //string _typingText = String.Empty;
        //public string TypingText
        //{
        //    get
        //    {
        //        return _typingText;
        //    }
        //    set
        //    {
        //        _typingText = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //bool _showTyping = false;
        //public bool ShowTyping
        //{
        //    get
        //    {
        //        return _showTyping;
        //    }
        //    set
        //    {
        //        _showTyping = value;
        //        RaisePropertyChanged();
        //    }
        //}

        private CancellationTokenSource tokenSource;

        public ChatViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.navigationService = navigationService;
            //App.IsChatPageInitialize = true;

            //ChatMessageList = new ObservableCollection<ChatMessage>();

            //SendMessageCommand = new Command(async () => await SendMessage());
            //ConnectCommand = new Command(async () => await ChatHelper.Connect(Settings.ChatUserName));
            //DisconnectCommand = new Command(async () => await ChatHelper.Disconnect(Settings.ChatUserName));
            //GoHomeCommand = new DelegateCommand(GoHomeCommandAction);
            //TextChangedCommand = new DelegateCommand(TextChangedCommandAction);

            //this.MyUserId = Utils.GetUserId(Settings.ChatUserName);
            //this.MyName = Utils.GetName(Settings.ChatUserName);
            //this.MyPhoto = "my_photo.png"; // Replace with your photo

            //hubConnection = ChatHelper.GetInstanse(Settings.ChatUserName);
            //hubConnection.Closed += async (error) =>
            //{
            //    SendLocalMessage("---Connection closed---");
            //    ChatHelper.IsConnected = false;
            //    await Task.Delay(2000);
            //    await ChatHelper.Connect(Settings.ChatUserName);
            //};

            //hubConnection.On<string, ObservableCollection<ChatUser>>("UserDisconnected", (connectionId, chatUserList) =>
            //{
            //    //SendLocalMessage("---User disconnected---");
            //});

            //hubConnection.On<string, string>("TypingMessage", (connectionId, name) =>
            //{
            //    TaskCancel();
            //    this.TypingText = name + " is typing...";
            //    this.ShowTyping = true;
            //    TaskDelay();
            //});

            //hubConnection.On<string, string, string, string, string, string, bool>("ReceiveMessage", (pairConnectionId, pairUserId, pairName, pairPhoto, message, uniqueId, isMe) =>
            //{
            //    if (!isMe)
            //    {
            //        this.PairConnectionId = pairConnectionId;
            //        this.PairUserId = pairUserId;
            //        this.PairName = PairName;
            //        this.PairPhoto = "pair_photo.png"; // Replace with your pair Photo;
            //    }

            //    ChatMessageList.Add(new ChatMessage() { Message = message, IsOwnMessage = isMe, IsSystemMessage = false, ActionTime = DateTime.Now.ToString("hh:mm tt") });

            //    // List item scroll down to bottom
            //    MessagingCenter.Send(this, "SCROLL_BOTTOM");

            //});
        }

        public void TaskCancel()
        {
            tokenSource?.Cancel();
        }

        //public async void TaskDelay()
        //{
        //    tokenSource = new CancellationTokenSource();
        //    try
        //    {
        //        await Task.Delay(3000, tokenSource.Token);
        //        this.ShowTyping = false;
        //    }
        //    catch (TaskCanceledException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        tokenSource.Dispose();
        //        tokenSource = null;
        //    }
        //}

        private async void GoHomeCommandAction()
        {
            await NavigationService.NavigateAsync("/MenuPage/NavigationPage/HomePage");
        }

        private async void TextChangedCommandAction()
        {
            await Typing();
        }

        //async Task SendMessage()
        //{
        //    try
        //    {
        //        await hubConnection.InvokeAsync("SendMessage", this.PairConnectionId, this.MyUserId, this.MyName, this.MyPhoto, this.SendingMessage);
        //        this.SendingMessage = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        //SendLocalMessage($"Send failed: {ex.Message}");
        //    }
        //}

        async Task Typing()
        {
            await hubConnection.InvokeAsync("Typing", this.PairConnectionId, this.MyName);
        }

        //private void SendLocalMessage(string message)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        ChatMessageList.Add(new ChatMessage
        //        {
        //            Message = message,
        //            IsOwnMessage = false,
        //            IsSystemMessage = true
        //        });
        //    });
        //}

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("userId"))
            {

                //TitleText = parameters["userId"] as string;
                //this.PairConnectionId = parameters["connectionId"] as string;
                //this.PairPhoto = "icon_female.png";
                //this.PairName = parameters["name"] as string;
                //this.PairUserId = parameters["userId"] as string;

                //this.MyUserId = Utils.GetUserId(Settings.ChatUserName);
                //this.MyPhoto = "icon_male.png";

                //MessagingCenter.Send(this, "SCROLL_BOTTOM");
            }
        }
    }
}
















//using System;
//using System.Collections.ObjectModel;
//using System.Threading.Tasks;
//using Chat.Messages;
//using Chat.Services;
//using System.IO;
//using System.Linq;
//using System.Windows.Input;
////using Acr.UserDialogs;
////using Plugin.Media;
////using Plugin.Media.Abstractions;
//using Xamarin.Forms;

//namespace chat.ViewModels
//{
//    public class ChatViewModel : ViewModel
//    {
//        private string text;
//        public string Text
//        {
//            get => text;
//            set => Set(ref text, value);
//        }

//        private readonly IChatService chatService;
//        public ObservableCollection<Message> Messages
//        {
//            get;
//            private set;
//        }

//        public ChatViewModel(IChatService chatService)
//        {
//            this.chatService = chatService;

//            Messages = new ObservableCollection<Message>();

//            chatService.NewMessage += ChatService_NewMessage;

//            Task.Run(async () =>
//            {
//                if (!chatService.IsConnected)
//                {
//                    await chatService.CreateConnection();
//                }

//                await chatService.SendMessage(new
//                UserConnectedMessage(User));
//            });
//        }

//        private void ChatService_NewMessage(object sender, Events.NewMessageEventArgs e)
//        {
//            Device.BeginInvokeOnMainThread(() =>
//            {
//                if (!Messages.Any(x => x.Id == e.Message.Id))
//                {
//                    Messages.Add(e.Message);
//                }
//            });
//        }

//        public ICommand Send => new Command(async () =>
//        {
//            var message = new SimpleTextMessage(User)
//            {
//                Text = this.Text
//            };

//            Messages.Add(new LocalSimpleTextMessage(message));

//            await chatService.SendMessage(message);

//            Text = string.Empty;
//        });
//    }
//}
