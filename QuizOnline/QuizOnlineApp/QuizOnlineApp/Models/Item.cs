using System;

namespace QuizOnlineApp.Models
{
    public class Item : IPKModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}