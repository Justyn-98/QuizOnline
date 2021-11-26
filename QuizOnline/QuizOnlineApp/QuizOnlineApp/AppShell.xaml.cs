using QuizOnlineApp.ViewModels;
using QuizOnlineApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QuizOnlineApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(MainMenuPage), typeof(MainMenuPage));
            Routing.RegisterRoute(nameof(GameSearchPage), typeof(GameSearchPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(QuestionPage), typeof(QuestionPage));
            Routing.RegisterRoute(nameof(RankingPage), typeof(RankingPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
