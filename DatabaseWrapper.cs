
using MongoDB.Driver;

namespace MongoWrapper;
public class DatabaseWrapper : IDatabaseWrapper
{
  private readonly IMongoClient _client;
  private readonly IMongoDatabase _database;
  public DatabaseWrapper(string connectionString, string databaseName) 
  {
    _client = new MongoClient(connectionString);
    _database = _client.GetDatabase(databaseName);
  }

  public IMongoCollection<T> InitialiseCollection<T>(string collectionName) =>
    _database.GetCollection<T>(collectionName);

  public IMongoClient RetrieveClient() =>
    _client;
}