using Prism.Mvvm;
using Prism.Navigation;

namespace chat.ViewModels
{
    public class ViewModel : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }



    //public abstract class ViewModel : INotifyPropertyChanged
    //{
    //    public static INavigation Navigation { get; set; }
    //    public static string User { get; set; }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected void Set<T>(ref T field, T newValue,
    //                          [CallerMemberName] string propertyName =
    //                          null)
    //    {
    //        if (!EqualityComparer<T>.Default.Equals(field, newValue))
    //        {
    //            field = newValue;
    //            PropertyChanged?.Invoke(this, new
    //            PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}
}
