using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class NGO
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = null!;

    [BsonElement("description")]
    public string Description { get; set; } = null!;

    [BsonElement("email")]
    public string Email { get; set; } = null!;

    [BsonElement("location")]
    public string Location { get; set; } = null!;

    [BsonElement("website")]
    public string Website { get; set; } = null!;

    [BsonElement("contact")]
    public string Contact { get; set; } = null!;
}
