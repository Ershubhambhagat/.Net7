using System.Text.Json.Serialization;

namespace Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        knight = 1,
        Mega = 2,

        cleric = 3
    }
}