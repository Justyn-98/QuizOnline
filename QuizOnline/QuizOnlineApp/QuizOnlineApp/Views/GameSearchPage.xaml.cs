using QuizOnlineApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizOnlineApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameSearchPage : ContentPage
    {
        public GameSearchPage()
        {
            BindingContext = new GameSearchViewModel();
            InitializeComponent();
        }
    }
}