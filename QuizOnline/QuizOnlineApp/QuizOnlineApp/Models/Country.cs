namespace QuizOnlineApp.Models
{
    public class Country : IPKModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FlagUri { get; set; }
    }
}
