using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Transaction
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("user_id")]
    public string UserId { get; set; } = null!;

    [BsonElement("ngo_id")]
    public string NgoId { get; set; } = null!;

    [BsonElement("timestamp")]
    public DateTime Timestamp { get; set; }

    [BsonElement("amount")]
    public decimal Amount { get; set; } = 0;
}
