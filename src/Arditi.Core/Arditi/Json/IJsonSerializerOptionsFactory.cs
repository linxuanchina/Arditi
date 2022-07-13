using System.Text.Json;

namespace Arditi.Json;

public interface IJsonSerializerOptionsFactory
{
    JsonSerializerOptions Create();
}
