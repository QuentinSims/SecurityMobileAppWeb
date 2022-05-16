using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SecurityMobileAppWeb.Models
{
    public class Location : BaseEntity
    {
        [BsonElement("Latitude")]
        public double Latitude { get; set; }

        [BsonElement("Longitude")]
        public double Longitude { get; set; }
    }
}
