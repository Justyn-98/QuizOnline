using QuizOnlineApp.Models;
using QuizOnlineApp.ViewModels;
using Xamarin.Forms;

namespace QuizOnlineApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            BindingContext = new NewItemViewModel();
            InitializeComponent();
        }
    }
}