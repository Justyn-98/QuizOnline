namespace QuizOnlineApp.Models
{
    public class UserProfile : IPKModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}
