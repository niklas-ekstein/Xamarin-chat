//using chat.Helpers;
using chat.ViewModels;
using Prism.Navigation;
using Xamarin.Forms;

namespace chat.Views
{
    public partial class ChatUserListPage : ContentPage
    {
        ChatUserListPageViewModel vm;

        public ChatUserListPage()
        {
            InitializeComponent();
            vm = BindingContext as ChatUserListPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //vm.LoadConnectedUsers();
        }
    }
}
