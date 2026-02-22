using InterviewPrep.Application.Shared.DataTransfer;
using InterviewPrep.Application.Shared.ResponseTypes;

namespace InterviewPrep.HttpResponses;

public static class HandlerResponseExtensions
{
    public static IResult ToMinimalApiResult<T>(this HandlerResponseDto<T> response)
    {
        return response.ResponseType switch
        {
            SuccessResponseType success => success.Type switch
            {
                SuccessType.Ok => Results.Ok(response.Data),
                SuccessType.Created => Results.Created(string.Empty, response.Data),
                SuccessType.Accepted => Results.Accepted(string.Empty, response.Data),
                SuccessType.NoContent => Results.NoContent(),
                _ => Results.Ok(response.Data)
            },

            ErrorResponseType error => error.Type switch
            {
                ErrorType.BadRequest => Results.BadRequest(response.Message),
                ErrorType.NotFound => Results.NotFound(response.Message),
                ErrorType.Unauthorized => Results.Unauthorized(),
                ErrorType.Forbidden => Results.Forbid(),
                ErrorType.Conflict => Results.Conflict(response.Message),
                ErrorType.InternalServerError => Results.Problem(response.Message),
                _ => Results.Problem(response.Message)
            },

            _ => Results.Problem("Unhandled response type")
        };
    }
}