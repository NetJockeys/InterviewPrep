using InterviewPrep.Application.Shared.ResponseTypes;

namespace InterviewPrep.Application.Shared.DataTransfer;

public class HandlerResponseDto<T>
{
    public T? Data { get; set; }
    public string Message { get; set; } = "The operation has been completed successfully";
    public bool IsSuccess { get; set; }
    public required ResponseType ResponseType { get; set; }

    // =========================
    // FLUENT FACTORY METHODS
    // =========================

    // Success
    public static HandlerResponseDto<T> Success(T data)
        => new()
        {
            IsSuccess = true,
            Data = data,
            ResponseType = new SuccessResponseType(SuccessType.Ok)
        };

    public static HandlerResponseDto<T> SuccessCreated(T data)
        => new()
        {
            IsSuccess = true,
            Data = data,
            ResponseType = new SuccessResponseType(SuccessType.Created)
        };

    public static HandlerResponseDto<T> SuccessAccepted(T data)
        => new()
        {
            IsSuccess = true,
            Data = data,
            ResponseType = new SuccessResponseType(SuccessType.Accepted)
        };

    public static HandlerResponseDto<T> SuccessNoContent()
        => new()
        {
            IsSuccess = true,
            Data = default,
            ResponseType = new SuccessResponseType(SuccessType.NoContent)
        };

    // Error
    public static HandlerResponseDto<T> FailureNotFound(string? message = null)
        => new()
        {
            IsSuccess = false,
            Data = default,
            ResponseType = new ErrorResponseType(ErrorType.NotFound),
            Message = message ?? "Resource not found"
        };

    public static HandlerResponseDto<T> FailureBadRequest(string? message = null)
        => new()
        {
            IsSuccess = false,
            Data = default,
            ResponseType = new ErrorResponseType(ErrorType.BadRequest),
            Message = message ?? "Bad request"
        };

    public static HandlerResponseDto<T> FailureUnauthorized(string? message = null)
        => new()
        {
            IsSuccess = false,
            Data = default,
            ResponseType = new ErrorResponseType(ErrorType.Unauthorized),
            Message = message ?? "Unauthorized"
        };

    public static HandlerResponseDto<T> FailureForbidden(string? message = null)
        => new()
        {
            IsSuccess = false,
            Data = default,
            ResponseType = new ErrorResponseType(ErrorType.Forbidden),
            Message = message ?? "Forbidden"
        };

    public static HandlerResponseDto<T> FailureConflict(string? message = null)
        => new()
        {
            IsSuccess = false,
            Data = default,
            ResponseType = new ErrorResponseType(ErrorType.Conflict),
            Message = message ?? "Conflict occurred"
        };

    public static HandlerResponseDto<T> FailureInternal(string? message = null)
        => new()
        {
            IsSuccess = false,
            Data = default,
            ResponseType = new ErrorResponseType(ErrorType.InternalServerError),
            Message = message ?? "Internal server error"
        };

    // =========================
    // FLUENT CHAINING METHODS
    // =========================

    public HandlerResponseDto<T> WithMessage(string message)
    {
        Message = message;
        return this;
    }

    public HandlerResponseDto<T> WithData(T data)
    {
        Data = data;
        return this;
    }

    public HandlerResponseDto<T> MarkAsSuccess(SuccessType type = SuccessType.Ok)
    {
        IsSuccess = true;
        ResponseType = new SuccessResponseType(type);
        return this;
    }

    public HandlerResponseDto<T> MarkAsError(ErrorType type, string? message = null)
    {
        IsSuccess = false;
        ResponseType = new ErrorResponseType(type);
        if (message != null) Message = message;
        return this;
    }
}