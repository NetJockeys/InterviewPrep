namespace InterviewPrep.Application.Shared.ResponseTypes;

public enum ErrorType
{
    Validation,
    NotFound,
    Unauthorized,
    Conflict,
    Forbidden,
    Unexpected,
    InternalServerError,
    BadRequest
}