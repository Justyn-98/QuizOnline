using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Services;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(DateTimeService))]
namespace QuizOnlineApp.Services
{
    public class DateTimeService : IDateTimeGetter
    {
        public DateTime Now => DateTime.Now;
    }
}
