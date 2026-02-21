namespace InterviewPrep.Application.Shared.ResponseTypes;

public abstract record ResponseType;

public sealed record SuccessResponseType(SuccessType Type) 
    : ResponseType;

public sealed record ErrorResponseType(ErrorType Type) 
    : ResponseType;