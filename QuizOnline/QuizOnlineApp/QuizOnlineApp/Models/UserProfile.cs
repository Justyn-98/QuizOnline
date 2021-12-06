namespace QuizOnlineApp.Models
{
    public class UserProfile : SetInTimeModel, IPKModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int RankPoints { get; set; }
        public int RankGames { get; set; }
    }
}
