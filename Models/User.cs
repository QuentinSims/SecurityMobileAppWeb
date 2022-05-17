using MongoDB.Bson.Serialization.Attributes;

namespace SecurityMobileAppWeb.Models
{
    public class User : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Team")]
        public string Team { get; set; }
    }
}
