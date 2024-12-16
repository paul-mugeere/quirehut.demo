namespace QuireHut.Demo.Application.Common;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Data { get; } = default;
    public string? Error { get; }

    protected Result(bool isSuccess, T data, string? error = "")
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
    }

    public static Result<T> Success(T data) => new Result<T>(true, data);
    public static Result<T> Success(string message) => new Result<T>(true, default, message);

    public static Result<T> Failure(string? error) => new Result<T>(false, default, error);

    public static Result<T> FromException(Exception exception) => new Result<T>(false, default, exception.Message);
}
