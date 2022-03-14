using chat.ViewModels;
//using chat.Views.Account;
//using chat.Helpers;
using chat.Models;
using chat.ViewModels;
//using chat.Views.Account;
//using chat.Views.Chat;
//using chat.Views.Menu;
//using Plugin.LocalNotification;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using chat.Views;

namespace chat
{
    public partial class App
    {

        public static ObservableCollection<ChatUser> OnlineChatUsers { get; set; }

        //public App()
        //{
        //    InitializeComponent();
        //    Bootstrapper.Init();

        //    var mainView = Resolver.Resolve<MainView>();
        //    var navigationPage = new NavigationPage(mainView);
        //    ViewModel.Navigation = navigationPage.Navigation;
        //    MainPage = navigationPage;
        //}

        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NotificationCenter.Current.NotificationTapped += LoadPageFromNotification;

            NavigationService.NavigateAsync("NavigationPage/MainView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ChatView, ChatViewModel>();
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterForNavigation<ChatListView, ChatListViewModel>();
            containerRegistry.RegisterForNavigation<ChatUserListPage, ChatUserListPageViewModel>();
            //containerRegistry.RegisterForNavigation<ForgotPasswordPage, ForgotPasswordPageViewModel>();
            //containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
        }

        protected override void OnStart()
        {
        }

        //protected override void OnSleep()
        //{
        //}

        //protected override void OnResume()
        //{
        //}

        //protected override void OnSleep()
        //{
        //    var chatService = Resolver.Resolve<IChatService>();
        //    chatService.Dispose();
        //}

        //protected override void OnResume()
        //{
        //    Task.Run(async () =>
        //    {
        //        var chatService = Resolver.Resolve<IChatService>();

        //        if (!chatService.IsConnected)
        //        {
        //            await chatService.CreateConnection();
        //        }
        //    });

        //    Page view = null;

        //    if (ViewModel.User != null)
        //    {
        //        view = Resolver.Resolve<ChatView>();
        //    }
        //    else
        //    {
        //        view = Resolver.Resolve<MainView>();
        //    }

        //    var navigationPage = new NavigationPage(view);
        //    MainPage = navigationPage;
        //}
    }
}
