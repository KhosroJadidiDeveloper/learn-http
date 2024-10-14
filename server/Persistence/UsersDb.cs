using System.Security.Cryptography;
using server.Entities;
using server.Models;
using server.Result;
using server.Result.Failure;
using server.Result.Success;

namespace server.Persistence;

internal sealed class UsersDb
{
    private List<User> _users = [];

    internal Task<IResult<User>> GetUserAsync(int userId)
    {
        IResult<User> getResult;
        try
        {
            var user = _users.SingleOrDefault(user => user.Id == userId);
            getResult = user is null
                ? new FailureResult<User> { Reason = FailureReason.NotFound }
                : new SuccessResult<User> { Payload = user };
        }
        catch (Exception e)
        {
            getResult = new FailureResult<User> { Reason = FailureReason.Exception, Exception = e };
        }

        return Task.FromResult(getResult);
    }

    internal Task<IResult<User>> PostUserAsync(UserDto userDto)
    {
        IResult<User> postResult;
        try
        {
            var newUser = new User
            {
                Id = RandomNumberGenerator.GetInt32(1, 10),
                Age = userDto.Age,
                Name = userDto.Name
            };
            _users.Add(newUser);
            postResult = new SuccessResult<User>();
        }
        catch (Exception e)
        {
            postResult = new FailureResult<User> { Reason = FailureReason.Exception, Exception = e };
        }

        return Task.FromResult(postResult);
    }

    internal Task<IResult<User>> PutUserAsync(UserDto userDto)
    {
        try
        {
            if (userDto.Id is null)
            {
                IResult<User> failureResult = new FailureResult<User>() { Reason = FailureReason.NotFound };
                return Task.FromResult(failureResult);
            }

            var user = _users.SingleOrDefault(u => u.Id == userDto.Id);
            if (user is null)
            {
                IResult<User> failureResult = new FailureResult<User>() { Reason = FailureReason.NotFound };
                return Task.FromResult(failureResult);
            }

            var putUser = new User
            {
                Id = userDto.Id,
                Age = userDto.Age,
                Name = userDto.Name
            };
            _users.Remove(user);
            _users.Add(putUser);

            IResult<User> successResult = new SuccessResult<User>();
            return Task.FromResult(successResult);
        }
        catch (Exception e)
        {
            IResult<User> failureResult = new FailureResult<User> { Reason = FailureReason.Exception, Exception = e };
            return Task.FromResult(failureResult);
        }
    }
}