using System.Text.Json;

namespace server.Models;

internal sealed class UserDto
{
    internal int? Id { get; set; }
    internal required string Name { get; set; }
    internal required int Age { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}