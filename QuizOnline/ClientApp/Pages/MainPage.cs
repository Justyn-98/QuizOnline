using System;
using Xamarin.Forms;

namespace ClientApp.Pages
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            await label.RelRotateTo(360, 1000);
        }
    }
}