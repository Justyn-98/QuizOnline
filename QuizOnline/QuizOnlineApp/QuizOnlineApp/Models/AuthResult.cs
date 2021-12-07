namespace QuizOnlineApp.Models
{
    public class AuthResult
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public static AuthResult Ok(string token, string userId = null, string message = "Success")
        {

            return new AuthResult
            {
                UserId = userId,
                Token = token,
                Success = true,
                Message = message,
            };
        }

        public static AuthResult Error(string message)
        {

            return new AuthResult
            {
                UserId = null,
                Token = null,
                Success = false,
                Message = message
            };
        }
    }
}
