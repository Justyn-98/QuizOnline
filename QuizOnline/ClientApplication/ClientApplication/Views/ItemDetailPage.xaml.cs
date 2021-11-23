using ClientApplication.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ClientApplication.Views
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