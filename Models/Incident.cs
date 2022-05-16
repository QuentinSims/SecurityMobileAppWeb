using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SecurityMobileAppWeb.Models
{
    public class Incident : BaseEntity
    {
        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Date of Incident")]
        public DateTime DateOfIncidentUtc { get; set; }

        [BsonElement("Location of Incident")]
        public Location LocationOfIncident { get; set; }

        [BsonElement("Description of Incident")]
        public string DescriptionOfIncident { get; set; }
    }
}
