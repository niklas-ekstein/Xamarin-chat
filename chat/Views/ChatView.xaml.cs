using chat.Models;
using chat.ViewModels;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace chat.Views
{
    public partial class ChatView : ContentPage
    {
        ChatViewModel vm;

        public ChatView()
        {
            InitializeComponent();
            vm = BindingContext as ChatViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ChatViewModel>(this, "SCROLL_BOTTOM", (obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Task.Delay(100);
                    //if (vm.ChatMessageList.Count > 0)
                    //{
                    //    lvChat.ScrollTo(vm.ChatMessageList[vm.ChatMessageList.Count - 1], ScrollToPosition.End, false);
                    //}
                });
            });
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<ChatViewModel>(this, "SCROLL_BOTTOM");
            base.OnDisappearing();
        }
    }
}











//using chat.ViewModels;
//using System.Linq;
//using Xamarin.Forms;
//using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
//using Xamarin.Forms.Xaml;

//namespace chat.Views
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class ChatView : ContentPage
//    {
//        private ChatViewModel viewModel;

//        public ChatView(ChatViewModel viewModel)
//        {
//            this.viewModel = viewModel;

//            InitializeComponent();

//            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(false);

//            //viewModel.Messages.CollectionChanged += Messages_CollectionChanged;
//            BindingContext = viewModel;
//        }

//        protected override void OnAppearing()
//        {
//            base.OnAppearing();
//            var safeArea = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
//            MainGrid.HeightRequest = this.Height - safeArea.Top - safeArea.Bottom;
//        }

//        private void Messages_CollectionChanged(object sender,
//            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
//        {
//            //MessageList.ScrollTo(viewModel.Messages.Last(), ScrollToPosition.End, true);
//        }
//    }
//}