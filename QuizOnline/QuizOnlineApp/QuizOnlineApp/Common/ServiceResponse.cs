using QuizOnlineApp.Interfaces;

namespace QuizOnlineApp.Common
{
    public class ServiceResponse : IServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static ServiceResponse Ok(string message = "Success")
        {
            return new ServiceResponse
            {
                Success = true,
                Message = message,
            };
        }

        public static ServiceResponse Error(string message)
        {
            return new ServiceResponse
            {
                Success = false,
                Message = message
            };
        }
    }
    
    public class ServiceResponse<T> : ServiceResponse, IServiceResponse<T>
    {
        public T Content { get; set; }

        public static ServiceResponse<T> Ok(T content, string message = "Success")
        {
            return new ServiceResponse<T>
            {
                Content = content,
                Success = true,
                Message = message,
            };
        }

        public static new ServiceResponse<T> Error(string message)
        {
            return new ServiceResponse<T>
            {
                Content = default,
                Success = false,
                Message = message
            };
        }
    }
}
