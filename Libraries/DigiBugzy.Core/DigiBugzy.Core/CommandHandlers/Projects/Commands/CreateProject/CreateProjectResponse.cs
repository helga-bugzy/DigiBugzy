
namespace DigiBugzy.ApplicationLayer.Sections.Products.Commands.CreateProduct
{
    public class CreateProjectResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("bugzerId")]
        public string BugzerId { get; set; }
    }
}
