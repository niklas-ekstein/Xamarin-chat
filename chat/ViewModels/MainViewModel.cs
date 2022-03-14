using System.Windows.Input;
//using chat.Services;
using chat.Views;
using Xamarin.Forms;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Mvvm;
//using chat.Helpers;

namespace chat.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public string Username { get; set; }
        public string test { get; set; }

        private readonly IPageDialogService dialogService;
        public INavigationService navigationService;
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }

        private DelegateCommand _navigateCommand;
        private readonly INavigationService _navigationService;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommad));

        //public User User { get; set; }

        //ChatService chatService;


        public MainViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;

            //test = "Main page";
            //User = Username;

            //var chatView = Resolver.Resolve<ChatView>();
            //Navigation.PushAsync(chatView);
        }

        public ICommand Start => new Command(async () =>
        {
            await NavigationService.NavigateAsync("ChatListView");
        });

        async void ExecuteNavigateCommad()
        {
            //var p = new NavigationParameters();
            //p.Add("title", "hello from main view");

            //await NavigationService.NavigateAsync("ChatView", new NavigationParameters($"userId={"hej"}"));

            //await _navigationService.NavigateAsync("/MainView/NavigationPage/ListChat", p);
        }
    }
}
