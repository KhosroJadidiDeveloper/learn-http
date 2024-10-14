namespace server.Result.Failure;

internal sealed class FailureResult<T>:IResult<T>
{
    internal required FailureReason Reason { get; set; }
    internal Exception? Exception { get; set; }
}

internal enum FailureReason
{
    NotFound = 1,
    Exception = 2
}