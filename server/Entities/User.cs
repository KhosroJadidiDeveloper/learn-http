using System.Text.Json;

namespace server.Entities;

internal sealed class User
{
    internal required int? Id { get; set; }
    internal required string Name { get; set; }
    internal required int Age { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}