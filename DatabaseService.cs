
using MongoDB.Driver;

namespace MongoWrapper;
public class DatabaseService : IDatabaseService
{
  private readonly IDatabaseWrapper _databaseWrapper;
  public DatabaseService(IDatabaseWrapper databaseWrapper)
  {
    _databaseWrapper = databaseWrapper;
  }

  public async Task CreateEntities<T>(List<T> entities, string collectionName)
  {
    var collection = _databaseWrapper.InitialiseCollection<T>(collectionName);
    await collection.InsertManyAsync(entities);
  }

  public async Task CreateEntity<T>(T entity, string collectionName)
  {
    var collection = _databaseWrapper.InitialiseCollection<T>(collectionName);
    await collection.InsertOneAsync(entity);
  }

  public async Task DeleteEntities<T>(FilterDefinition<T> filter, string collectionName)
  {
    var collection = _databaseWrapper.InitialiseCollection<T>(collectionName);
    await collection.DeleteManyAsync(filter);
  }

  public async Task DeleteEntity<T>(FilterDefinition<T> filter, string collectionName)
  {
    var collection = _databaseWrapper.InitialiseCollection<T>(collectionName);
    await collection.DeleteOneAsync(filter);
  }

  public async Task<List<T>> ReadEntities<T>(string collectionName)
  {
    var collection = _databaseWrapper.InitialiseCollection<T>(collectionName);
    var results = await collection.FindAsync(_ => true);
    return await results.ToListAsync();
  }

  public async Task<List<T>> ReadEntities<T>(FilterDefinition<T> filter, string collectionName)
  {
    var collection = _databaseWrapper.InitialiseCollection<T>(collectionName);
    var results = await collection.FindAsync(filter);
    return await results.ToListAsync();
  }

  public async Task<List<T>> ReadEntities<T>(Func<T, bool> filter, string collectionName)
  {
    var collection = _databaseWrapper.InitialiseCollection<T>(collectionName);
    var results = await collection.FindAsync(_ => true);
    return results.ToEnumerable().Where(filter).ToList();
  }

  public async Task<T> ReadEntity<T>(FilterDefinition<T> filter, string collectionName)
  {
    var collection = _databaseWrapper.InitialiseCollection<T>(collectionName);
    return await collection.Find(filter).FirstOrDefaultAsync();
  }

  public async Task UpdateEntities<T>(FilterDefinition<T> filter, UpdateDefinition<T> update, string collectionName)
  {
    var collection = _databaseWrapper.InitialiseCollection<T>(collectionName);
    await collection.UpdateOneAsync(filter, update);
  }

  public async Task UpdateEntity<T>(FilterDefinition<T> filter, UpdateDefinition<T> update, string collectionName)
  {
    var collection = _databaseWrapper.InitialiseCollection<T>(collectionName);
    await collection.UpdateManyAsync(filter, update);
  }
}