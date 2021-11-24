using QuizOnlineApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace QuizOnlineApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}