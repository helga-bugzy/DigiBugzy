

namespace DigiBugzy.ApplicationLayer.Sections.Products.Queries.GetAllProducts
{
    public class GetAllProductsResponse
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
