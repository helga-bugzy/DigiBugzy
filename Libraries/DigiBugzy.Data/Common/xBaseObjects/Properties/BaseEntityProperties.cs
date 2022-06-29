namespace DigiBugzy.Data.Common.xBaseObjects.Properties
{
    public class BaseEntityProperties
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("digiadminid")]
        public int DigiAdminId { get; set; }

        [JsonPropertyName("isactive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isdeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("createdon")]
        public bool CreatedOn { get; set; }


    }
}
