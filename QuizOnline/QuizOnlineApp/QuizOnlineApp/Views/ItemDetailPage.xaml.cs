using QuizOnlineApp.ViewModels;
using Xamarin.Forms;

namespace QuizOnlineApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            BindingContext = new ItemDetailViewModel();
            InitializeComponent();
        }
    }
}