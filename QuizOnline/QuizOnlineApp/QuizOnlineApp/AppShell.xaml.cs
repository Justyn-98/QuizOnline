using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Views;
using System;
using Xamarin.Forms;

namespace QuizOnlineApp
{
    public partial class AppShell : Shell
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
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            ISignInService signInService = DependencyService.Get<ISignInService>();
            signInService.SignOut();
            await Current.GoToAsync($"//{nameof(LoginPage)}");
            Application.Current.MainPage = new LoginPage();
        }
    }
}
