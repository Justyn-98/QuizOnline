using QuizOnlineApp.Views;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        public Command OpenQuestionCommand;

        public QuestionViewModel ()
        {
            OpenQuestionCommand = new Command(OnQuestionClicked);
        }

        private async void OnQuestionClicked (object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(QuestionPage)}");
        }
    }
}
