namespace DigiBugzy.Data.Common.xBaseObjects.Properties
{
    public class BaseAdminsProperties : BaseEntityProperties
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }


    }
}
