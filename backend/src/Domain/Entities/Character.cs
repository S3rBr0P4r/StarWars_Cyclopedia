using System.Text.Json.Serialization;

namespace StarWars_Cyclopedia.Domain.Entities
{
    public class Character
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("height")]
        public string Height { get; set; }
        [JsonPropertyName("mass")]
        public string Mass { get; set; }
        [JsonPropertyName("hair_color")]
        public string HairColor { get; set; }
        [JsonPropertyName("skin_color")]
        public string SkinColor { get; set; }
        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; }
        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("homeworld")]
        public string HomeWorld { get; set; }
        [JsonPropertyName("films")]
        public IReadOnlyList<string> Films { get; set; }
        [JsonPropertyName("species")]
        public IReadOnlyList<string> Species { get; set; }
        [JsonPropertyName("vehicles")]
        public IReadOnlyList<string> Vehicles { get; set; }
        [JsonPropertyName("starships")]
        public IReadOnlyList<string> Starships { get; set; }
        [JsonPropertyName("created")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("edited")]
        public DateTime EditedAt { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
