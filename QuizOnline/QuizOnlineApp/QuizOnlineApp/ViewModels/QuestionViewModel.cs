using QuizOnlineApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    class QuestionViewModel : BaseViewModel
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
