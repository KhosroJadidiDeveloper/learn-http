namespace server.Result.Success;

internal sealed class SuccessResult<T>:IResult<T>
{
    internal T Payload { get; set; }
}