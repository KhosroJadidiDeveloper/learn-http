namespace server.Models;

internal sealed class UserDto
{
    internal int? Id { get; set; }
    internal required string Name { get; set; }
    internal required int Age { get; set; }
}