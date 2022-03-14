using System;
using System.Collections.Generic;
using chat.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace chat.Views
{
    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>
            ().SetUseSafeArea(false);

            BindingContext = viewModel;
        }
    }
}
