namespace Application.SharedKernel.Common;

public abstract class ResultBase
{
    public bool IsSuccess { get; }
    public string? Message { get; }
    public string? ErrorCode { get; }

    protected ResultBase(bool isSuccess, string? message, string? errorCode)
    {
        IsSuccess = isSuccess;
        Message = message;
        ErrorCode = errorCode;
    }
}
