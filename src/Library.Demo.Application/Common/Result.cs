namespace Library.Demo.Application;

public record Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; } = default;
    public string? Error { get; }

    private Result(bool isSuccess, T value, string? error = "")
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T value) => new Result<T>(true, value);

    public static Result<T> Failure(string? error) => new Result<T>(false, default, error);

    public static Result<T> FromException(Exception exception) => new Result<T>(false, default, exception.Message);
}
