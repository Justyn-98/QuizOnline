namespace QuizOnlineApp.Interfaces
{
    public interface IServiceResponse
    {
        string Message { get; }
        bool Success { get; }
    }

    public interface IServiceResponse<T> : IServiceResponse
    {
        T Content { get; }
    }
}
