using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace QuireHut.Demo.Infrastructure.Persistence.Helpers;

public class JsonValueConverter<T> : ValueConverter<T, string>
{
     public static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public JsonValueConverter() : base(
        d => JsonSerializer.Serialize(d, _options),
        s => JsonSerializer.Deserialize<T>(s, _options))
    { }
}
