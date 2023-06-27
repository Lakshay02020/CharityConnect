namespace charity.Models;
public class MongoDBSettings{

    public string ConnectionURI { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string NgoCollectionName { get; set; } = null!;

    public string TransactionCollectionName { get; set; } = null!;


}