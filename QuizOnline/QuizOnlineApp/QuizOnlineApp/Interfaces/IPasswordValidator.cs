namespace QuizOnlineApp.Interfaces
{
    public interface IPasswordValidator
    {
        string GetValidationAlert(string password, string confirmPassword);
        bool GetResult(string password, string confirmPassword);
    }
}
