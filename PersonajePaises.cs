namespace RPG;
using System.Text;
using System.Text.Json.Serialization;

public class Country
{
    [JsonPropertyName("country_id")]
    public string country_id { get; set; }

    [JsonPropertyName("probability")]
    public double probability { get; set; }
}

public class PersonajePaises
{
    [JsonPropertyName("count")]
    public int count { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("country")]
    public List<Country> country { get; set; }
}