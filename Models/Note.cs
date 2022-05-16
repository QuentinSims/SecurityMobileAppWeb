using MongoDB.Bson.Serialization.Attributes;

namespace SecurityMobileAppWeb.Models
{
    public class Note : BaseEntity
    {
        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Date of Note")]
        public DateTime DateOfNote { get; set; }

        [BsonElement("Description of Note")]
        public string DescriptionOfNote { get; set; }
    }
}
