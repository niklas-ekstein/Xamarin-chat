//using ChatApp.Helpers;
using chat.ViewModels;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace chat.Views
{
    public partial class ChatListView : ContentPage
    {
        ChatListViewModel vm;

        public ChatListView()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(false);

            vm = BindingContext as ChatListViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //vm.LoadConnectedUsers();
        }
    }
}






//using System;
//using System.Collections.Generic;
//using chat.ViewModels;
//using Xamarin.Forms;
//using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
//using Xamarin.Forms.Xaml;

//namespace chat.Views
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class ChatListView : ContentPage
//    {
//        public ChatListViewModel viewModel;
//        public string Username;

//        public ChatListView(ChatListViewModel viewModel)
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
//            //vm.usernameVM = Username;
//            //vm.LoadConnectedUsers();
//        }
//    }
//}
