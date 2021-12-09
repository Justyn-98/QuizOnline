using QuizOnlineApp.ViewModels;
using Xamarin.Forms;

namespace QuizOnlineApp.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            BindingContext = _viewModel = new ItemsViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}